using FluentResults;
using MediatR;
using YumeNailBar.Application.Exceptions;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.Registration.Commands.CancelRegistrationCommand;

public class CancelRegistrationCommandHandler : IRequestHandler<CancelRegistrationCommand, Result>
{
    private readonly IRegistrationRepository _repository;

    public CancelRegistrationCommandHandler(IRegistrationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(CancelRegistrationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(request.Id);

        if (entity is null)
        {
            throw new RegistrationNotFoundException(request.Id);
        }

        await _repository.DeleteAsync(entity);
        
        return Result.Ok();
    }
}