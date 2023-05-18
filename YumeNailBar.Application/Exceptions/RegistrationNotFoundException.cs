using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

namespace YumeNailBar.Application.Exceptions;

internal class RegistrationNotFoundExceptionBase : ApplicationExceptionBase
{
    public RegistrationNotFoundExceptionBase(RegistrationId id) 
        : base($"Registration entity with id {id} not found.")
    {
    }
}