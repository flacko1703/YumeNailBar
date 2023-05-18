using YumeNailBar.Domain.Abstractions;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

namespace YumeNailBar.Domain.Events;

public record ProcedureAddedDomainEvent(Registration Registration, Procedure Procedure) : IDomainEvent;