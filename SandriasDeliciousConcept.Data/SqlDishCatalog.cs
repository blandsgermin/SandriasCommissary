using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;
using SandriasDeliciousConcept.Contracts;

namespace SandriasDeliciousConcept.Data;

public class SqlDishCatalog : IDishCatalog
{
    public IReadOnlyList<DishDto> GetAll()
    {
        using var conn = new SqlConnection(DatabaseInitializer.AppConnection);
        conn.Open();
        using var cmd = new SqlCommand("dbo.usp_Dish_GetAll", conn) { CommandType = CommandType.StoredProcedure };
        using var r = cmd.ExecuteReader();
        var list = new List<DishDto>();
        while (r.Read()) list.Add(new DishDto(r.GetInt32(0), r.GetString(1), r.GetString(2)));
        return list;
    }
}