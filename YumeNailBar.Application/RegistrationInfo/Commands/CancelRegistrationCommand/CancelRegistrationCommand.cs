using FluentResults;
using MediatR;
using YumeNailBar.Application.Abstractions;

namespace YumeNailBar.Application.RegistrationInfo.Commands.CancelRegistrationCommand;

public record CancelRegistrationCommand(Guid Id) : IRequest<Result>;


