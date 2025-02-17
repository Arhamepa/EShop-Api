using System.Data;
using Microsoft.Data.SqlClient;

namespace Shop.Infrastructure.Persistent.Dapper;

public class ShopDapperContext
{
    private readonly string _connectionString;

    public ShopDapperContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    public string Inventories => "[seller].Inventories";
    public string OrderItems => "[order].Items";
    public string Products => "[product].Products";
    public string Sellers => "[seller].Sellers";


}