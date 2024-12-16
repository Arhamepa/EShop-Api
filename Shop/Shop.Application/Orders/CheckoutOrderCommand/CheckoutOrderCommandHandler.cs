using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.CheckoutOrderCommand;

public class CheckoutOrderCommandHandler:IBaseCommandHandler<CheckoutOrderCommand>
{
    private readonly IOrderRepository _repository;

    public CheckoutOrderCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
        if (currentOrder == null)
            return OperationResult.NotFound();

        var newAddress =  new OrderAddress(
           request.Province,
           request.City,
           request.PostalAddress,
           request.PostalCode,
           request.PhoneNumber,
           request.Name,
           request.Family,
           request.NationalCode);

       currentOrder.Checkout(newAddress);
       await _repository.Save();
       return OperationResult.Success();
    }
}