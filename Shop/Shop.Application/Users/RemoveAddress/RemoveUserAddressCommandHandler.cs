using Common.Application;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.RemoveAddress;

internal class RemoveUserAddressCommandHandler : IBaseCommandHandler<RemoveUserAddressCommand>
{
    private readonly IUserRepository _repository;

    public RemoveUserAddressCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(RemoveUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        user.RemoveAddress(request.AddressId);
        await _repository.Save();
        return OperationResult.Success();
    }
}