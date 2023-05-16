using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;
using YumeNailBar.Domain.SeedWork.ValueObjects;

namespace YumeNailBar.Domain.Factories;

public class RegistrationFactory : IRegistrationFactory
{
    public Registration Create(RegistrationId id, Client client, AppointmentDate appointmentDate,
        bool isCanceled = false) => new(id, client, appointmentDate, isCanceled);
}