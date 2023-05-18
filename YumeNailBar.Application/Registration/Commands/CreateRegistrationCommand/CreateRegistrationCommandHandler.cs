using FluentResults;
using MediatR;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.DTO;
using YumeNailBar.Application.Services;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.Factories;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.Registration.Commands.CreateRegistrationCommand;

public class CreateRegistrationCommandHandler : IRequestHandler<CreateRegistrationCommand, Result>
{
    private readonly IRegistrationRepository _registrationRepository;
    private readonly IRegistrationFactory _registrationFactory;
    private readonly ICustomerFactory _customerFactory;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRegistrationCommandHandler(IRegistrationRepository registrationRepository,
        IRegistrationFactory registrationFactory, ICustomerFactory customerFactory, 
        IUnitOfWork unitOfWork)
    {
        _registrationRepository = registrationRepository;
        _registrationFactory = registrationFactory;
        _customerFactory = customerFactory;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(CreateRegistrationCommand request, CancellationToken cancellationToken)
    {
        //RegistrationDTO
        var (id, customerId, 
            registrationDate, customerName, phoneNumber, procedureDtos,
            comment, isCanceled) = request;
        
        HashSet<Procedure> procedures = new HashSet<Procedure>();

        if (procedureDtos.Any())
        {
            foreach (var procedure in procedureDtos)
            {
                procedures.Add(Procedure.Create(procedure.ProcedureKind, procedure.Price));
            }
        }
        
        var registration = _registrationFactory.Create(id, customerId, 
            registrationDate, customerName, phoneNumber, 
            procedures, comment, isCanceled);

        
        await _registrationRepository.AddAsync(registration);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}