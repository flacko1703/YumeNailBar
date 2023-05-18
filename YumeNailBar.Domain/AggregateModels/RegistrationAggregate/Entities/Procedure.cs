using YumeNailBar.Domain.Abstractions;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

namespace YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

public class Procedure : IEntity<ProcedureId>
{
    private ProcedureKind _procedureKind;
    private int _price;

    private Procedure(ProcedureKind procedureKind, int price)
    {
        _procedureKind = procedureKind;
        _price = price;
    }

    public Procedure()
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
            _procedureKind = procedureKind,
            _price = price
        };
    }
}

public enum ProcedureKind
{
    Manicure,
    Design,
    RemovingGel
}