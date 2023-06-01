using FluentResults;
using MediatR;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.Common.Mappings.ManualMappings;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.Customers.Commands.CreateCustomerCommand;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<Customer>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository,
        IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var requestRegistrations = request.Registrations;
                
        var customer = Customer.Create(requestRegistrations, 
            new CustomerName(request.Name), 
            new PhoneNumber(request.PhoneNumber),
            new Email(request.Email), request.Comment);
        
        
        
        await _customerRepository.AddAsync(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(customer);
    }
}