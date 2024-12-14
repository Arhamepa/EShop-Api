using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg;

public class User:AggregateRoot
{
    public User(
        string name,
        string family,
        string phoneNumber,
        string password,
        string email,
        Gender gender,
        IDomainUserService domainUserService)
    {
        Guard(phoneNumber, email, domainUserService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Password = password;
        Email = email;
        Gender = gender;
    }

    public string Name { get; private set; }
    public string Family { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public Gender Gender { get; set; }
    public List<UserAddress> Addresses { get; private set; }
    public List<UserRole> Roles { get; private set; }
    public List<Wallet> Wallets { get; private set; }

    public static User RegisterUser(string email , string phoneNumber , string password, IDomainUserService domainUserService)
    {
        return new User("", "", phoneNumber, password, email, Gender.None, domainUserService);
    }
   
    public void Edit(
        string name,
        string family,
        string phoneNumber,
        string email,
        Gender gender,
        IDomainUserService domainUserService)
    {
        Guard(phoneNumber, email, domainUserService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
    }
    
    public void RemoveAddress(long addressId)
    {
        var existAddress = Addresses.FirstOrDefault(adr => adr.Id == addressId);
        if (existAddress == null)
            throw new NullOrEmptyDomainDataException("آدرس پیدا نشد!");

        Addresses.Remove(existAddress);
    }
    public void AddAddress(UserAddress userAddress)
    {
        userAddress.UserId = Id;
        Addresses.Add(userAddress);
    }
    public void EditAddress(UserAddress userAddress)
    {
       var oldAddress =  Addresses.FirstOrDefault(adr => adr.Id == userAddress.Id);
       if (oldAddress ==null)
            throw new NullOrEmptyDomainDataException("آدرس پیدا نشد!");

       Addresses.Remove(oldAddress);
       Addresses.Add(userAddress);
    }

    public void ChargeWallet(Wallet wallet)
    {
        wallet.UserId= Id;
        Wallets.Add(wallet);
    }

    public void SetRoles(List<UserRole> userRoles)
    {
        userRoles.ForEach(r=>r.UserId =Id);
        Roles.Clear();
        Roles.AddRange(userRoles);
    }

    public void Guard(string phoneNumber, string email,IDomainUserService domainUserService)
    {
        NullOrEmptyDomainDataException.CheckString(phoneNumber,nameof(phoneNumber));
        if (phoneNumber.Length != 11)
            throw new InvalidDomainDataException("شماره موبایل نامعتبر است!");

        NullOrEmptyDomainDataException.CheckString(email, nameof(email));
        if (email.IsValidEmail() == false)
            throw new InvalidDomainDataException("ایمیل معتبر نمی باشد!");


        if (phoneNumber !=PhoneNumber)
            if (domainUserService.IsPhoneNumberExist(phoneNumber))
                throw new InvalidDomainDataException("شماره موبایل تکراری است!");

        if (email != Email)
            if (domainUserService.IsEmailExist(email))
                throw new InvalidDomainDataException("شماره ایمیل تکراری است!");
    }
}