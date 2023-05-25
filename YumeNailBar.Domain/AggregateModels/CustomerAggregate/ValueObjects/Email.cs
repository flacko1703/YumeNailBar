using FluentResults;
using YumeNailBar.Domain.Errors;

namespace YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

public record Email
{
    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            Result.Fail<Email>(new EmptyEmailError(nameof(EmptyEmailError)));
        }

        Value = value;
        Result.Ok(value);
    }
    
    public string Value { get; }
    
    public static implicit operator string(Email email) => email.Value;

    public static implicit operator Email(string email) => new(email);
}