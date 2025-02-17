using Common.Query;
using Common.Query.Filter;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Query.Orders.DTOs;

public class OrderDto:BaseDto
{
    public long UserId { get;  set; }
    public string UserFullName { get; set; }
    public OrderStatus Status { get;  set; }
    public List<OrderItemDto> Items { get;  set; }
    public OrderDiscount? Discount { get;  set; }
    public OrderAddress? Address { get;  set; }
    public OrderShippingMethod? OrderShippingMethod { get;  set; }
    public int ItemCount => Items.Count;
    public DateTime? LastUpdate { get;  set; }
}

public class OrderItemDto : BaseDto
{
    public OrderItemProduct Product { get; set; }
    public string ShopName { get; set; }
    public long OrderId { get;  set; }
    public long InventoryId { get; set; }
    public int Count { get;  set; }
    public int Price { get;  set; }
    public int TotalPrice => Count * Price;
}

public class OrderItemProduct
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string ImageName { get; set; }

}

public class OrderFilterData:BaseDto
{
    public long UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus Status { get; set; }
    public string? ShippingType { get; set; }
    public string? Province { get;  set; }
    public string? City { get;  set; }
    public int TotalPrice { get; set; }
    public int TotalItemCount { get; set; }

}

public class OrderFilterParams:BaseFilterParams
{
    public long? UserId { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public OrderStatus? Status { get; set; }
}

public class OrderFilterResult : BaseFilter<OrderFilterData, OrderFilterParams>
{

}