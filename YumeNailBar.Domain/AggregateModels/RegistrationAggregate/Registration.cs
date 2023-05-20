using System.Collections.ObjectModel;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;
using YumeNailBar.Domain.Events;
using YumeNailBar.Domain.Exceptions.ProcedureExceptions;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.AggregateModels.RegistrationAggregate;

public record Registration : AggregateRoot<RegistrationId>
{
    private Customer _customer;
    private AppointmentDate _appointmentDate;
    private readonly HashSet<Procedure> _procedures = new();
    private string? _comment;
    private bool _isCanceled;

    private Registration(RegistrationId id, 
        Customer customer, IEnumerable<Procedure> procedures,
        AppointmentDate appointmentDate, string? comment, bool isCanceled = false)
    {
        Id = id;
        _customer = customer;
        _appointmentDate = appointmentDate;
        _comment = comment;
        _isCanceled = isCanceled;
    }
    
    private Registration()
    {
        //For Entity Framework
    }
    
    public RegistrationId Id { get; init; }
    public HashSet<Procedure> Procedures => _procedures;

    public static Registration Create( 
        Customer customer, 
        IEnumerable<Procedure> procedures,
        AppointmentDate appointmentDate, 
        string? comment,
        bool isCanceled = false)
    {
        return new Registration(Guid.NewGuid(), customer, procedures, appointmentDate, comment, isCanceled);
    }


    public IEnumerable<Procedure>? AddProcedure(Procedure procedure)
    {
        if (_procedures.Any(x => x == procedure))
        {
            throw new ProcedureAlreadyExistsExceptionBase(procedure);
        }

        _procedures.Add(procedure);
        
        AddEvent(new ProcedureAddedDomainEvent(this, procedure));

        return _procedures;
    }

    public Customer GetCustomer()
    {
        return _customer;
    }

    public bool GetStatus()
    {
        return _isCanceled;
    }

    public string? GetComment()
    {
        return _comment;
    }

    public AppointmentDate GetAppointmentDate()
    {
        return _appointmentDate;
    }

    public IEnumerable<Procedure>? GetProcedures()
    {
        return _procedures;
    }

}