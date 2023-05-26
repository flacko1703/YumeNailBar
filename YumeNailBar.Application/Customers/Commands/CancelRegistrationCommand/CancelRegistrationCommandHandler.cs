using FluentResults;
using MediatR;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.Exceptions;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.Customers.Commands.CancelRegistrationCommand;

public class CancelRegistrationCommandHandler : IRequestHandler<CancelRegistrationCommand, Result>
{
    private readonly ICustomerRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CancelRegistrationCommandHandler(ICustomerRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CancelRegistrationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(request.Id);

        if (entity is null)
        {
            throw new RegistrationNotFoundExceptionBase(request.Id);
        }

        await _repository.DeleteAsync(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Ok();
    }
}