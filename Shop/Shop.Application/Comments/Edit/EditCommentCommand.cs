using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Comments.Edit;

public record EditCommentCommand(long CommentId,string Text , long UserId ) : IBaseCommand;