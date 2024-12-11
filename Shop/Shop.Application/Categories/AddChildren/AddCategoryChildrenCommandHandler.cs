using Common.Application;
using Common.Application.Validation;
using FluentValidation;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Service;

namespace Shop.Application.Categories.AddChildren;

public class AddCategoryChildrenCommandHandler : IBaseCommandHandler<AddCategoryChildrenCommand>
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryDomainService _domainService;

    public AddCategoryChildrenCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(AddCategoryChildrenCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetTracking(request.ParentId);
        if (category == null)
            return OperationResult.NotFound();
        category.AddChildren(request.Title, request.Slug, request.SeoData, _domainService);
        return OperationResult.Success();
    }


  
}