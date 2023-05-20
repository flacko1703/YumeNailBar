using FluentResults;
using MediatR;

namespace YumeNailBar.Application.RegistrationUseCases.Commands.CancelRegistrationCommand;

public record CancelRegistrationCommand(Guid Id) : IRequest<Result>;


