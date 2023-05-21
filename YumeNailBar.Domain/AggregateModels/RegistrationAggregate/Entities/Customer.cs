﻿using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

public class Customer : IEntity<CustomerId>
{
    private CustomerId _customerId;
    private CustomerName _customerName;
    private PhoneNumber _phoneNumber;
    private Email? _email;
    private string? _comment;

    private Customer(CustomerId customerId, CustomerName customerName, 
        PhoneNumber phoneNumber, Email? email, string comment)
    {
        _customerId = customerId;
        _customerName = customerName;
        _phoneNumber = phoneNumber;
        _email = email;
        _comment = comment;
    }

    private Customer()
    {
        //For Entity Framework
    }
    
    public CustomerId Id { get; init; }
    
    public static Customer Create(CustomerName name, PhoneNumber phoneNumber, Email? email, string? comment)
    {
        return new Customer()
        {
            Id = Guid.NewGuid(),
            _customerName = name,
            _phoneNumber = phoneNumber,
            _email = email,
            _comment = comment
        };
    }
}