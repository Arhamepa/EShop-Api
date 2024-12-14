using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.AddChildren;

public class AddCategoryChildrenCommandValidator : AbstractValidator<AddCategoryChildrenCommand>
{
    public AddCategoryChildrenCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        RuleFor(r => r.Slug)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
    }
}