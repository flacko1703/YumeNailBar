using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

namespace YumeNailBar.Application.Common.Mappings.Manual;

public static class ProcedureMap
{
    public static Procedure ToDomainModel(this ProcedureDto procedureDto)
    {
        return Procedure.Create(procedureDto.ProcedureKind, procedureDto.Price);
    }
    
    public static ProcedureDto ToDto(this Procedure procedure)
    {
        return new ProcedureDto(procedure.Id, procedure.ProcedureKind, procedure.Price);
    }
    
    
}