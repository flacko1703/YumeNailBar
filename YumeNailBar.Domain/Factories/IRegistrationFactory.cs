using YumeNailBar.Domain.AggregateModels.RegistrationAggregate;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

namespace YumeNailBar.Domain.Factories;

public interface IRegistrationFactory
{
    Registration Create(RegistrationId id, 
        CustomerId customerId, 
        AppointmentDate appointmentDate, 
        CustomerName customerName,
        PhoneNumber phoneNumber,
        IEnumerable<Procedure> procedures,
        string? comment,
        bool isCanceled = false);
}