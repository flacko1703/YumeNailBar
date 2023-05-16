using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureNotFoundException : YumeNailBarDomainException
{
    public ProcedureNotFoundException(ProcedureKind procedureKind) 
        : base($"Procedure {procedureKind} not found")
    {
    }
}