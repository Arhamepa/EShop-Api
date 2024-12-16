﻿using FluentValidation;

namespace Shop.Application.Orders.IncreaseOrderItemCount;

public class IncreaseOrderItemCountCommandValidator:AbstractValidator<IncreaseOrderItemCountCommand>
{
    public IncreaseOrderItemCountCommandValidator()
    {
        RuleFor(o => o.Count)
            .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}