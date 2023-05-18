namespace YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

public class Procedure
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