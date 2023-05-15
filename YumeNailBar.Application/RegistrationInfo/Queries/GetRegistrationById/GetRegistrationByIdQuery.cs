using FluentResults;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.DTO;

namespace YumeNailBar.Application.RegistrationInfo.Queries.GetRegistrationById;

public record GetRegistrationByIdQuery(Guid Id, ClientDto Client, DateTime AppointmentDate, bool IsCanceled) 
    : IQuery<RegistrationDto>;