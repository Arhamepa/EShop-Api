﻿using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.UserAgg;

public class UserAddress : BaseEntity
{
    public UserAddress(long userId, string province, string city, string postalAddress, string postalCode, string phoneNumber, string name, string family, string nationalCode)
    {
        Guard(
        province,
        city,
        postalAddress,
        postalCode,
        phoneNumber,
        name,
        family,
        nationalCode);
        UserId = userId;
        this.Province = province;
        City = city;
        PostalAddress = postalAddress;
        PostalCode = postalCode;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
        AddressActive=false;
    }

    public long UserId { get; internal set; }
    public string Province { get; private set; }
    public string City { get; private set; }
    public string PostalAddress { get; private set; }
    public string PostalCode { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }
    public bool AddressActive { get; set; }

    public void SetActive()
    {
        AddressActive = true;
    }

    public void Edit(
       
        
        string province,
        string city,
        string postalAddress,
        string postalCode,
        string phoneNumber,
        string name,
        string family,
        string nationalCode)
    {
        Guard(
            province,
            city,
            postalAddress,
            postalCode,
            phoneNumber,
            name,
            family,
            nationalCode);
        this.Province = province;
        City = city;
        PostalAddress = postalAddress;
        PostalCode = postalCode;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
    }   
    public void Guard(
           
            string province,
            string city,
            string postalAddress,
            string postalCode,
            string phoneNumber,
            string name,
            string family,
            string nationalCode)
        
    {
        NullOrEmptyDomainDataException.CheckString(province, nameof(province));
        NullOrEmptyDomainDataException.CheckString(city, nameof(city));
        NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
        NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
        NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
        NullOrEmptyDomainDataException.CheckString(name, nameof(name));
        NullOrEmptyDomainDataException.CheckString(family, nameof(family));
        NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));

        if (IranianNationalCodeValidation.IsValid(nationalCode) == false)
            throw new InvalidDomainDataException("کد ملی معتبر نیست!");
    }
}