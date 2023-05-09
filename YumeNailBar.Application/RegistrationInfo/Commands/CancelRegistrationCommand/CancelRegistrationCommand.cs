using MediatR;

namespace YumeNailBar.Application.RegistrationInfo.Commands.CancelRegistrationCommand;

public record CancelRegistrationCommand(Guid Id) : IRequest;


