using YumeNailBar.Application.Common.Mappings;
using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;

namespace YumeNailBar.Application.DTO;

public record ClientDto
    (string ClientName, string PhoneNumber, IEnumerable<ProcedureDto> Procedures, string Comment) 
    : IMapWith<Client>;

