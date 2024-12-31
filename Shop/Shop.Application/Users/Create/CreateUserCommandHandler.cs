using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Create;

public class CreateUserCommandHandler:IBaseCommandHandler<CreateUserCommand>
{
    private readonly IUserRepository _repository;
    private readonly IUserDomainService _userDomainService;

    public CreateUserCommandHandler(IUserRepository repository, IUserDomainService userService)
    {
        _repository = repository;
        _userDomainService = userService;
    }

    public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var password = Sha256Hasher.Hash(request.Password);
        var user = new User(request.Name, request.Family, request.PhoneNumber, password, request.Email, request.Gender,
            _userDomainService);

        _repository.Add(user);
        await _repository.Save();
        return OperationResult.Success();
    }
}