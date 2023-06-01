using FluentResults;
using MediatR;
using YumeNailBar.Application.Common.Mappings.ManualMappings;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.Customers.Queries.GetAllCustomers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = _customerRepository.GetAllCustomers().Value;

        if (customers is not null && customers.Any())
        {
            return customers.ToList();
        }

        return customers;
    }
}