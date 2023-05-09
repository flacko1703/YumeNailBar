using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions;

public class RegistrationTimingException : YumeNailBarDomainException
{
    public RegistrationTimingException(DateTime dateTime) 
        : base($"Registration is available at least three hours in advance. Current value: {dateTime}")
    {
    }
}