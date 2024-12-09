using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.CommentAgg;

public class Comment:AggregateRoot
{

    public long UserId { get; private set; }
    public long ProductId { get; private set; }
    public string Text { get; private set; }
    public CommentStatus Status { get; private set; }
    public DateTime UpdateDateTime { get; private set; }

    public Comment(string text, CommentStatus status, long userId, long productId)
    {
        NullOrEmptyDomainDataException.CheckString(text, nameof(text));
        Text = text;
        Status = CommentStatus.Pending;
        UserId = userId;
        ProductId = productId;
    }

    public void Edit(string text)
    {
        NullOrEmptyDomainDataException.CheckString(text, nameof(text));
        Text = text;
        UpdateDateTime = DateTime.Now;
    }

    public void ChangeStatus(CommentStatus status)
    {
        UpdateDateTime = DateTime.Now;
        Status = status;
    }
    public enum CommentStatus 
    {
        Pending,
        Accepted,
        Rejected,
    }
}