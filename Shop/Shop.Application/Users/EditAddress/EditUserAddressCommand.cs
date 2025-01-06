using Common.Application;
using Common.Domain.ValueObjects;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.EditAddress;

public class EditUserAddressCommand:IBaseCommand
{
    public EditUserAddressCommand(long userAddressId, long userId, string province, string city, string postalAddress, string postalCode, PhoneNumber phoneNumber, string name, string family, string nationalCode)
    {
        UserAddressId = userAddressId;
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

    public long UserAddressId { get; private set; }
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

public class EditUserAddressCommandHandler : IBaseCommandHandler<EditUserAddressCommand>
{
    private readonly IUserRepository _repository;

    public EditUserAddressCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        var address = new UserAddress(request.Province, request.City, request.PostalAddress, request.PostalCode,
            request.PhoneNumber, request.Name, request.Family, request.NationalCode);

        user.EditAddress(address ,request.UserAddressId);

        await _repository.Save();
        return OperationResult.Success();
    }
}