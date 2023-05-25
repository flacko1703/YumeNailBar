using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureEmptyPriceException : DomainExceptionBase
{
    public ProcedureEmptyPriceException() 
        : base("Procedure price cannot be empty")
    {
    }
}