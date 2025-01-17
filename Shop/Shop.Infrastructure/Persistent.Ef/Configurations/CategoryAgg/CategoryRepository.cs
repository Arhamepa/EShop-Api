﻿using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.Configurations.CategoryAgg;

internal class CategoryRepository:BaseRepository<Category> , ICategoryRepository
{
    public CategoryRepository(ShopContext context) : base(context)
    {
    }
}