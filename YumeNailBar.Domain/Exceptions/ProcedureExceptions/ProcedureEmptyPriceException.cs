using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureEmptyPriceException : YumeNailBarDomainException
{
    public ProcedureEmptyPriceException() 
        : base("Procedure price cannot be empty")
    {
    }
}