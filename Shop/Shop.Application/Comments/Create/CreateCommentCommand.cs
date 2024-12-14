using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Comments.Create;

public record CreateCommentCommand(long UserId, long ProductId, string Text , Comment.CommentStatus Status) : IBaseCommand;
