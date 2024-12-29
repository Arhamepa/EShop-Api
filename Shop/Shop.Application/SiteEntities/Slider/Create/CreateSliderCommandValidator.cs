using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.SiteEntities.Slider.Create;

public class CreateSliderCommandValidator:AbstractValidator<CreateSliderCommand>
{
    public CreateSliderCommandValidator()
    {
        RuleFor(i => i.ImageFile)
            .NotNull().WithMessage(ValidationMessages.required("عکس"))
            .JustImageFile();

        RuleFor(l => l.Link)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("لینک"));

        RuleFor(t => t.Title)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
    }
}