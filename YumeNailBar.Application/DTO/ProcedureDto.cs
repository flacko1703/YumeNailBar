using YumeNailBar.Application.Common.Mappings;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

namespace YumeNailBar.Application.DTO;

public record ProcedureDto(ProcedureKind ProcedureKind, int Price) 
    : IMapWith<Procedure>;