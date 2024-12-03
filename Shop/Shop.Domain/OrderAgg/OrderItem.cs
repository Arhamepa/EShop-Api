using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.OrderAgg;

public class OrderItem:BaseEntity
{
    public OrderItem(long orderId, long inventoryItem, int count, int price)
    {
        OrderId = orderId;
        InventoryItem = inventoryItem;
        Count = count;
        Price = price;
    }

    public long OrderId { get; internal set; }
    public long InventoryItem { get; set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int TotalPrice => Count * Price;

    public void ChangeCount(int lastCount)
    {
        ChangeGuard(lastCount);
        Count=lastCount;
    }

    public void SetPrice(int lastPrice)
    {
        PriceGuard(lastPrice);
        Price=lastPrice;
    }
    public void ChangeGuard(int count)
    {
        if (count < 1)
            throw new InvalidDomainDataException("تعداد کالا نا معتبر است");
    }
    public void PriceGuard(int price)
    {
        if (price < 1)
            throw new InvalidDomainDataException("مبلغ کالا نا معتبر است");
    }


}