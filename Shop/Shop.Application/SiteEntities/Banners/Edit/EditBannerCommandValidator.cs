using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;
using Shop.Application.SiteEntities.Banner.Create;

namespace Shop.Application.SiteEntities.Banners.Edit;

public class EditBannerCommandValidator:AbstractValidator<EditBannerCommand>
{
    public EditBannerCommandValidator()
    {
        RuleFor(i => i.ImageFile)
            .JustImageFile();

        RuleFor(l => l.Link)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("لینک"));
    }
}