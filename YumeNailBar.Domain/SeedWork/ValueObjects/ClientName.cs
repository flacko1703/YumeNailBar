using YumeNailBar.Domain.Exceptions;

namespace YumeNailBar.Domain.SeedWork.ValueObjects;

public record ClientName
{
    public string Value { get; private set; }

    public ClientName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyNameException();
        }

        Value = value;
    }
    
    public static implicit operator string(ClientName name) => name.Value;

    public static implicit operator ClientName(string name) => new(name);
}