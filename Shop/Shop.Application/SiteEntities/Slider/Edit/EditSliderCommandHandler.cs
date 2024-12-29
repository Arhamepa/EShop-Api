using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Slider.Edit;

public class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
{
    private readonly ISliderRepository _repository;
    private readonly IFileService _fileService;

    public EditSliderCommandHandler(ISliderRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
    {
        var currentSlider = await _repository.GetTracking(request.SliderId);
        if (currentSlider == null)
            return OperationResult.NotFound();

        string imageName= currentSlider.ImageName;
        var oldImage = currentSlider.ImageName;
        if (request.ImageFile != null)
        {
            imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImagesPath);
        }
        currentSlider.Edit(request.Title , request.Link,imageName);
        await _repository.Save();

        DeleteOldImage(request.ImageFile , oldImage);

        return OperationResult.Success();
    }

    private void DeleteOldImage(IFormFile? imageFile, string oldImage)
    {
        if (imageFile != null)
        {
            _fileService.DeleteFile(Directories.SliderImagesPath,oldImage);
        }
    }
}