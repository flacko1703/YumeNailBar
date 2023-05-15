using YumeNailBar.Application.Common.Mappings;
using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;

namespace YumeNailBar.Application.DTO;

public record ClientDto
    (string ClientName, string PhoneNumber, IEnumerable<ProcedureDto> ProcedureDtos, string Comment) 
    : IMapWith<Client>;

