using System.Collections.ObjectModel;
using FluentResults;
using MediatR;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.Registrations.Commands.CreateCustomerCommand;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository,
        IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        //RegistrationDTO
        var (registration, 
            name, phoneNumber, 
            email,
            comment) = request;


        var customer = Customer.Create(registration, name, phoneNumber, email, comment);
        await _customerRepository.AddAsync(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}