using YumeNailBar.Domain.Exceptions.CustomerExceptions;

namespace YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

public record CustomerId
{
    public CustomerId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new NullCustomerIdException();
        }
        
        Value = value;
    }
    
    public Guid Value { get; }
    
    public static implicit operator Guid(CustomerId id) => id.Value;

    public static implicit operator CustomerId(Guid id) => new(id);
}