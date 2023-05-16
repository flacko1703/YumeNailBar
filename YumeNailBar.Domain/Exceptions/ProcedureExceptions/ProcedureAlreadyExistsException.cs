using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.ProcedureExceptions;

public class ProcedureAlreadyExistsException : YumeNailBarDomainException
{
    public ProcedureAlreadyExistsException(Procedure procedure) 
        : base($"Procedure {procedure} already exists")
    {
        
    }
}