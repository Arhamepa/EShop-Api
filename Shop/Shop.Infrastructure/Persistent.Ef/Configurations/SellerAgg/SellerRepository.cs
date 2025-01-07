using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.Configurations.SellerAgg;

internal class SellerRepository:BaseRepository<Seller>, ISellerRepository
{
    public SellerRepository(ShopContext context) : base(context)
    {
    }

    public Task<InventoryResponse> GetInventoryById(long id)
    {
        return null;
    }
}