using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions;

public class DateCannotBeInPastException : YumeNailBarDomainException
{
    public DateCannotBeInPastException(DateTime dateTime) 
        : base($"Date cannot be in past. Current value: {dateTime}")
    {
    }
}