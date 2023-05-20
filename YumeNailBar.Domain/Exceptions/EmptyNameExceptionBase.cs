using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions;

public class EmptyNameExceptionBase : DomainExceptionBase
{
    public EmptyNameExceptionBase() 
        : base("Name cannot be empty")
    {
    }
}