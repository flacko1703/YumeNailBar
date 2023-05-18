using YumeNailBar.Domain.Abstractions;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureAlreadyExistsExceptionBase : DomainExceptionBase
{
    public ProcedureAlreadyExistsExceptionBase(Procedure procedure) 
        : base($"Procedure {procedure} already exists")
    {
        
    }
}