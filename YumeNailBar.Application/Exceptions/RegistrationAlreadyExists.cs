using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;

namespace YumeNailBar.Application.Exceptions;

public class RegistrationAlreadyExists : YumeNailBarApplicationException
{
    public RegistrationAlreadyExists(PhoneNumber phoneNumber) 
    : base($"Registration entity with phone number {phoneNumber} already exists.")
    {
    }
}