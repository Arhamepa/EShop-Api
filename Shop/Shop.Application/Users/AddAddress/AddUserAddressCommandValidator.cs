using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.AddAddress;

public class AddUserAddressCommandValidator:AbstractValidator<AddUserAddressCommand>
{
    public AddUserAddressCommandValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty().WithMessage(ValidationMessages.required("نام"));

        RuleFor(i => i.Family)
            .NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));

        RuleFor(i => i.Province)
            .NotEmpty().WithMessage(ValidationMessages.required("استان"));

        RuleFor(i => i.City)
            .NotEmpty().WithMessage(ValidationMessages.required("شهر"));

        RuleFor(i => i.PostalAddress)
            .NotEmpty().WithMessage(ValidationMessages.required("آدرس پستی"));
        RuleFor(i => i.PostalCode)
            .NotEmpty().WithMessage(ValidationMessages.required("کد پستی"))
            .MaximumLength(10).MinimumLength(10)
            .ValidPostalCode();
        RuleFor(i => i.NationalCode)
            .NotEmpty().WithMessage(ValidationMessages.required("کد ملی"))
            .ValidNationalId();
    }
}