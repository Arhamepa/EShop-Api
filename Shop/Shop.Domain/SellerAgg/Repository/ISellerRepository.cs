using Common.Domain.Repository;

namespace Shop.Domain.SellerAgg.Repository;

public interface ISellerRepository:IBaseRepository<Seller>
{
    Task<InventoryResponse> GetInventoryById(long id);
}

public class InventoryResponse
{
    public long Id { get; set; }
    public long InventoryId { get; set; }
    public int Count { get; set; }
    public long UserId { get; set; }
    public long SellerId { get; set; }
    public int Price { get; set; }
}