using FluentResults;
using YumeNailBar.Domain.Errors;

namespace YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

public record ProcedureKindId
{
    public ProcedureKindId(int value)
    {
        if (value.ToResult().IsFailed)
        {
            //TODO:Заменить на Exception
            Result.Fail(new EmptyProcedureGuidError().Message);
        }
    }

    public int Value { get; }
    
    public static implicit operator int(ProcedureKindId id) => id.Value;

    public static implicit operator ProcedureKindId(int id) => new(id);
}