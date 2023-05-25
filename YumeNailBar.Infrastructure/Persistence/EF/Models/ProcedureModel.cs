using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

namespace YumeNailBar.Infrastructure.Persistence.EF.Models;

public class ProcedureModel
{
    public ProcedureKind ProcedureKind { get; set; }
    public int Price { get; set; }
}