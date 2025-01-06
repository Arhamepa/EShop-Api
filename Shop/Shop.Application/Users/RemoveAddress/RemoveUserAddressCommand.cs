using Common.Application;

namespace Shop.Application.Users.RemoveAddress;

public record RemoveUserAddressCommand(long UserId, long AddressId) : IBaseCommand;