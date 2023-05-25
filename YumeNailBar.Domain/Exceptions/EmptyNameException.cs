using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions;

public class EmptyNameException : DomainExceptionBase
{
    public EmptyNameException() 
        : base("Name cannot be empty")
    {
    }
}