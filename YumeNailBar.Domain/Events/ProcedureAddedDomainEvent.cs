using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;
using YumeNailBar.Domain.SeedWork.Abstractions;

namespace YumeNailBar.Domain.Events;

public record ProcedureAdded(RegistrationInfo RegistrationInfo, Procedure Procedure) : IDomainEvent;