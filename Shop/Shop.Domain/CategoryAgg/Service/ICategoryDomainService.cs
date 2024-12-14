namespace Shop.Domain.CategoryAgg.Service;

public interface ICategoryDomainService
{
    bool SlugIsExist(string slug);
}