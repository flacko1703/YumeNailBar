using FluentResults;
using MediatR;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.SeedWork.ValueObjects;

namespace YumeNailBar.Application.RegistrationInfo.Commands.CreateRegistrationCommand;

public record CreateRegistrationCommand(Guid Id, ClientDto Client, DateTime AppointmentDate,
        bool IsCanceled) : IRequest<Result>;

