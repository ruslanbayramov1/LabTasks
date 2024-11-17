using Microsoft.Data.SqlClient;
using System.Data;

namespace Repository.Helpers;

static class SqlHelper
{
    private const string _connStr = "Server=.\\MAINDB;Database=Academy;Trusted_Connection=True;TrustServerCertificate=True";
    public static async Task<int> Exec(string query)
    {
        using SqlConnection conn = new SqlConnection(_connStr);
        using SqlCommand cmd = new SqlCommand(query, conn);

        await conn.OpenAsync();
        int affRow = cmd.ExecuteNonQuery();
        await conn.CloseAsync();

        return affRow;
    }

    public static async Task<DataTable> Read(string query)
    {
        using SqlConnection conn = new SqlConnection(_connStr);
        using SqlDataAdapter sda = new SqlDataAdapter(query, conn);
        DataTable dt = new DataTable();

        await conn.OpenAsync();
        sda.Fill(dt);
        await conn.CloseAsync();

        return dt;
    }
}
