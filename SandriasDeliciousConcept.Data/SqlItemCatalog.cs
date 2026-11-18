using System.Data;
using Microsoft.Data.SqlClient;
using SandriasDeliciousConcept.Contracts;

namespace SandriasDeliciousConcept.Data;

public class SqlItemCatalog : IItemCatalog
{
    public IReadOnlyList<ItemDto> GetAll()
    {
        using var conn = new SqlConnection(DatabaseInitializer.AppConnection);
        conn.Open();
        using var cmd = new SqlCommand("dbo.usp_Item_GetAll", conn) { CommandType = CommandType.StoredProcedure };
        using var r = cmd.ExecuteReader();
        var list = new List<ItemDto>();
        while (r.Read()) list.Add(new ItemDto(r.GetInt32(0), r.GetString(1), r.GetString(2)));
        return list;
    }
}