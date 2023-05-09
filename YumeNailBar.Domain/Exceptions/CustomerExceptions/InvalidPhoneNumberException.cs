using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.CustomerExceptions;

public class InvalidPhoneNumberException : YumeNailBarDomainException
{
    public InvalidPhoneNumberException() 
        : base("Phone Number is invalid")
    {
    }
}