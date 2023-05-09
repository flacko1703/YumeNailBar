using YumeNailBar.Domain.Exceptions;

namespace YumeNailBar.Domain.SeedWork.ValueObjects;

public abstract record ClientName
{
    public string Value { get; }

    public ClientName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyNameException();
        }

        Value = value;
    }
}