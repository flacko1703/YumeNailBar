using FluentResults;
using MediatR;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.Registrations.Commands.CreateRegistrationCommand;

public class CreateRegistrationCommandHandler : IRequestHandler<CreateRegistrationCommand, Result>
{
    private readonly IRegistrationRepository _registrationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRegistrationCommandHandler(IRegistrationRepository registrationRepository,
        IUnitOfWork unitOfWork)
    {
        _registrationRepository = registrationRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(CreateRegistrationCommand request, CancellationToken cancellationToken)
    {
        //RegistrationDTO
        var (id, customer, 
            registrationDate, procedures,
            comment, isCanceled) = request;

        var proceduresList = new List<Procedure>();

        foreach (var procedure in procedures)
        {
            proceduresList.Add(Procedure.Create(procedure.ProcedureKind, procedure.Price));
        }

        var registration = Registration.Create(customer.Id, proceduresList,
            registrationDate,
            isCanceled);

        
        await _registrationRepository.AddAsync(registration);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}