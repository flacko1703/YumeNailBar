using YumeNailBar.Domain.AggregateModels.RegistrationAggregate;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

namespace YumeNailBar.Domain.Factories;

public class RegistrationFactory : IRegistrationFactory
{
    public Registration Create(RegistrationId id, 
        CustomerId customerId, 
        AppointmentDate appointmentDate,
        IEnumerable<Procedure> procedures,
        string? comment, 
        bool isCanceled = false) 
        => new(id, customerId, appointmentDate, comment, isCanceled);
}