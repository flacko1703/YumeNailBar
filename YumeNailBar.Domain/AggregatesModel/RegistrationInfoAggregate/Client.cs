using YumeNailBar.Domain.SeedWork.ValueObjects;

namespace YumeNailBar.Domain.AggregatesModel.CustomerAggregate;

public class Client
{
    private ClientName _clientName;
    private PhoneNumber _phoneNumber;
    private readonly LinkedList<Procedure>? _procedures = new();
    private string _comment;

    private Client(ClientName clientName, PhoneNumber phoneNumber, LinkedList<Procedure> procedures, string comment)
    {
        _clientName = clientName;
        _phoneNumber = phoneNumber;
        _procedures = procedures;
        _comment = comment;
    }

    internal static Client CreateInstance(ClientName clientName, PhoneNumber phoneNumber,
        LinkedList<Procedure> procedures, string comment)
    {
        return new Client(clientName, phoneNumber, procedures, comment);
    }


    public LinkedList<Procedure> GetProcedures()
    {
        return _procedures;
    }
}