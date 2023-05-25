using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions;

public class DateCannotBeInPastException : DomainExceptionBase
{
    public DateCannotBeInPastException(DateTime dateTime) 
        : base($"Date cannot be in past. Current value: {dateTime}")
    {
    }
}