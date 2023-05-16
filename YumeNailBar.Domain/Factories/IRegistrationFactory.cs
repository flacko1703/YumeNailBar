using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;
using YumeNailBar.Domain.SeedWork.ValueObjects;

namespace YumeNailBar.Domain.Factories;

public interface IRegistrationFactory
{
    Registration Create(RegistrationId id, Client client, AppointmentDate appointmentDate,
        bool isCanceled = false);
}