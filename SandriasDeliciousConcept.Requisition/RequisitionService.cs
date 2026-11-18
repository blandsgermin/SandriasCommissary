using System.Data;
using Microsoft.Data.SqlClient;
using SandriasDeliciousConcept.Contracts;
using SandriasDeliciousConcept.Data;

namespace SandriasDeliciousConcept.Requisition;

public class RequisitionService : IRequisitionService
{
    private readonly IEventBus _bus;
    public RequisitionService(IEventBus bus) => _bus = bus;

    private static SqlConnection Open()
    {
        var conn = new SqlConnection(DatabaseInitializer.AppConnection);
        conn.Open();
        return conn;
    }

    private static object Db(object? value) => value ?? DBNull.Value;

    private static SqlCommand Proc(SqlConnection conn, string name, SqlTransaction? tx = null) =>
        new(name, conn, tx) { CommandType = CommandType.StoredProcedure };

    public int Create(RequisitionDto rf)
    {
        using var conn = Open();
        using var tx = conn.BeginTransaction();
        try
        {
            using var cmd = Proc(conn, "dbo.usp_RF_Create", tx);
            cmd.Parameters.AddWithValue("@Requester", rf.Requester);
            cmd.Parameters.AddWithValue("@CustomerName", Db(rf.CustomerName));
            cmd.Parameters.AddWithValue("@EventDate", Db(rf.EventDate));
            cmd.Parameters.AddWithValue("@Venue", Db(rf.Venue));
            cmd.Parameters.AddWithValue("@Pax", Db(rf.Pax));
            cmd.Parameters.AddWithValue("@Menu", Db(rf.Menu));
            cmd.Parameters.AddWithValue("@Purpose", rf.Purpose);
            cmd.Parameters.AddWithValue("@RequiredDate", Db(rf.RequiredDate));
            var outId = new SqlParameter("@NewRfId", SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(outId);
            cmd.ExecuteNonQuery();
            int newId = (int)outId.Value;

            AddItems(conn, tx, newId, rf.Items);
            tx.Commit();
            return newId;
        }
        catch
        {
            tx.Rollback();
            throw;
        }
    }

    public void Update(RequisitionDto rf)
    {
        using var conn = Open();
        using var tx = conn.BeginTransaction();
        try
        {
            using var cmd = Proc(conn, "dbo.usp_RF_Update", tx);
            cmd.Parameters.AddWithValue("@RfId", rf.RfId);
            cmd.Parameters.AddWithValue("@CustomerName", Db(rf.CustomerName));
            cmd.Parameters.AddWithValue("@EventDate", Db(rf.EventDate));
            cmd.Parameters.AddWithValue("@Venue", Db(rf.Venue));
            cmd.Parameters.AddWithValue("@Pax", Db(rf.Pax));
            cmd.Parameters.AddWithValue("@Menu", Db(rf.Menu));
            cmd.Parameters.AddWithValue("@Purpose", rf.Purpose);
            cmd.Parameters.AddWithValue("@RequiredDate", Db(rf.RequiredDate));
            cmd.ExecuteNonQuery();

            AddItems(conn, tx, rf.RfId, rf.Items);
            tx.Commit();
        }
        catch
        {
            tx.Rollback();
            throw;
        }
    }

    private static void AddItems(SqlConnection conn, SqlTransaction tx, int rfId, IEnumerable<RequisitionItemDto> items)
    {
        foreach (var item in items)
        {
            using var cmd = Proc(conn, "dbo.usp_RFItem_Add", tx);
            cmd.Parameters.AddWithValue("@RfId", rfId);
            cmd.Parameters.AddWithValue("@ItemId", item.ItemId);
            cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
            cmd.Parameters.AddWithValue("@Unit", item.Unit);
            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
            cmd.ExecuteNonQuery();
        }
    }

    public RequisitionDto? GetById(int rfId)
    {
        using var conn = Open();
        RequisitionDto? rf = null;

        using (var cmd = Proc(conn, "dbo.usp_RF_GetById"))
        {
            cmd.Parameters.AddWithValue("@RfId", rfId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read()) rf = Map(reader, Array.Empty<RequisitionItemDto>());
        }
        if (rf is null) return null;

        var items = new List<RequisitionItemDto>();
        using (var cmd = Proc(conn, "dbo.usp_RFItem_GetByRf"))
        {
            cmd.Parameters.AddWithValue("@RfId", rfId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                items.Add(new RequisitionItemDto(
                    reader.GetInt32(reader.GetOrdinal("ItemId")),
                    reader.GetString(reader.GetOrdinal("ItemName")),
                    reader.GetString(reader.GetOrdinal("Unit")),
                    reader.GetDecimal(reader.GetOrdinal("Quantity"))));
        }
        return rf with { Items = items };
    }

    public IReadOnlyList<RequisitionDto> GetAll(RequisitionStatus? status = null)
    {
        using var conn = Open();
        using var cmd = Proc(conn, "dbo.usp_RF_GetAll");
        cmd.Parameters.AddWithValue("@Status", Db(status?.ToString()));
        using var reader = cmd.ExecuteReader();
        var list = new List<RequisitionDto>();
        while (reader.Read()) list.Add(Map(reader, Array.Empty<RequisitionItemDto>()));
        return list;
    }

    public void Approve(int rfId, string approvedBy)
    {
        using (var conn = Open())
        using (var cmd = Proc(conn, "dbo.usp_RF_Approve"))
        {
            cmd.Parameters.AddWithValue("@RfId", rfId);
            cmd.Parameters.AddWithValue("@ApprovedBy", approvedBy);
            cmd.ExecuteNonQuery();
        }
        _bus.Publish(new RequisitionApproved(rfId));
    }

    public void Return(int rfId, string reason) => Run("dbo.usp_RF_Return", rfId, "@Reason", reason);
    public void Cancel(int rfId, string reason) => Run("dbo.usp_RF_Cancel", rfId, "@Reason", reason);
    public void SetStatus(int rfId, RequisitionStatus status) => Run("dbo.usp_RF_SetStatus", rfId, "@Status", status.ToString());

    private static void Run(string proc, int rfId, string paramName, string value)
    {
        using var conn = Open();
        using var cmd = Proc(conn, proc);
        cmd.Parameters.AddWithValue("@RfId", rfId);
        cmd.Parameters.AddWithValue(paramName, value);
        cmd.ExecuteNonQuery();
    }

    private static RequisitionDto Map(SqlDataReader r, IReadOnlyList<RequisitionItemDto> items)
    {
        static string? Str(SqlDataReader r, string c) { int i = r.GetOrdinal(c); return r.IsDBNull(i) ? null : r.GetString(i); }
        static DateTime? Dt(SqlDataReader r, string c) { int i = r.GetOrdinal(c); return r.IsDBNull(i) ? null : r.GetDateTime(i); }
        static int? Num(SqlDataReader r, string c) { int i = r.GetOrdinal(c); return r.IsDBNull(i) ? null : r.GetInt32(i); }

        return new RequisitionDto(
            r.GetInt32(r.GetOrdinal("RfId")),
            r.GetString(r.GetOrdinal("RfNumber")),
            r.GetDateTime(r.GetOrdinal("RequestDate")),
            r.GetString(r.GetOrdinal("Requester")),
            Str(r, "CustomerName"),
            Dt(r, "EventDate"),
            Str(r, "Venue"),
            Num(r, "Pax"),
            Str(r, "Menu"),
            r.GetString(r.GetOrdinal("Purpose")),
            Dt(r, "RequiredDate"),
            Enum.Parse<RequisitionStatus>(r.GetString(r.GetOrdinal("Status"))),
            items);
    }
}