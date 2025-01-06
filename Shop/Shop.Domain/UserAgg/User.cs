using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
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
        IUserDomainService domainUserService)
    {
        Guard(phoneNumber, email, domainUserService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Password = password;
        Email = email;
        Gender = gender;
        AvatarName = "avatar.png";
    }

    public string Name { get; private set; }
    public string Family { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public string AvatarName { get; set; }
    public Gender Gender { get; set; }
    public List<UserAddress> Addresses { get; private set; }
    public List<UserRole> Roles { get; private set; }
    public List<Wallet> Wallets { get; private set; }

    public static User RegisterUser( string phoneNumber , string password, IUserDomainService domainUserService)
    {
        return new User("", "", phoneNumber,null, password, Gender.None, domainUserService);
    }

    public void Edit(
        string name,
        string family,
        string phoneNumber,
        string email,
        Gender gender,
        IUserDomainService domainUserService)
    {
        Guard(phoneNumber, email, domainUserService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
    }

    public void SetAvatar(string imageName)
    {
        if (string.IsNullOrWhiteSpace(imageName))
            imageName = "avatar.png";

        AvatarName = imageName;
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
    public void EditAddress(UserAddress userAddress , long addressId)
    {
       var oldAddress =  Addresses.FirstOrDefault(adr => adr.Id == addressId);
       if (oldAddress ==null)
            throw new NullOrEmptyDomainDataException("آدرس پیدا نشد!");

       oldAddress.Edit(userAddress.Province, userAddress.City, userAddress.PostalAddress, userAddress.PostalCode,
            userAddress.PhoneNumber, userAddress.Name, userAddress.Family, userAddress.NationalCode);
       
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

    public void Guard(string phoneNumber, string email,IUserDomainService domainUserService)
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