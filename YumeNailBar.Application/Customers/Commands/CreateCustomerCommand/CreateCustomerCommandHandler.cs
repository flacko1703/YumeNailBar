using AutoMapper;
using FluentResults;
using MediatR;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.Common.Mappings.Manual;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.Customers.Commands.CreateCustomerCommand;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository,
        IUnitOfWork unitOfWork, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<Result<CustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var registrationModel = request.Registration.ToDomainModel();
        var customer = Customer.Create(registrationModel, 
            new CustomerName(request.Name), 
            new PhoneNumber(request.PhoneNumber),
            new Email(request.Email), request.Comment);
        
        await _customerRepository.AddAsync(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(customer.ToDto());
    }
}