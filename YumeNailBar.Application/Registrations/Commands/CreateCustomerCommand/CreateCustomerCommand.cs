using FluentResults;
using MediatR;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

namespace YumeNailBar.Application.Registrations.Commands.CreateCustomerCommand;

public record CreateCustomerCommand(Registration Registration, string Name, string PhoneNumber, string? Email, string? Comment)
    : IRequest<Result>;

