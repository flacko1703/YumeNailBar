using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureDomainKindNotSetException : YumeNailBarDomainException
{
    public ProcedureDomainKindNotSetException() 
        : base("Procedure Kind must be set")
    {
    }
}