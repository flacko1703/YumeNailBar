using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

public record Procedure : IEntity<ProcedureId>
{
    private ProcedureId _procedureId;
    private ProcedureKind _procedureKind;
    private int _price;

    private Procedure(ProcedureId procedureId, ProcedureKind procedureKind, int price)
    {
        Id = procedureId;
        _procedureKind = procedureKind;
        _price = price;
    }

    private Procedure()
    {
        //For Entity Framework
    }
    
    public ProcedureId Id { get; init; }
    public ProcedureKind ProcedureKind => _procedureKind;
    public int Price => _price;

    public static Procedure Create(ProcedureKind procedureKind, int price)
    {
        return new Procedure()
        {
            Id = Guid.NewGuid(),
            _procedureKind = procedureKind,
            _price = price
        };
    }
}
