using AutoMapper;
using FluentResults;
using MediatR;
using YumeNailBar.Application.Common.Mappings.Manual;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetAsync(request.Id);

        if (customer is null)
        {
            return null;
        }


        return _mapper.Map<Customer, CustomerDto>(customer);
    }
}