using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.CustomerExceptions;

public class NullRegistrationIdException : DomainExceptionBase
{
    public NullRegistrationIdException() 
        : base("Registration Id cannot be null")
    {
    }
}