using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

public class Procedure : IEntity<ProcedureId>
{
    private ProcedureId _procedureId;
    private ProcedureKind _procedureKind;
    private int _price;

    private Procedure(ProcedureId procedureId, ProcedureKind procedureKind, int price)
    {
        _procedureId = procedureId;
        _procedureKind = procedureKind;
        _price = price;
    }

    private Procedure()
    {
        //For Entity Framework
    }
    
    public ProcedureId Id { get; init; }

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
