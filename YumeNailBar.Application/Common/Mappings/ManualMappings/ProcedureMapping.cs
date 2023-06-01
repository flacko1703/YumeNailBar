using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

namespace YumeNailBar.Application.Common.Mappings.ManualMappings;

public static class ProcedureMapping
{
    public static ProcedureDto MapToDto(this Procedure procedure)
    {
        return new ProcedureDto(procedure.ProcedureKind, procedure.Price);
    }

    public static Procedure MapToModel(this ProcedureDto dto)
    {
        return Procedure.Create(dto.ProcedureKind, dto.Price);
    }

    public static IEnumerable<ProcedureDto> MapCollectionToDtos(this IEnumerable<Procedure> procedures)
    {
        return procedures.Select(procedure 
            => new ProcedureDto(procedure.ProcedureKind, procedure.Price)).ToList();
    }
    
    public static IEnumerable<Procedure> MapCollectionToModels(this IEnumerable<ProcedureDto> procedures)
    {
        return procedures.Select(procedure 
            => Procedure.Create(procedure.ProcedureKind, procedure.Price)).ToList();
    }

}