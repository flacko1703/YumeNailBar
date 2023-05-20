using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions;

public class RegistrationTimingExceptionBase : DomainExceptionBase
{
    public RegistrationTimingExceptionBase(DateTime dateTime) 
        : base($"Registration is available at least three hours in advance. Current value: {dateTime}")
    {
    }
}