using YumeNailBar.Domain.Abstractions;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;
using YumeNailBar.Domain.Events;
using YumeNailBar.Domain.Exceptions.ProcedureExceptions;

namespace YumeNailBar.Domain.AggregateModels.RegistrationAggregate;

public record Registration : AggregateRoot<RegistrationId>
{
    private CustomerId _customerId;
    private AppointmentDate _appointmentDate;
    private readonly HashSet<Procedure> _procedures = new();
    private string? _comment;
    private bool _isCanceled;

    internal Registration(RegistrationId id, 
        CustomerId customerId, 
        AppointmentDate appointmentDate, string? comment, bool isCanceled = false)
    {
        Id = id;
        _customerId = customerId;
        _appointmentDate = appointmentDate;
        _comment = comment;
        _isCanceled = isCanceled;
    }
    
    public Registration()
    {
        //For Entity Framework
    }
    
    public RegistrationId Id { get; init; }

    public static Registration Create(RegistrationId id, 
        CustomerId customerId, 
        AppointmentDate appointmentDate, 
        string? comment,
        bool isCanceled = false)
    {
        return new Registration(id, customerId, appointmentDate, comment, isCanceled);
    }


    public IEnumerable<Procedure>? AddProcedure(CustomerId customerId, Procedure procedure)
    {
        if (_procedures.Any(x => x == procedure))
        {
            throw new ProcedureAlreadyExistsExceptionBase(procedure);
        }

        _procedures.Add(procedure);
        
        AddEvent(new ProcedureAddedDomainEvent(this, procedure));

        return _procedures;
    }

    public IEnumerable<Procedure>? GetProcedures()
    {
        return _procedures;
    }

}