using YumeNailBar.Domain.Exceptions.CustomerExceptions;

namespace YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;

public record RegistrationId
{
    public Guid Value { get; init; }

    public RegistrationId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyCustomerDomainIdException();
        }
        Value = value;
    }
    
    public static implicit operator Guid(RegistrationId id) => id.Value;

    public static implicit operator RegistrationId(Guid id) => new(id);
}