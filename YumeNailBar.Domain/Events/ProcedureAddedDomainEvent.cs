using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;
using YumeNailBar.Domain.SeedWork.Abstractions;

namespace YumeNailBar.Domain.Events;

public record ProcedureAddedDomainEvent(Registration Registration, Procedure Procedure) : IDomainEvent;