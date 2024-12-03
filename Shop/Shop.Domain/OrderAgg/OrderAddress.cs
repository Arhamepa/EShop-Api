using Common.Domain;

namespace Shop.Domain.OrderAgg;

public class OrderAddress : BaseEntity
{
    public OrderAddress(
        string province,
        string city,
        string postalAddress,
        string postalCode,
        string phoneNumber,
        string name,
        string family,
        string nationalCode)
    {
        Province = province;
        City = city;
        PostalAddress = postalAddress;
        PostalCode = postalCode;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;

    }

    public long OrderId { get; internal set; }
    public string Province { get; private set; }
    public string City { get; private set; }
    public string PostalAddress { get; private set; }
    public string PostalCode { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }
    public Order Order { get;  set; }

}