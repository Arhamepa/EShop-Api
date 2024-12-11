﻿using Common.Application;
using Shop.Application.Categories.Create;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Service;

namespace Shop.Application.Categories.Edit;

public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryDomainService _domainService;

    public EditCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }
    public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category =await _repository.GetTracking(request.Id);
        if (category == null)
            return OperationResult.NotFound();
        category.Edit(request.Title,request.Slug,request.SeoData , _domainService);
        return OperationResult.Success();
    }


}