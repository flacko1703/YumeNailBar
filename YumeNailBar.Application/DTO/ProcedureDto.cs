using YumeNailBar.Application.Common.Mappings;
using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;

namespace YumeNailBar.Application.DTO;

public record ProcedureDto(ProcedureKind ProcedureKind, int Price) 
    : IMapWith<Procedure>;