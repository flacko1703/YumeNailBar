using YumeNailBar.Domain.Abstractions;

namespace YumeNailBar.Domain.Exceptions.CustomerExceptions;

public class NullRegistrationIdExceptionBase : DomainExceptionBase
{
    public NullRegistrationIdExceptionBase() 
        : base("Registration Id cannot be null")
    {
    }
}