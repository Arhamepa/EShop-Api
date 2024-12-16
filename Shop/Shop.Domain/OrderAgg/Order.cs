using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.ValueObjects;
using Shop.Domain.UserAgg;

namespace Shop.Domain.OrderAgg;

public class Order:AggregateRoot
{
    private Order()
    {
        
    }
    public Order(long userId)
    {
        UserId = userId;
        Status = OrderStatus.Pending;
        Items =new List<OrderItem>();
    }

    public long UserId { get; private set; }
    public OrderStatus Status { get;private set; }
    public List<OrderItem> Items { get; private set; }
    public OrderDiscount? Discount { get;private set; }
    public OrderAddress? Address { get; private set; }
    public OrderShippingMethod? OrderShippingMethod { get; private set; }
    public int ItemCount => Items.Count;
    public DateTime? LastUpdate { get; private set; }

    public int TotalPrice
    {
        get
        {
            var totalPrice = Items.Sum(it => it.TotalPrice);
            if (OrderShippingMethod !=null)
                totalPrice += OrderShippingMethod.ShippingCost;
            if (Discount != null)
                totalPrice -= Discount.DiscountAmount;

            return totalPrice;
        }
    }

    public void AddItem(OrderItem item)
    {
        ChangeOrderGuard();
        var oldItem= Items.FirstOrDefault(it => it.InventoryId == item.Id);
        if (oldItem != null)
        {
            oldItem.ChangeCount(item.Count + oldItem.Count);
            return;
        }
        Items.Add(item);
    }

    public void RemoveItem(long itemId)
    {
        ChangeOrderGuard();
        var currentItem = Items.FirstOrDefault(it => it.Id == itemId);
        if (currentItem != null)
         Items.Remove(currentItem);
    }

    public void IncreaseItemCount(long itemId, int count)
    {
        ChangeOrderGuard();
        var currentItem = Items.FirstOrDefault(it => it.Id == itemId);
        if (currentItem == null)
            throw new NullOrEmptyDomainDataException();

        currentItem.IncreaseCount(count);
    }

    public void DecreaseItemCount(long itemId, int count)
    {
        ChangeOrderGuard();
        var currentItem = Items.FirstOrDefault(it => it.Id == itemId);
        if (currentItem == null)
            throw new NullOrEmptyDomainDataException();

        currentItem.DecreaseCount(count);
    }
   

    public void ChangeStatus(OrderStatus status)
    {
        Status = status;
        LastUpdate= DateTime.Now;
    }

    public void Checkout(OrderAddress orderAddress)
    {
        ChangeOrderGuard();
        Address = orderAddress;
    }

    public void ChangeOrderGuard()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidDomainDataException("امکان ویرایش این سفارش وجود ندارد!");

    }
}