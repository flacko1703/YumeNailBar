using FluentResults;
using MediatR;

namespace YumeNailBar.Application.Customers.Commands.CancelRegistrationCommand;

public record CancelRegistrationCommand(Guid Id) : IRequest<Result>;


