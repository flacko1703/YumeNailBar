using FluentResults;
using MediatR;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;

namespace YumeNailBar.Application.Customers.Queries.GetAllCustomers;

public record GetAllCustomersQuery : IRequest<IEnumerable<Customer>>;