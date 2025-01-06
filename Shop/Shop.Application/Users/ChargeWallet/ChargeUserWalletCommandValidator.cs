using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.ChargeWallet;

public class ChargeUserWalletCommandValidator : AbstractValidator<ChargeUserWalletCommand>
{
    public ChargeUserWalletCommandValidator()
    {
        RuleFor(r => r.Description)
            .NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

        RuleFor(r => r.Amount)
            .GreaterThanOrEqualTo(1000);
    }
}