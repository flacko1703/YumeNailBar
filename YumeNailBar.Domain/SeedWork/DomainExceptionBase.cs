namespace YumeNailBar.Domain.SeedWork;

public abstract class DomainExceptionBase : Exception
{
    protected DomainExceptionBase(string message) : base(message)
    {
        
    }
}