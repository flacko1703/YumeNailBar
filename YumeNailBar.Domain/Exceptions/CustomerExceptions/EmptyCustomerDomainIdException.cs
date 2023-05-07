using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.CustomerExceptions;

public class EmptyCustomerDomainIdException : CustomerDomainExceptionBase
{
    public EmptyCustomerDomainIdException() 
        : base("Customer Id cannot be empty")
    {
    }
}