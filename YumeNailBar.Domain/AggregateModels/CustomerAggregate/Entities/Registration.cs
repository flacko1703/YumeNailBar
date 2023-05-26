using System.Collections;
using System.Collections.ObjectModel;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using YumeNailBar.Domain.Exceptions.ProcedureExceptions;
using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

public record Registration : IEntity<RegistrationId>
{
    private AppointmentDate _appointmentDate;
    private readonly IEnumerable<Procedure> _procedures;
    private bool _isCanceled;

    private Registration(RegistrationId id, 
        IEnumerable<Procedure> procedures,
        AppointmentDate appointmentDate,  bool isCanceled = false)
    {
        Id = id;
        _procedures = procedures;
        _appointmentDate = appointmentDate;
        _isCanceled = isCanceled;
    }
    
    private Registration()
    {
        //For Entity Framework
    }
    
    public RegistrationId Id { get; init; }

    public IEnumerable<Procedure> Procedures => _procedures;

    public static Registration Create( 
        IEnumerable<Procedure> procedures,
        AppointmentDate appointmentDate, 
        bool isCanceled = false)
    {
        return new Registration(Guid.NewGuid(), procedures, appointmentDate, isCanceled);
    }

    public IEnumerable<Procedure>? AddProcedure(Procedure procedure)
    {
        var procedures = new List<Procedure>();
        
        if (Procedures.Any(x => x == procedure))
        {
            throw new ProcedureAlreadyExistsException(procedure);
        }
        
        procedures.Add(procedure);
        return procedures;
    }

   
    public bool GetStatus()
    {
        return _isCanceled;
    }

    public AppointmentDate GetAppointmentDate()
    {
        return _appointmentDate;
    }

    public IEnumerable<Procedure> GetProcedures()
    {
        return _procedures;
    }

}