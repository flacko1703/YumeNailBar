using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureNotFoundExceptionBase : DomainExceptionBase
{
    public ProcedureNotFoundExceptionBase(ProcedureKind procedureKind) 
        : base($"Procedure {procedureKind} not found")
    {
    }
}