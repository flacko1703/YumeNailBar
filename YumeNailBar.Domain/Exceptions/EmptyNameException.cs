using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions;

public class EmptyNameException : YumeNailBarDomainException
{
    public EmptyNameException() 
        : base("Name cannot be empty")
    {
    }
}