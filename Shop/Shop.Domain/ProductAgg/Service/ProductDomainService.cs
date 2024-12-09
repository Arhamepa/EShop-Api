namespace Shop.Domain.ProductAgg.Service;

public interface IProductDomainService
{
    bool SlugIsExist(string slug);

}