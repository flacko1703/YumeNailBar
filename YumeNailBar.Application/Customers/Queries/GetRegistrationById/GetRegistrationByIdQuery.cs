using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.DTO;

namespace YumeNailBar.Application.Customers.Queries.GetRegistrationById;

public record GetRegistrationByIdQuery(Guid Id) 
    : IQuery<RegistrationDto>;