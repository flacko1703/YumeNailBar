using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

namespace YumeNailBar.Infrastructure.Persistence.EF.Models;

internal class ProcedureReadModel
{
    public ProcedureKind ProcedureKind { get; set; }
    public int Price { get; set; }
    public CustomerReadModel Customer { get; set; }
}