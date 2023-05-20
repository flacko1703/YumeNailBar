using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureEmptyPriceExceptionBase : DomainExceptionBase
{
    public ProcedureEmptyPriceExceptionBase() 
        : base("Procedure price cannot be empty")
    {
    }
}