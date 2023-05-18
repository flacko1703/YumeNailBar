namespace YumeNailBar.Application.Exceptions;

internal abstract class ApplicationExceptionBase : Exception
{
    protected ApplicationExceptionBase(string message) : base(message)
    {
        
    }
}