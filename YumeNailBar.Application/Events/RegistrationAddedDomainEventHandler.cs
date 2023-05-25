using MediatR;
using YumeNailBar.Domain.Events;

namespace YumeNailBar.Application.Events;

public class RegistrationAddedDomainEventHandler : INotificationHandler<RegistrationAddedDomainEvent>
{
    public async Task Handle(RegistrationAddedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}