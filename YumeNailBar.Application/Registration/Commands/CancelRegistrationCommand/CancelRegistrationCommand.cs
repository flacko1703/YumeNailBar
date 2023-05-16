using FluentResults;
using MediatR;

namespace YumeNailBar.Application.Registration.Commands.CancelRegistrationCommand;

public record CancelRegistrationCommand(Guid Id) : IRequest<Result>;


