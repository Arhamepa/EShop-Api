namespace Shop.Domain.UserAgg.Services;

public interface IUserDomainService
{
    public bool IsEmailExist(string email);
    public bool IsPhoneNumberExist(string phoneNumber);
}