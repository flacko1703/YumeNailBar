using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Events;

public record ProcedureAddedDomainEvent(Registration Registration, Procedure Procedure) : IDomainEvent;