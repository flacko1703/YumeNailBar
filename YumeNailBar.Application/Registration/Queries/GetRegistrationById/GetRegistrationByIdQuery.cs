using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.DTO;

namespace YumeNailBar.Application.Registration.Queries.GetRegistrationById;

public record GetRegistrationByIdQuery(Guid Id) 
    : IQuery<RegistrationDto>;