namespace Shop.Domain.UserAgg.Services;

public interface IDomainUserService
{
    public bool IsEmailExist(string email);
    public bool IsPhoneNumberExist(string phoneNumber);
}