using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Service;

namespace Shop.Application.Products.Create;

public class CreateProductCommandHandler:IBaseCommandHandler<CreateProductCommand>
{
    private readonly IProductDomainService _domainService;
    private readonly IProductRepository _repository;
    private readonly IFileService _fileService;

    public CreateProductCommandHandler(IProductDomainService domainService, IProductRepository repository, IFileService fileService)
    {
        _domainService = domainService;
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var imageName =await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImagePath);

        var product = new Product(
            request.Title,
            request.Description,
            request.Slug,
            imageName,
            request.CategoryId,
            request.SubCategoryId,
            request.SecondarySubCategoryId,
            request.SeoData,
            _domainService);

        await _repository.AddAsync(product);
        var specifications = new List<ProductSpecification>();

        request.Specifications.ToList().ForEach(
            specification => 
                specifications.Add(new ProductSpecification(specification.Key , specification.Value)));

        product.SetSpecification(specifications);
        await _repository.Save();
        return OperationResult.Success();

    }
}