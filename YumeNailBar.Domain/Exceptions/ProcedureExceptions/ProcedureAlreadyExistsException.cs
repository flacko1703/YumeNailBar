using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureAlreadyExistsException : DomainExceptionBase
{
    public ProcedureAlreadyExistsException(Procedure procedure) 
        : base($"Procedure {procedure} already exists")
    {
        
    }
}