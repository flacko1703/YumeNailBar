using MediatR;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.DTO;

namespace YumeNailBar.Application.Customers.Queries.GetCustomerById;

public record GetCustomerByIdQuery(Guid Id) 
    : IRequest<CustomerDto>;