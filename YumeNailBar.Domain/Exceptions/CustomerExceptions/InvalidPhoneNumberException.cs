using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.CustomerExceptions;

public class InvalidPhoneNumberException : DomainExceptionBase
{
    public InvalidPhoneNumberException(PhoneNumber phoneNumber) 
        : base($"Phone Number is invalid. Current value:{phoneNumber}")
    {
    }
}