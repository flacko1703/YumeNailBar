using YumeNailBar.Domain.Events;
using YumeNailBar.Domain.Exceptions.ProcedureExceptions;
using YumeNailBar.Domain.SeedWork.Abstractions;
using YumeNailBar.Domain.SeedWork.ValueObjects;

namespace YumeNailBar.Domain.AggregatesModel.CustomerAggregate;

public record RegistrationInfo : AggregateRoot<RegistrationId>
{
    private Client _client;
    private RegistrationDate _registrationDate;
    private string? _comment;
    private bool _isCanceled;

    private RegistrationInfo(RegistrationId id, Client client, RegistrationDate registrationDate, bool isCanceled = false)
    {
        Id = id;
        _client = client;
        _registrationDate = registrationDate;
        _isCanceled = isCanceled;
    }
    public RegistrationId Id { get; init; }

    internal static RegistrationInfo CreateInstance(RegistrationId id, Client client, RegistrationDate registrationDate, bool isCanceled = false)
    {
        return new RegistrationInfo(id, client, registrationDate, isCanceled);
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
        AddEvent(new ProcedureAdded(this, procedure));

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



}