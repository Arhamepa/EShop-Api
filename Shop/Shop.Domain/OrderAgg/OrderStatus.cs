namespace Shop.Domain.OrderAgg;

public enum OrderStatus
{
    Pending,
    Preparing,
    Sending,
    Returned
}