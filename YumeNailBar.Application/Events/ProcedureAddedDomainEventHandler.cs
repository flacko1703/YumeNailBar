using MediatR;
using YumeNailBar.Domain.Events;

namespace YumeNailBar.Application.Events;

public sealed class ProcedureAddedDomainEventHandler : INotificationHandler<ProcedureAddedDomainEvent>
{
    public async Task Handle(ProcedureAddedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}