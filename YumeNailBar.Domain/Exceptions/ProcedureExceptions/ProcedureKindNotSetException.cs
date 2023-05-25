using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureKindNotSetException : DomainExceptionBase
{
    public ProcedureKindNotSetException() 
        : base("Procedure kind must be set")
    {
    }
}