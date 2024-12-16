using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Orders.CheckoutOrderCommand;

public class CheckoutOrderCommandValidator:AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandValidator()
    {
        RuleFor(f => f.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("نام"));

        RuleFor(f => f.Family)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required(" نام خانوادگی"));

        RuleFor(f => f.City)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("شهر"));

        RuleFor(f => f.Province)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("استان"));

        RuleFor(f => f.PostalAddress)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("آدرس پستی"));

        RuleFor(f => f.PostalCode)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("کد پستی"));

        RuleFor(f => f.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("نام"))
            .MaximumLength(11).WithMessage("شماره موبایل نامعتبر است!0")
            .MinimumLength(11).WithMessage("شماره موبایل نامعتبر است!0");

        RuleFor(f => f.NationalCode)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("کد ملی"))
            .MaximumLength(10).WithMessage("کد ملی نامعتبر است!0")
            .MinimumLength(10).WithMessage("کد ملی نامعتبر است!0")
            .ValidNationalId();




    }
}