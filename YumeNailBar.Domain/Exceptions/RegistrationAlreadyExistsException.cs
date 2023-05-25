using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions;

public class RegistrationAlreadyExistsException : DomainExceptionBase
{
    public RegistrationAlreadyExistsException(RegistrationId registrationId) 
        : base($"Registration already exists: {registrationId}")
    {
    }
}