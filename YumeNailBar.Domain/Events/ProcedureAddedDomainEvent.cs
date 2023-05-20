using YumeNailBar.Domain.AggregateModels.RegistrationAggregate;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Events;

public record ProcedureAddedDomainEvent(Registration Registration, Procedure Procedure) : IDomainEvent;