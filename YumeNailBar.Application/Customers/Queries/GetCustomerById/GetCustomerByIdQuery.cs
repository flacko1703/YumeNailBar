using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.DTO;

namespace YumeNailBar.Application.Customers.Queries.GetRegistrationById;

public record GetCustomerByIdQuery(Guid Id) 
    : IQuery<RegistrationDto>;