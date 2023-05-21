using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

namespace YumeNailBar.Infrastructure.Persistence.EF.Models;

public class ProcedureModel
{
    public Guid Id { get; set; }
    public ProcedureKind ProcedureKind { get; set; }
    public int Price { get; set; }
}