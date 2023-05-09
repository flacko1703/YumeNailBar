using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;

namespace YumeNailBar.Application.Exceptions;

public class RegistrationNotFoundException : YumeNailBarApplicationException
{
    public RegistrationNotFoundException(RegistrationId id) 
        : base($"Registration entity with id {id} not found.")
    {
    }
}