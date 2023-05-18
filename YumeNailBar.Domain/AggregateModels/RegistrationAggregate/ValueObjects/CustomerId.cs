using YumeNailBar.Domain.Exceptions.CustomerExceptions;

namespace YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

public record CustomerId
{
    public CustomerId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new NullCustomerIdExceptionBase();
        }
        
        Value = value;
    }
    
    public Guid Value { get; init; }
    
    public static implicit operator Guid(CustomerId id) => id.Value;

    public static implicit operator CustomerId(Guid id) => new(id);
}