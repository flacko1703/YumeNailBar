using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.CustomerExceptions;

public class InvalidPhoneNumberExceptionBase : DomainExceptionBase
{
    public InvalidPhoneNumberExceptionBase(PhoneNumber phoneNumber) 
        : base($"Phone Number is invalid. Current value:{phoneNumber}")
    {
    }
}