using Common.Application;
using Shop.Domain.UserAgg;

namespace Shop.Application.Users.ChargeWallet;

public class ChargeUserWalletCommand : IBaseCommand
{
    public ChargeUserWalletCommand(long userId, long amount, string description, bool isFinally, WalletType type)
    {
        UserId = userId;
        Amount = amount;
        Description = description;
        IsFinally = isFinally;
        Type = type;
    }
    public long UserId { get; private set; }
    public long Amount { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public WalletType Type { get; private set; }
}