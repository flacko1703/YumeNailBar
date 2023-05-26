using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

namespace YumeNailBar.Application.DTO;

public record ProcedureDto(Guid Id, ProcedureKind ProcedureKind, int Price);