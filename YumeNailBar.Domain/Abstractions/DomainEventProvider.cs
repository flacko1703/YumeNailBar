using MediatR;

namespace YumeNailBar.Domain.Abstractions;

public static class DomainEvent 
{
    private static IMediator _mediator;

    public static void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public static async Task RaiseAsync<T>(T eventToRaise) where T : INotification
    {
        if (_mediator == null)
            throw new InvalidOperationException("Mediator not set");

        await _mediator.Publish(eventToRaise);
    }
}