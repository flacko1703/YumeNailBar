using YumeNailBar.Domain.SeedWork.ValueObjects;

namespace YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;

public class Client
{
    private ClientName _clientName;
    private PhoneNumber _phoneNumber;
    private readonly LinkedList<Procedure>? _procedures = new();
    private string _comment;

    internal Client(ClientName clientName, PhoneNumber phoneNumber, LinkedList<Procedure> procedures, string comment)
    {
        _clientName = clientName;
        _phoneNumber = phoneNumber;
        _procedures = procedures;
        _comment = comment;
    }

    public Client()
    {
        
    }

    public static Client CreateInstance(string value)
    {
        var splitClientString = value.Split(',');
        return new Client()
        {
            _clientName = splitClientString.First(),
            _phoneNumber = splitClientString.Last()
        };
    }


    public LinkedList<Procedure> GetProcedures()
    {
        return _procedures;
    }

    public string GetPhoneNumber()
    {
        return _phoneNumber;
    }
    
    public override string ToString()
    {
        return $"{_clientName}, {_phoneNumber}";
    }
}