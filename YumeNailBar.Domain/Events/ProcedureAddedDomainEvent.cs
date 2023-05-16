using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;
using YumeNailBar.Domain.SeedWork.Abstractions;

namespace YumeNailBar.Domain.Events;

public record ProcedureAddedDomainEvent(Registration Registration, Procedure Procedure) : IDomainEvent;