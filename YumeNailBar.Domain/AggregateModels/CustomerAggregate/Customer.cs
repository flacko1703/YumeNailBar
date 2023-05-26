using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using YumeNailBar.Domain.Events;
using YumeNailBar.Domain.Exceptions;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.AggregateModels.CustomerAggregate;

public record Customer : AggregateRoot<CustomerId>
{
    private Registration _registration;
    private CustomerName _customerName;
    private PhoneNumber _phoneNumber;
    private Email? _email;
    private string? _comment;
    private int _numberOfReceptions;

    private Customer(CustomerId customerId, Registration registration, CustomerName customerName, 
        PhoneNumber phoneNumber, Email? email, string comment, int numberOfReceptions)
    {
        Id = customerId;
        _registration = registration;
        _customerName = customerName;
        _phoneNumber = phoneNumber;
        _email = email;
        _comment = comment;
        _numberOfReceptions = numberOfReceptions;
    }

    private Customer()
    {
        //For Entity Framework
    }
    
    public CustomerId Id { get; init; }
    
    public static Customer Create(Registration registration, CustomerName name, PhoneNumber phoneNumber, Email? email, string? comment)
    {
        var id = new CustomerId(Guid.NewGuid());
        
        return new Customer()
        {
            Id = id,
            _registration = Registration.Create(
                    registration.Procedures.ToList(), 
                    registration.GetAppointmentDate(), 
                    registration.GetStatus()),
            _customerName = name,
            _phoneNumber = phoneNumber,
            _email = email,
            _comment = comment
        };
    }

    public void AddRegistration(Registration registration)
    {
        if (_registration == registration)
        {
            throw new RegistrationAlreadyExistsException(registration.Id);
        }

        _registration = registration;
        
        AddEvent(new RegistrationAddedDomainEvent(this.Id, registration.Id));
    }

    public Registration GetRegistration()
    {
        return _registration;
    }

    public CustomerName GetName()
    {
        return _customerName;
    }

    public Email GetEmail()
    {
        return _email;
    }

    public PhoneNumber GetPhoneNumber()
    {
        return _phoneNumber;
    }

    public string GetComment()
    {
        return _comment;
    }
}