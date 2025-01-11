using Dapper;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Dapper;

namespace Shop.Infrastructure.Persistent.Ef.Configurations.SellerAgg;

internal class SellerRepository:BaseRepository<Seller>, ISellerRepository
{
    private readonly ShopDapperContext _dapperContext;
    public SellerRepository(ShopContext context, ShopDapperContext dapperContext) : base(context)
    {
        _dapperContext = dapperContext;
    }

    public async Task<InventoryResponse?> GetInventoryById(long id)
    {
        using var connection = _dapperContext.CreateConnection();
        var query = $"SELECT * from {_dapperContext.Inventories} where Id=@id";
         return await connection.QueryFirstOrDefaultAsync<InventoryResponse>(query, new { Id = id });
    }
}