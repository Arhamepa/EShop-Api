using Dapper;
using Shop.Domain.CommentAgg;
using Shop.Domain.OrderAgg;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTOs;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders;

public static class OrderMapper
{
    public static OrderDto Map(this Order order)
    {
        return new OrderDto()
        {
            Id = order.Id,
            Status = order.Status,
            CreateDateTime = order.CreationDate,
            Address = order.Address,
            Discount = order.Discount,
            Items = new (),
            LastUpdate = order.LastUpdate,
            OrderShippingMethod = order.OrderShippingMethod,
            UserFullName = "",
            UserId = order.UserId
        };
    }
    public static async Task<List<OrderItemDto>> GetOrderItems(this OrderDto orderDto , ShopDapperContext dapperContext)
    {
        using var connection = dapperContext.CreateConnection();
        var sql = @$"SELECT o.Id, s.ShopName ,o.OrderId,o.InventoryId,o.Count,o.price,
                          p.Title as ProductTitle , p.Slug as ProductSlug ,
                          p.ImageName as ProductImageName
                    FROM {dapperContext.OrderItems} o
                    Inner Join {dapperContext.Inventories} i on o.InventoryId=i.Id
                    Inner Join {dapperContext.Products} p on i.ProductId=p.Id
                    Inner Join {dapperContext.Sellers} s on i.SellerId=s.Id
                    where o.OrderId=@orderId";
        var result = await connection.QueryAsync<OrderItemDto>(sql, new { orderId = orderDto.Id });
        return result.ToList();
    }
    public static OrderFilterData MapFilteredOrder(this Order order, ShopContext context)
    {
        var userFullName = context.Users
            .Where(i => i.Id == order.UserId)
            .Select(u => $"{u.Name} {u.Family}").First();
        return new OrderFilterData()
        {
            Id = order.Id,
            Status = order.Status,
            CreateDateTime = order.CreationDate,
            City = order.Address?.City,
            Province = order.Address?.Province,
            TotalPrice = order.TotalPrice,
            TotalItemCount = order.ItemCount,
            ShippingType = order.OrderShippingMethod?.ShippingType,
            UserFullName = userFullName,
            UserId = order.UserId
        };
    }
}