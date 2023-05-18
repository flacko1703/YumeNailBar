namespace YumeNailBar.Domain.Abstractions;

public abstract class DomainExceptionBase : Exception
{
    protected DomainExceptionBase(string message) : base(message)
    {
        
    }
}