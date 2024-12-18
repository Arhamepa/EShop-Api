using Common.Application;
using Common.Domain.ValueObjects;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.Edit;

public class EditProductCommand:IBaseCommand
{
    public EditProductCommand(
        long productId,
        string title,
        string description,
        string slug,
        IFormFile? imageFile,
        long categoryId,
        long subCategoryId,
        long secondarySubCategoryId,
        SeoData seoData,
        Dictionary<string, string> specifications)
    {
        ProductId = productId;
        Title = title;
        Description = description;
        Slug = slug;
        ImageFile = imageFile;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SecondarySubCategoryId = secondarySubCategoryId;
        SeoData = seoData;
        Specifications = specifications;
    }

    public long ProductId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Slug { get; private set; }
    public IFormFile? ImageFile { get; private set; }
    public long CategoryId { get; private set; }
    public long SubCategoryId { get; private set; }
    public long SecondarySubCategoryId { get; private set; }
    public SeoData SeoData { get; private set; }
    public Dictionary<string, string> Specifications { get; private set; }
}