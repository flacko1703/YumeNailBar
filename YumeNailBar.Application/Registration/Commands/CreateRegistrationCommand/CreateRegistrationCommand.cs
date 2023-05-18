using FluentResults;
using MediatR;
using YumeNailBar.Application.DTO;

namespace YumeNailBar.Application.Registration.Commands.CreateRegistrationCommand;

public record CreateRegistrationCommand(Guid Id, Guid CustomerId, DateTime AppointmentDate, 
    string CustomerName, string PhoneNumber,
    IEnumerable<ProcedureDto> Procedures, string? Comment, bool IsCanceled) 
    : IRequest<Result>;

