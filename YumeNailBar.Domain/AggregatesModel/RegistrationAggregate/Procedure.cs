using YumeNailBar.Domain.Exceptions.ProcedureExceptions;

namespace YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;

public record Procedure
{
    public Procedure(ProcedureKind procedureKind, int price)
    {
        if (procedureKind.Equals(null))
        {
            throw new ProcedureKindNotSetException();
        }
        
        if (price.Equals(null))
        {
            throw new ProcedureEmptyPriceException();
        }

        Price = price;
    }
    
    public int Price { get; init; }
    
    public ProcedureKind ProcedureKind { get; init; }
}