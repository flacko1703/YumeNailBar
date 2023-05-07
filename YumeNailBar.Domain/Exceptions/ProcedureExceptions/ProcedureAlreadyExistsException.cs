using YumeNailBar.Domain.AggregatesModel.ProcedureAggregate;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.AggregatesModel.CustomerAggregate;

public class ProcedureAlreadyExistsException : YumeNailBarDomainException
{
    public ProcedureAlreadyExistsException(Procedure procedure) 
        : base($"Procedure {procedure} already exists")
    {
        
    }
}