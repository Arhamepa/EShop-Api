using Common.Domain.ValueObjects;
using Common.Query;
using Shop.Domain.CategoryAgg;

namespace Shop.Query.Categories.DTOs;

public class ChildCategoryDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public long? ParentId { get; set; }
    public List<GrandChildCategoryDto> Children { get; set; }
}