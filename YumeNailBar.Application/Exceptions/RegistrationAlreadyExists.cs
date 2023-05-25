using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

namespace YumeNailBar.Application.Exceptions;

internal class RegistrationAlreadyExists : ApplicationExceptionBase
{
    public RegistrationAlreadyExists(PhoneNumber phoneNumber) 
    : base($"Registration entity with phone number {phoneNumber} already exists.")
    {
    }
}