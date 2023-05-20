using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions;

public class DateCannotBeInPastExceptionBase : DomainExceptionBase
{
    public DateCannotBeInPastExceptionBase(DateTime dateTime) 
        : base($"Date cannot be in past. Current value: {dateTime}")
    {
    }
}