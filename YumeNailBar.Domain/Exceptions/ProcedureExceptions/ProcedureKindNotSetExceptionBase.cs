using YumeNailBar.Domain.Abstractions;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureKindNotSetExceptionBase : DomainExceptionBase
{
    public ProcedureKindNotSetExceptionBase() 
        : base("Procedure kind must be set")
    {
    }
}