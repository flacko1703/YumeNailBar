using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Events;

public record RegistrationAddedDomainEvent(CustomerId CustomerId, RegistrationId RegistrationId) : IDomainEvent;