using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.CustomerExceptions;

internal class NullCustomerIdException : DomainExceptionBase
{
    internal NullCustomerIdException() 
        : base("Customer id can not be null")
    {
    }
}