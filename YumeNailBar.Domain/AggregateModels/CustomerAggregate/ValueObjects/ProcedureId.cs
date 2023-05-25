using FluentResults;
using YumeNailBar.Domain.Errors;

namespace YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

public record ProcedureId
{
    public ProcedureId(Guid value)
    {
        if (value == Guid.Empty)
        {
            //TODO:Заменить на Exception
            Result.Fail(new EmptyProcedureGuidError().Message);
        }
    }

    public Guid Value { get; }
    
    public static implicit operator Guid(ProcedureId id) => id.Value;

    public static implicit operator ProcedureId(Guid id) => new(id);
}