using FluentResults;
using MediatR;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

namespace YumeNailBar.Application.RegistrationUseCases.Commands.CreateRegistrationCommand;

public record CreateRegistrationCommand(Guid Id, CustomerDto Customer, DateTime AppointmentDate, 
    IEnumerable<ProcedureDto> Procedures, string? Comment, bool IsCanceled) 
    : IRequest<Result>;

