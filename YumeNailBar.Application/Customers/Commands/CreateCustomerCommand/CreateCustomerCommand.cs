using FluentResults;
using MediatR;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

namespace YumeNailBar.Application.Customers.Commands.CreateCustomerCommand;

public record CreateCustomerCommand(IEnumerable<Registration> Registrations, string Name, string PhoneNumber, string? Email, string? Comment)
    : IRequest<Result<Customer>>;

