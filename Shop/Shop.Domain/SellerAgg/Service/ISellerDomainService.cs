namespace Shop.Domain.SellerAgg.Service;

public interface ISellerDomainService
{
    bool IsInfoExist(Seller seller);
    bool NationalCodeIsExist(string nationalCode);
}