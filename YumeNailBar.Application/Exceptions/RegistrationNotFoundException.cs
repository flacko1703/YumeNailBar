using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;

namespace YumeNailBar.Application.Exceptions;

public class RegistrationNotFoundException : YumeNailBarApplicationException
{
    public RegistrationNotFoundException(RegistrationId id) 
        : base($"Registration entity with id {id} not found.")
    {
    }
}