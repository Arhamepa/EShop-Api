using Common.Application;

namespace Shop.Application.Orders.IncreaseOrderItemCount;

public record IncreaseOrderItemCountCommand(long UserId , long ItemId , int Count) : IBaseCommand;