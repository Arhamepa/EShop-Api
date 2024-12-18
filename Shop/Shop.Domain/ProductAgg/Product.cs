using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utilities;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAgg.Service;

namespace Shop.Domain.ProductAgg;

public class Product:AggregateRoot
{

    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Slug { get; private set; }
    public string ImageName { get; private set; }
    public long CategoryId { get; private set; }
    public long SubCategoryId { get;private set; }
    public long SecondarySubCategoryId { get; private set; }
    public SeoData SeoData { get; private set; }
    public List<ProductImage> Images { get; private set; }
    public List<ProductSpecification> Specifications { get; private set; }
    public Product(
        string title,
        string description,
        string slug,
        string imageName,
        long categoryId,
        long subCategoryId,
        long secondarySubCategoryId,
        SeoData seoData,
        IProductDomainService domainService)
    {
        NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
        Guard(title, description, slug, domainService);
        Title = title;
        Description = description;
        Slug = slug.ToString();
        ImageName = imageName;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SecondarySubCategoryId = secondarySubCategoryId;
        SeoData = seoData;
    }
    public void Edit(
        string title,
        string description,
        string slug,
        long categoryId,
        long subCategoryId,
        long secondarySubCategoryId,
        SeoData seoData,
        IProductDomainService domainService)
    {
    
        Guard(title,description,slug,domainService);
        Title = title;
        Description = description;
        Slug = slug.ToSlug();
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SecondarySubCategoryId = secondarySubCategoryId;
        SeoData = seoData;
    }
    
    public void AddImage(ProductImage image)
    {
        Images.Add(image);
    }

    public void RemoveImage(long id)
    {
        var existImage = Images.FirstOrDefault(i => i.Id == id);
        if (existImage == null)
            return;
        Images.Remove(existImage);
    }

    public void SetProductImage(string imageName)
    {
        NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
         ImageName=imageName;
    }
    public void SetSpecification(List<ProductSpecification> specifications)
    {
        Specifications = specifications;
    }

    public void Guard(string title, string description,string slug, IProductDomainService domainService)
    {
        NullOrEmptyDomainDataException.CheckString(title , nameof(title));
        NullOrEmptyDomainDataException.CheckString(description, nameof(description));
        NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));
        
        if(slug!=Slug)
            if (domainService.SlugIsExist(slug.ToSlug()))
                throw new SlugIsDuplicateException();
    }
}