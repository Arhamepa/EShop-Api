namespace Common.Domain.Exceptions;

public class NationalCodeIsDuplicateException:BaseDomainException
{
    public NationalCodeIsDuplicateException():base("کد ملی متعلق به شخص دیگری است!")
    {
    }

    public NationalCodeIsDuplicateException(string message) : base(message)
    {
    }
        
}