using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.CategoryAgg;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories
{
    public static class CategoryMapper
    {
        public static CategoryDto Map(this Category? category)
        {
            if (category == null)
                return null;

            return new CategoryDto()
            {
                Title = category.Title,
                Slug = category.Slug,
                Id = category.Id,
                CreateDateTime = category.CreationDate,
                SeoData = category.SeoData,
                Children = category.Children.MapCategoryChildren()
            };
        }
        public static List<CategoryDto> Map(this List<Category> categories)
        {
            var model = new List<CategoryDto>();
            categories.ForEach(c =>
            {
                model.Add(new CategoryDto()
                {
                    Title = c.Title,
                    Slug = c.Slug,
                    Id = c.Id,
                    CreateDateTime = c.CreationDate,
                    SeoData = c.SeoData,
                    Children = c.Children.MapCategoryChildren()
                });
            });
            return model;
        }

        public static List<ChildCategoryDto> MapCategoryChildren(this List<Category> childrens)
        {
            var model = new List<ChildCategoryDto>();
            childrens.ForEach(c =>
            {
                model.Add(new ChildCategoryDto()
                {
                    Title = c.Title,
                    Slug = c.Slug,
                    Id = c.Id,
                    CreateDateTime = c.CreationDate,
                    SeoData = c.SeoData,
                    ParentId = (long)c.ParentId,
                    Children = c.Children.MapCategoryGrandChildren()
                });
            });
            return model;
        }

        private static List<GrandChildCategoryDto> MapCategoryGrandChildren(this List<Category> childrens)
        {
            var model = new List<GrandChildCategoryDto>();
            childrens.ForEach(c =>
            {
                model.Add(new GrandChildCategoryDto()
                {
                    Title = c.Title,
                    Slug = c.Slug,
                    Id = c.Id,
                    CreateDateTime = c.CreationDate,
                    SeoData = c.SeoData,
                    ParentId = (long)c.ParentId
                });
            });
            return model;
        }
    }
}
