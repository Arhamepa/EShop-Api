﻿using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Banners.Create;

internal class CreateBannerCommandHandler:IBaseCommandHandler<CreateBannerCommand>
{
    private readonly IBannerRepository _repository;
    private readonly IFileService _fileService;

    public CreateBannerCommandHandler(IBannerRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImagePath);
        var banner = new Domain.SiteEntities.Banner(request.Link , imageName,request.Position);

        await _repository.AddAsync(banner);
        await _repository.Save();
        return OperationResult.Success();
    }
}