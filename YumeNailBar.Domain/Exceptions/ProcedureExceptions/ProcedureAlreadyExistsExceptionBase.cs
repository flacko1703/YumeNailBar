using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureAlreadyExistsExceptionBase : DomainExceptionBase
{
    public ProcedureAlreadyExistsExceptionBase(Procedure procedure) 
        : base($"Procedure {procedure} already exists")
    {
        
    }
}