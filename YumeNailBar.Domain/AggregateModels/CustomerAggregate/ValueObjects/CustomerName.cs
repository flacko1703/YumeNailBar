﻿using YumeNailBar.Domain.Exceptions;

namespace YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

public record CustomerName
{
    public string Value { get; }

    public CustomerName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyNameException();
        }

        Value = value;
    }
    
    public static implicit operator string(CustomerName name) => name.Value;

    public static implicit operator CustomerName(string name) => new(name);
}