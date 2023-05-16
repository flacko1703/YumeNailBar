using FluentResults;
using MediatR;
using YumeNailBar.Application.DTO;

namespace YumeNailBar.Application.Registration.Commands.CreateRegistrationCommand;

public record CreateRegistrationCommand(Guid Id, ClientDto Client, DateTime AppointmentDate,
        bool IsCanceled) : IRequest<Result>;

