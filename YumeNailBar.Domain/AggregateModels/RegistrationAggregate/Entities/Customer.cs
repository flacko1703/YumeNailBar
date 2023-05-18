using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

namespace YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

public class Customer
{
    private CustomerId _customerId;
    private CustomerName _customerName;
    private PhoneNumber _phoneNumber;
    private Email? _email;

    internal Customer(CustomerName customerName, 
        PhoneNumber phoneNumber, Email? email)
    {
        _customerName = customerName;
        _phoneNumber = phoneNumber;
        _email = email;
    }

    private Customer()
    {
        //For Entity Framework
    }

    public static Customer Create(string value)
    {
        var splitClientString = value.Split(',');
        return new Customer()
        {
            _customerName = splitClientString.First(),
            _phoneNumber = splitClientString.Last()
        };
    }

    public string GetPhoneNumber()
    {
        return _phoneNumber;
    }

    public string GetEmail()
    {
        return _email;
    }
    
    public override string ToString()
    {
        return $"{_customerName}, {_phoneNumber}";
    }
}