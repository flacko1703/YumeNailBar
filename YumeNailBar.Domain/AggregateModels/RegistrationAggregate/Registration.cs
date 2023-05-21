using System.Collections.ObjectModel;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;
using YumeNailBar.Domain.Events;
using YumeNailBar.Domain.Exceptions.ProcedureExceptions;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.AggregateModels.RegistrationAggregate;

public record Registration : AggregateRoot<RegistrationId>
{
    private CustomerId _customerId;
    private AppointmentDate _appointmentDate;
    private readonly List<Procedure> _procedures = new();
    private bool _isCanceled;

    private Registration(RegistrationId id, 
        CustomerId customerId, IEnumerable<Procedure> procedures,
        AppointmentDate appointmentDate, bool isCanceled = false)
    {
        Id = id;
        _customerId = customerId;
        _appointmentDate = appointmentDate;
        _isCanceled = isCanceled;
    }
    
    private Registration()
    {
        //For Entity Framework
    }
    
    public RegistrationId Id { get; init; }
    public IReadOnlyList<Procedure> Procedures => _procedures.AsReadOnly();

    public static Registration Create( 
        CustomerId customerId, 
        IEnumerable<Procedure> procedures,
        AppointmentDate appointmentDate, 
        bool isCanceled = false)
    {
        return new Registration(Guid.NewGuid(), customerId, procedures, appointmentDate, isCanceled);
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

    public CustomerId GetCustomerId()
    {
        return _customerId;
    }
    public bool GetStatus()
    {
        return _isCanceled;
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