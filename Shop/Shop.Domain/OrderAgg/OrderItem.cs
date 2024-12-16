using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.OrderAgg;

public class OrderItem:BaseEntity
{
    public OrderItem( long inventoryId, int count, int price)
    {
        InventoryId = inventoryId;
        Count = count;
        Price = price;
    }

    public long OrderId { get; internal set; }
    public long InventoryId { get; set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int TotalPrice => Count * Price;
    public void IncreaseCount(int count)
    {
        Count += count;
    }

    public void DecreaseCount(int count)
    {
        if (Count == 1)
            return;
        if (Count - count <=0)
            return;

        Count -= count;
    }
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