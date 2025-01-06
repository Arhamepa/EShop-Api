using Common.Application;
using Common.Domain.ValueObjects;
using Shop.Application.Users.Register;

namespace Shop.Application.Users.Register;

public class RegisterUserCommand:IBaseCommand
{
    public RegisterUserCommand(string password, PhoneNumber phoneNumber)
    {
        Password = password;
        PhoneNumber = phoneNumber;
    }
    public string Password { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
}