using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.UserAgg;

public class Wallet : BaseEntity
{
    public Wallet(string description, int amount, bool isFinally, DateTime? finallyDate, WalletType type)
    {
        if (amount < 500)
            throw new InvalidDomainDataException();
            
        
        Description = description;
        Amount = amount;
        IsFinally = isFinally;
        FinallyDate = finallyDate;
        Type = type;
    }

    public long UserId { get; internal set; }
    public int Amount { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public DateTime? FinallyDate { get; private set; }
    public WalletType Type { get; set; }

    public void Finally(string refCode)
    {
        IsFinally=true;
        FinallyDate=DateTime.Now;
        Description += $"کد پیگیری {refCode}";
    }
    public void Finally()
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
    }
}