using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureNotFoundException : DomainExceptionBase
{
    public ProcedureNotFoundException() 
        : base($"Procedure not found")
    {
    }
}