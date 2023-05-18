using FluentResults;

namespace YumeNailBar.Domain.Errors;

public class EmptyEmailError : IError
{
    public EmptyEmailError(string message)
    {
        Message = message;
    }

    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }
}