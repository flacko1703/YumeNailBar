using YumeNailBar.Domain.Exceptions;

namespace YumeNailBar.Domain.SeedWork.ValueObjects;

public record AppointmentDate
{
    public AppointmentDate(DateTime value)
    {
        if (value < DateTime.Now)
        {
            throw new DateCannotBeInPastException(value);
        }

        if (value.Hour < DateTime.Now.Hour - 3)
        {
            throw new RegistrationTimingException(value);
        }

        Value = value;
    }
    public DateTime Value { get; init; }

    public static implicit operator DateTime(AppointmentDate date) => date.Value;
    public static implicit operator AppointmentDate(DateTime date) => new(date);
    
    
}