using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

public record Procedure : IEntity<ProcedureId>
{
    private ProcedureKind _procedureKind;
    private int _price;

    private Procedure(ProcedureKind procedureKind, int price)
    {
        Id = Guid.NewGuid();
        _procedureKind = procedureKind;
        _price = price;
    }

    private Procedure()
    {
        //For Entity Framework
    }

    public ProcedureId Id { get; init; } = new ProcedureId(Guid.NewGuid());
    public ProcedureKind ProcedureKind => _procedureKind;
    public int Price => _price;

    public static Procedure Create(ProcedureKind procedureKind, int price)
    {
        var procedure = new Procedure(procedureKind, price);
        return procedure;
    }
}
