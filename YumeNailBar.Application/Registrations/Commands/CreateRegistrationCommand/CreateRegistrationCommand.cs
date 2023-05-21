using FluentResults;
using MediatR;
using YumeNailBar.Application.DTO;

namespace YumeNailBar.Application.Registrations.Commands.CreateRegistrationCommand;

public record CreateRegistrationCommand(Guid Id, CustomerDto Customer, DateTime AppointmentDate, 
    IEnumerable<ProcedureDto> Procedures, string? Comment, bool IsCanceled) 
    : IRequest<Result>;

