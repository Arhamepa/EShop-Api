using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Service;

namespace Shop.Domain.SellerAgg;

public class Seller:AggregateRoot
{
    public Seller()
    {

    }
    public Seller(long userId, string shopName, string nationalCode,ISellerDomainService domainService)
    {
        Guard(shopName , nationalCode);
        UserId = userId;
        ShopName = shopName;
        NationalCode = nationalCode;
        Inventories = new List<SellerInventory>();

        if (domainService.IsInfoExist(this) == false)
            throw new InvalidDomainDataException("اطلاعات نا معتبر است");
    }

    public long UserId { get; private set; }
    public string ShopName { get; private set; }
    public string NationalCode { get; private set; }
    public SellerStatus Status { get; private set; }
    public DateTime? LatestUpDateTime { get; private set; }
    public List<SellerInventory> Inventories { get; private set; }

    public void ChangeStatus(SellerStatus status)
    {
        Status = status;
        LatestUpDateTime=DateTime.Now;
    }
    public void Edit(string shopName, string nationalCode, ISellerDomainService domainService)
    {
        Guard(shopName,nationalCode);
        ShopName = shopName;
        NationalCode = nationalCode;
        if(nationalCode != NationalCode)
            if (domainService.NationalCodeIsExist(nationalCode))
                throw new NationalCodeIsDuplicateException();
    }
    public void Guard(string shopName, string nationalCode)
    {
        NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
        NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
        if (IranianNationalCodeValidation.IsValid(nationalCode) == false)
            throw new InvalidDomainDataException("کد ملی نامعتبر است!");
    }
    public void AddInventory(SellerInventory newInventory)
    {
        if (Inventories.Any(i => i.ProductId == newInventory.ProductId))
            throw new InvalidDomainDataException("این محصول وجود دارد!");
        Inventories.Add(newInventory);
    }
    public void EditInventory(SellerInventory inventory)
    {
        var currentInventory = Inventories.FirstOrDefault(i => i.Id == inventory.Id);
        if (currentInventory == null)
            return;
        Inventories.Remove(currentInventory); 
        Inventories.Add(inventory);
    }
    public void DeleteInventory(SellerInventory inventory)
    {
        var currentInventory = Inventories.FirstOrDefault(i => i.Id == inventory.Id);
        if (currentInventory == null)
            throw new InvalidDomainDataException("محصول یافت نشد.");
        Inventories.Remove(currentInventory);
       
    }
}