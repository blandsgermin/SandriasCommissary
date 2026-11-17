using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace SandriasDeliciousConcept.Data;

public static class DatabaseInitializer
{
    public const string DatabaseName = "SandriasCommissaryDb";

    public static string AppConnection =>
        $@"Server=(localdb)\MSSQLLocalDB;Database={DatabaseName};Integrated Security=true;TrustServerCertificate=true";

    public static void EnsureCreated()
    {
        using (var master = new SqlConnection(
            @"Server=(localdb)\MSSQLLocalDB;Database=master;Integrated Security=true;TrustServerCertificate=true"))
        {
            master.Open();
            using var cmd = new SqlCommand(
                $"IF DB_ID(N'{DatabaseName}') IS NULL CREATE DATABASE [{DatabaseName}];", master);
            cmd.ExecuteNonQuery();
        }

        var asm = typeof(DatabaseInitializer).Assembly;
        var scripts = asm.GetManifestResourceNames()
            .Where(n => n.EndsWith(".sql", StringComparison.OrdinalIgnoreCase))
            .OrderBy(n => n, StringComparer.OrdinalIgnoreCase);

        using var conn = new SqlConnection(AppConnection);
        conn.Open();

        foreach (var name in scripts)
        {
            using var stream = asm.GetManifestResourceStream(name)!;
            using var reader = new StreamReader(stream);
            var sql = reader.ReadToEnd();

            foreach (var batch in Regex.Split(sql, @"^\s*GO\s*$",
                         RegexOptions.Multiline | RegexOptions.IgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(batch)) continue;
                using var cmd = new SqlCommand(batch, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}