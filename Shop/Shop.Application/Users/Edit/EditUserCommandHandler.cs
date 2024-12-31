using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Edit;

public class EditUserCommandHandler:IBaseCommandHandler<EditUserCommand>
{
    private readonly IUserRepository _repository;
    private readonly IUserDomainService _userDomainService;
    private readonly IFileService _fileService;

    public EditUserCommandHandler(IUserRepository repository, IUserDomainService userService, IFileService fileService)
    {
        _repository = repository;
        _userDomainService = userService;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        user.Edit(request.Name, request.Family, request.PhoneNumber, request.Email, request.Gender, _userDomainService);
        var oldImage = user.AvatarName;
        if (request.Avatar != null)
        {
            var imageName =
                await _fileService.SaveFileAndGenerateName(request.Avatar, Directories.UserAvatarsImagesPath);
            user.SetAvatar(imageName);
        }

        DeleteOldAvatar(request.Avatar, oldImage);
        await _repository.Save();
        return OperationResult.Success();
    }

    private void DeleteOldAvatar(IFormFile? avatar, string oldImage)
    {
        if (avatar ==null || oldImage=="avatar.png")
            return;
        _fileService.DeleteFile(Directories.UserAvatarsImagesPath , oldImage);
        
    }
}