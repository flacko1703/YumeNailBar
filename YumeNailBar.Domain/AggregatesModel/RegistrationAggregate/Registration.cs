using YumeNailBar.Domain.Events;
using YumeNailBar.Domain.Exceptions.ProcedureExceptions;
using YumeNailBar.Domain.SeedWork.Abstractions;
using YumeNailBar.Domain.SeedWork.ValueObjects;

namespace YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;

public record Registration : AggregateRoot<RegistrationId>
{
    private Client _client;
    private AppointmentDate _appointmentDate;
    private string? _comment;
    private bool _isCanceled;

    internal Registration(RegistrationId id, Client client, AppointmentDate appointmentDate, bool isCanceled = false)
    {
        Id = id;
        _client = client;
        _appointmentDate = appointmentDate;
        _isCanceled = isCanceled;
    }
    public RegistrationId Id { get; init; }

    public static Registration CreateInstance(RegistrationId id, Client client, AppointmentDate appointmentDate, bool isCanceled = false)
    {
        return new Registration(id, client, appointmentDate, isCanceled);
    }

    public Registration()
    {
        
    }


    public IEnumerable<Procedure> AddAllProcedures(Client client, IEnumerable<Procedure> procedures)
    {
        var proceduresList = procedures.ToList();

        for (var index = 0; index < proceduresList.Count; index++)
        {
            var procedure = proceduresList[index];
            AddProcedure(client, procedure);
        }

        return proceduresList;
    }

    
    public IEnumerable<Procedure>? AddProcedure(Client client, Procedure procedure)
    {
        var procedures = client.GetProcedures();
        if (procedures != null && procedures.Any(x => x == procedure))
        {
            throw new ProcedureAlreadyExistsException(procedure);
        }

        procedures?.AddLast(procedure);
        AddEvent(new ProcedureAddedDomainEvent(this, procedure));

        return procedures;
    }

   
    private Procedure GetProcedure(Client client, Procedure procedure)
    {
        var procedures = client.GetProcedures();
        var foundedProcedure = procedures.FirstOrDefault(p => p.ProcedureKind == procedure.ProcedureKind);
        if (foundedProcedure is null)
        {
            throw new ProcedureNotFoundException(procedure.ProcedureKind);
        }

        return procedure;
    }

    public IEnumerable<Procedure>? GetAllProcedures(Client client)
    {
        return client.GetProcedures();
    }

    public Client GetClient()
    {
        return _client;
    }



}