using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Service;

namespace Shop.Application.Products.Create
{
    public class CreateProductCommand:IBaseCommand
    {
        public CreateProductCommand(
            string title,
            string description,
            string slug,
            string imageName,
            long categoryId,
            long subCategoryId,
            long secondarySubCategoryId,
            SeoData seoData)
        {
            Title = title;
            Description = description;
            Slug = slug;
            ImageName = imageName;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            SeoData = seoData;
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
}
