using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.CustomerExceptions;

public class EmptyCustomerDomainIdException : YumeNailBarDomainException
{
    public EmptyCustomerDomainIdException() 
        : base("Customer Id cannot be empty")
    {
    }
}