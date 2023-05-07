using YumeNailBar.Domain.Exceptions;

namespace YumeNailBar.Domain.SeedWork.ValueObjects;

public abstract record Name
{
    public string Value { get; }

    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyNameException();
        }

        Value = value;
    }
}