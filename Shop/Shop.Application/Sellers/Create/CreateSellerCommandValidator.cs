using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Sellers.Create;

public class CreateSellerCommandValidator:AbstractValidator<CreateSellerCommand>
{
    public CreateSellerCommandValidator()
    {
        RuleFor(i => i.ShopName)
            .NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));

        RuleFor(n => n.NationalCode)
            .NotEmpty().WithMessage(ValidationMessages.required("کد ملی"))
            .ValidNationalId();
    }
}