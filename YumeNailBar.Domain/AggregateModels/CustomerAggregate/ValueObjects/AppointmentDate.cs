using YumeNailBar.Domain.Exceptions;

namespace YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

public record AppointmentDate
{
    public AppointmentDate(DateTime value)
    {
        if (value < DateTime.UtcNow)
        {
            throw new DateCannotBeInPastException(value);
        }

        // if (value.Hour < DateTime.Now.Hour - 3)
        // {
        //     throw new RegistrationTimingException(value);
        // }

        Value = value;
    }
    public DateTime Value { get; }

    public override string ToString()
    {
        return this.Value.ToString("dd.MM.yyyy HH:mm");
    }

    public static implicit operator DateTime(AppointmentDate date) => date.Value;
    public static implicit operator AppointmentDate(DateTime date) => new(date);
    
    
}