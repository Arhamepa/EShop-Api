using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.AddInventory;

public class AddSellerInventoryCommand:IBaseCommand
{
    public long SellerId { get; private set; }
    public long ProductId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int? DisCountPercentage { get; private set; }
}

public class AddSellerInventoryCommandHandler : IBaseCommandHandler<AddSellerInventoryCommand>
{
    private readonly ISellerRepository _repository;

    public AddSellerInventoryCommandHandler(ISellerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(AddSellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId);
        if (seller == null)
            return OperationResult.NotFound();

        var inventory =
            new SellerInventory(request.ProductId, request.Count, request.Price, request.DisCountPercentage);

        seller.AddInventory(inventory);
        await _repository.Save();
        return OperationResult.Success();
    }
} 