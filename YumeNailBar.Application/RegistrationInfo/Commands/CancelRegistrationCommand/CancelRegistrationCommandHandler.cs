using MediatR;
using Microsoft.EntityFrameworkCore;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.Exceptions;
using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.RegistrationInfo.Commands.CancelRegistrationCommand;

public class CancelRegistrationCommandHandler : IRequestHandler<CancelRegistrationCommand>
{
    private readonly IRegistrationRepository _repository;

    public CancelRegistrationCommandHandler(IRegistrationRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CancelRegistrationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(request.Id);

        if (entity is null)
        {
            throw new RegistrationNotFoundException(request.Id);
        }

        await _repository.DeleteAsync(entity);
    }
}