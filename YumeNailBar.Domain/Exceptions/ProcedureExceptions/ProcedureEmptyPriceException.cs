using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureDomainEmptyPriceException : YumeNailBarDomainException
{
    public ProcedureDomainEmptyPriceException() 
        : base("Procedure price cannot be empty")
    {
    }
}