using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.Create
{
    public class CreateProductCommand:IBaseCommand
    {
        public CreateProductCommand(
            string title,
            string description,
            string slug,
            IFormFile imageName,
            long categoryId,
            long subCategoryId,
            long secondarySubCategoryId,
            SeoData seoData, Dictionary<string, string> specifications)
        {
            Title = title;
            Description = description;
            Slug = slug;
            ImageFile = imageName;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            SeoData = seoData;
            Specifications = specifications;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; private set; }
        public IFormFile ImageFile { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondarySubCategoryId { get; private set; }
        public SeoData SeoData { get; private set; }
        public Dictionary<string,string> Specifications { get; private set; }
    }
}
