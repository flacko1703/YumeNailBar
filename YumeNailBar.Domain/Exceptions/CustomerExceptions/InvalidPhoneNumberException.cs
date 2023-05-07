using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.CustomerExceptions;

public class InvalidPhoneNumberDomainException : CustomerDomainExceptionBase
{
    public InvalidPhoneNumberDomainException() 
        : base("Phone Number is invalid")
    {
    }
}