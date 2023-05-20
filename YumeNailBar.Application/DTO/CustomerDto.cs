using YumeNailBar.Application.Common.Mappings;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

namespace YumeNailBar.Application.DTO;

public record CustomerDto
    (Guid Id, string Name, string PhoneNumber) 
    : IMapWith<Customer>;

