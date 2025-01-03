﻿using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Service;

namespace Shop.Application.Products.Edit;

public class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
{
    private readonly IProductDomainService _domainService;
    private readonly IProductRepository _repository;
    private readonly IFileService _fileService;

    public EditProductCommandHandler(IProductDomainService domainService, IProductRepository repository,
        IFileService fileService)
    {
        _domainService = domainService;
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetTracking(request.ProductId);
        if (product == null)
            return OperationResult.NotFound();
        product.Edit(
            request.Title,
            request.Description,
            request.Slug,
            request.CategoryId,
            request.SubCategoryId,
            request.SecondarySubCategoryId,
            request.SeoData,
            _domainService);
        var oldImageName = product.ImageName;
        if (request.ImageFile != null)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImagePath);
            product.SetProductImage(imageName);
        }

        var specifications = new List<ProductSpecification>();

        request.Specifications.ToList().ForEach(
            specification =>
                specifications.Add(new ProductSpecification(specification.Key, specification.Value)));

        product.SetSpecification(specifications);
        await _repository.Save();
        RemoveOldImage(request.ImageFile, oldImageName);
        return OperationResult.Success();
    }

    private void RemoveOldImage(IFormFile? imageFile, string oldImageName)
    {
        if (imageFile != null)
        {
            _fileService.DeleteFile(Directories.ProductImagePath, oldImageName);
        }
    }

}