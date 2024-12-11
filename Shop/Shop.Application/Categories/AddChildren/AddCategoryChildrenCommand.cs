using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Categories.AddChildren;

public record AddCategoryChildrenCommand(long ParentId, string Title, string Slug, SeoData SeoData) : IBaseCommand;