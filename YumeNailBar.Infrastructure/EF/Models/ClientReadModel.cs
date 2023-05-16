namespace YumeNailBar.Infrastructure.EF.Models;

internal class ClientReadModel
{
    public Guid Id { get; set; }
    public string ClientName { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<ProcedureReadModel> Procedures { get; set; }
    public string Comment { get; set; }

    public static ClientReadModel Create(string value)
    {
        var splitClientString = value.Split(',');
        return new ClientReadModel()
        {
            ClientName = splitClientString.First(),
            PhoneNumber = splitClientString.Last()
        };
    }

    public override string ToString()
    {
        return $"{ClientName}, {PhoneNumber}";
    }
}

