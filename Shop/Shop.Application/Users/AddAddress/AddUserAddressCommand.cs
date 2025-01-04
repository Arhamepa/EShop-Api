using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Users.AddAddress;

public class AddUserAddressCommand : IBaseCommand
{
    public AddUserAddressCommand(long userId, string province,
        string city, string postalAddress, string postalCode,
        PhoneNumber phoneNumber, string name, string family, string nationalCode)
    {
        UserId = userId;
        Province = province;
        City = city;
        PostalAddress = postalAddress;
        PostalCode = postalCode;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
    }
    public long UserId { get; internal set; }
    public string Province { get; private set; }
    public string City { get; private set; }
    public string PostalAddress { get; private set; }
    public string PostalCode { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }
}