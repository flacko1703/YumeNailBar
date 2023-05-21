using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.DTO;

namespace YumeNailBar.Application.Registrations.Queries.GetRegistrationById;

public record GetRegistrationByIdQuery(Guid Id) 
    : IQuery<RegistrationDto>;