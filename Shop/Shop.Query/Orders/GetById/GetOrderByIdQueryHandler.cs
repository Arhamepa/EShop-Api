using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetById;

internal class GetOrderByIdQueryHandler:IQueryHandler<GetOrderByIdQuery , OrderDto?>
{
    private readonly ShopContext _context;
    private readonly ShopDapperContext _dapperContext;

    public GetOrderByIdQueryHandler(ShopContext context, ShopDapperContext dapperContext)
    {
        _context = context;
        _dapperContext = dapperContext;
    }

    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order =await _context.Orders.FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);
        if (order == null)
            return null;

        var orderDto = order.Map();
        orderDto.UserFullName = await _context.Users.Where(u => u.Id == orderDto.UserId)
            .Select(s => $"{s.Name} {s.Family}").FirstAsync(cancellationToken);
        orderDto.Items = await orderDto.GetOrderItems(_dapperContext);

        return orderDto;
    }
}