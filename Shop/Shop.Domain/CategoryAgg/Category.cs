using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utilities;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Service;

namespace Shop.Domain.CategoryAgg;

public class Category:AggregateRoot
{
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public long? ParentId { get; private set; }
    public List<Category> Children { get; private set; }
    public Category(string title, string slug, SeoData seoData, ICategoryDomainService service)
    {
        slug = slug?.ToSlug();
        Guard(title, slug, service);
        Title = title;
        Slug = slug;
        SeoData = seoData;
    }
    public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService service)
    {
        slug = slug?.ToSlug();
        Guard(title, slug, service);
        Title = title;
        Slug = slug;
        SeoData = seoData;
    }

    public void AddChildren(string title, string slug, SeoData seoData, ICategoryDomainService service)
    {
        Children.Add(new Category(title,slug,seoData,service)
        {
            ParentId = Id
        });
    }
    public void Guard(string title, string slug,ICategoryDomainService service)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

        if (slug != Slug)
            if (service.SlugIsExist(slug.ToSlug()))
                throw new SlugIsDuplicateException();
    }
}