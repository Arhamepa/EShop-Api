using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Orders.AddItem;

public class AddOrderItemCommandHandler : IBaseCommandHandler<AddOrderItemCommand>
{
    private readonly IOrderRepository _repository;
    private readonly ISellerRepository _seller;

    public AddOrderItemCommandHandler(IOrderRepository repository, ISellerRepository seller)
    {
        _repository = repository;
        _seller = seller;
    }

    public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
    {
        var inventory =await _seller.GetInventoryById(request.InventoryId);
        if (inventory == null)
            return OperationResult.NotFound();
        if (inventory.Count < request.Count)
            return OperationResult.Error("تعداد محصولات درخواستی بیشتر از موجودی می باشد.");

        var order =await _repository.GetCurrentUserOrder(request.UserId);
        if (order == null)
            order=new Order(request.UserId);

        order.AddItem(new OrderItem(request.InventoryId , request.Count,inventory.Price));
        if(ItemCountBiggerthanInventoryCount(inventory , order))
            return OperationResult.Error("تعداد محصولات درخواستی بیشتر از موجودی می باشد.");

        await _repository.Save();
        return OperationResult.Success();
    }
    private bool ItemCountBiggerthanInventoryCount(InventoryResponse inventory, Order order)
    {
        var orderItem = order.Items.First(o => o.InventoryId == inventory.Id);
        if (orderItem.Count > inventory.Count)
            return true;
        return false;
    }
}