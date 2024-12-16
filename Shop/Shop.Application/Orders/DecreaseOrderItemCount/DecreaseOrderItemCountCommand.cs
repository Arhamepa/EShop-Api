using Common.Application;
using Shop.Application.Orders.IncreaseOrderItemCount;

namespace Shop.Application.Orders.DecreaseOrderItemCount;

public record DecreaseOrderItemCountCommand(long UserId, long ItemId, int Count) : IBaseCommand;