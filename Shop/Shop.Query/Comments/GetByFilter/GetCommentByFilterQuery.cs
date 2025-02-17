using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetByFilter;

public class GetCommentByFilterQuery:QueryFilter<CommentFilterResult , CommentFilterParams>
{

    public GetCommentByFilterQuery(CommentFilterParams filterParam) : base(filterParam)
    {
    }
}
public class GetCommentByFilterQueryHandler : IQueryHandler<GetCommentByFilterQuery , CommentFilterResult>
{
    private readonly ShopContext _context;

    public GetCommentByFilterQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
    {
        var @param = request.FilterParams;

        var result = _context.Comments.OrderByDescending(d => d.CreationDate).AsQueryable();

        if (@param.Status != null)
        {
            result = result.Where(i => i.Status == @param.Status);
        }
        if (@param.UserId != null)
        {
            result = result.Where(i => i.UserId == @param.UserId);
        }
        if (@param.StartDateTime != null)
        {
            result = result.Where(i => i.CreationDate >= @param.StartDateTime.Value.Date);
        }
        if (@param.EndDateTime != null)
        {
            result = result.Where(i => i.CreationDate <= @param.EndDateTime.Value.Date);
        }

        var skip = (@param.PageId - 1) * @param.Take;
        var model = new CommentFilterResult()
        {
            Data =await result.Skip(skip).Take(@param.Take).Select(comment => comment.MapFilteredComment()).ToListAsync(cancellationToken),
            FilterParam = @param
            
        };
        model.GeneratePaging(result,@param.Take,@param.PageId);
        return model;
    }
}    