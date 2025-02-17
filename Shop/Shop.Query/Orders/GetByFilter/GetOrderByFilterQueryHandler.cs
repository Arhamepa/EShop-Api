using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.GetByFilter;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetByFilter;

internal class GetOrderByFilterQueryHandler:IQueryHandler<GetOrderByFilterQuery , OrderFilterResult>
{
    private readonly ShopContext _context;

    public GetOrderByFilterQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
    {
        var @param = request.FilterParams;
        var result =  _context.Orders.OrderByDescending(o => o.Id).AsQueryable();

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
        var model = new OrderFilterResult()
        {
            Data = await result.Skip(skip).Take(@param.Take)
                .Select(o => o.MapFilteredOrder(_context))
                .ToListAsync(cancellationToken),
            FilterParam = @param

        };
        model.GeneratePaging(result, @param.Take, @param.PageId);
        return model;
    }
}