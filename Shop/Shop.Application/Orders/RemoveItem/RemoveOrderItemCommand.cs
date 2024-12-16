using Common.Application;
using FluentValidation;

namespace Shop.Application.Orders.RemoveItem;

public record RemoveOrderItemCommand(long UserId, long OrderItemId) : IBaseCommand;