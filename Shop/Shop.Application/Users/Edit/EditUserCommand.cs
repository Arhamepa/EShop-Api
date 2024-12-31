using System.Drawing.Text;
using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Application.Users.Edit;

public class EditUserCommand:IBaseCommand
{
    public EditUserCommand(long userId, string name, string family, string phoneNumber,
        string password, string email, Gender gender, IFormFile? avatar)
    {
        UserId = userId;
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
        Avatar = avatar;
    }

    public long UserId { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string PhoneNumber { get; private set; }
    public IFormFile? Avatar { get; private set; }
    public string Email { get; private set; }
    public Gender Gender { get; set; }
}