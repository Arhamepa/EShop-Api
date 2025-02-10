using Shop.Domain.CommentAgg;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments;

internal static class CommentMapper
{
    public static CommentDto? Map(this Comment comment)
    {
        if (comment == null)
        {
            return null;
        }
        return new CommentDto()
        {
            Id = comment.Id,
            Status = comment.Status,
            Text = comment.Text,
            ProductId = comment.ProductId,
            UserId = comment.UserId
        };
    }
}