using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureKindNotSetException : YumeNailBarDomainException
{
    public ProcedureKindNotSetException() 
        : base("Procedure kind must be set")
    {
    }
}