using System.Data;
using Microsoft.Data.SqlClient;
using SandriasDeliciousConcept.Contracts;

namespace SandriasDeliciousConcept.Data;

public class SqlUserService : IUserService
{
    public CurrentUser? Login(string username, string password)
    {
        using var conn = new SqlConnection(DatabaseInitializer.AppConnection);
        conn.Open();
        using var cmd = new SqlCommand("dbo.usp_User_Login", conn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@Username", username);
        cmd.Parameters.AddWithValue("@Password", password);
        using var r = cmd.ExecuteReader();
        return r.Read()
            ? new CurrentUser(
                r.GetString(r.GetOrdinal("Username")),
                r.GetString(r.GetOrdinal("FullName")),
                r.GetString(r.GetOrdinal("Role")))
            : null;
    }
}