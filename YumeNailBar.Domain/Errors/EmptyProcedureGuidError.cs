using FluentResults;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

namespace YumeNailBar.Domain.Errors;

public class EmptyProcedureGuidError : IError
{
    public string Message { get; } = "Procedure Guid can not be empty";
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }
}