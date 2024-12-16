using FluentValidation;

namespace Shop.Application.Orders.DecreaseOrderItemCount;

public class DecreaseOrderItemCountCommandValidator:AbstractValidator<DecreaseOrderItemCountCommand>
{
    public DecreaseOrderItemCountCommandValidator()
    {
        RuleFor(o => o.Count)
            .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}