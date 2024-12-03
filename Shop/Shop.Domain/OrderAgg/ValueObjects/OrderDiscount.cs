using Common.Domain;

namespace Shop.Domain.OrderAgg.ValueObjects;

public class OrderDiscount:ValueObject
{
    public OrderDiscount(int discountAmount, string discountTitle, string discountDescription)
    {
        DiscountAmount = discountAmount;
        DiscountTitle = discountTitle;
        DiscountDescription = discountDescription;
    }

    public string DiscountTitle { get;private set; }
    public int DiscountAmount { get;private set; }
    public string DiscountDescription { get;private set; }
}