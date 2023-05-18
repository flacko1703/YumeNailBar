using YumeNailBar.Application.Common.Mappings;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

namespace YumeNailBar.Application.DTO;

public record ClientDto
    (Guid Id, string ClientName, string PhoneNumber) 
    : IMapWith<Customer>;

