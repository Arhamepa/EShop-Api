using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Create;

public class CreateCommentCommandValidator:AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(t => t.Text)
            .NotNull()
            .MaximumLength(5).WithMessage(ValidationMessages.maxLength("متن نظر", 5));
    }
}