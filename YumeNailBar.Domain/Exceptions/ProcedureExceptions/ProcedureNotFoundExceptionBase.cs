using YumeNailBar.Domain.Abstractions;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureNotFoundExceptionBase : DomainExceptionBase
{
    public ProcedureNotFoundExceptionBase(ProcedureKind procedureKind) 
        : base($"Procedure {procedureKind} not found")
    {
    }
}