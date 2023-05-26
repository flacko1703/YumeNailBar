using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

namespace YumeNailBar.Application.DTO;

public record ProcedureDto(ProcedureKind ProcedureKind, int Price);