using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Edit;

public class EditCommentCommandValidator:AbstractValidator<EditCommentCommand>
{
    public EditCommentCommandValidator()
    {
        RuleFor(t => t.Text)
            .NotNull()
            .MaximumLength(5).WithMessage(ValidationMessages.maxLength("متن نظر", 5));
    }
}