using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Common.Query.Filter;
using Shop.Domain.CommentAgg;

namespace Shop.Query.Comments.DTOs;

public class CommentDto:BaseDto
{
    public long Id { get; set; }
    public long UserId { get;  set; }
    public long ProductId { get;  set; }
    public string UserFullName { get; set; }
    public string ProductTitle { get; set; }
    public string Text { get;  set; }
    public Comment.CommentStatus Status { get;  set; }
}

public class CommentFilterParams:BaseFilterParams
{
    
    public long? UserId { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public Comment.CommentStatus? Status { get;  set; }
}

public class CommentFilterResult:BaseFilter<CommentDto , CommentFilterParams>
{

}