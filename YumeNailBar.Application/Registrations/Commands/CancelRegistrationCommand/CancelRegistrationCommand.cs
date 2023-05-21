using FluentResults;
using MediatR;

namespace YumeNailBar.Application.Registrations.Commands.CancelRegistrationCommand;

public record CancelRegistrationCommand(Guid Id) : IRequest<Result>;


