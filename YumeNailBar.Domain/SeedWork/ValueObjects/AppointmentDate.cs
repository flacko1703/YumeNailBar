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
    public DateTime Value;
}