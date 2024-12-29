using Common.Application;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.EditInventory;

public class EditSellerInventoryCommand:IBaseCommand
{
    public EditSellerInventoryCommand(long sellerId, long inventoryId, int count, int price, int? disCountPercentage)
    {
        SellerId = sellerId;
        InventoryId = inventoryId;
        Count = count;
        Price = price;
        DisCountPercentage = disCountPercentage;
    }
    public long SellerId { get; private set; }
    public long InventoryId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int? DisCountPercentage { get; private set; }
}

public class EditSellerInventoryCommandHandler:IBaseCommandHandler<EditSellerInventoryCommand>
{
    private readonly ISellerRepository _repository;

    public EditSellerInventoryCommandHandler(ISellerRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(EditSellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId);
        if (seller == null)
            return OperationResult.NotFound();
        
        seller.EditInventory(request.InventoryId , request.Count , request.Price,request.DisCountPercentage);
        await _repository.Save();
        return OperationResult.Success();
    }
}