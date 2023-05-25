using YumeNailBar.Application.Common.Mappings;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

namespace YumeNailBar.Application.DTO;

public record ProcedureDto(ProcedureKind ProcedureKind, int Price)
    : IMapWith<Procedure>
{
    public Procedure ToDomainModel()
    {
        return Procedure.Create(ProcedureKind, Price);
    }
}