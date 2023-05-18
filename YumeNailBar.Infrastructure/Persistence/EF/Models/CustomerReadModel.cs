namespace YumeNailBar.Infrastructure.Persistence.EF.Models;

internal class CustomerReadModel
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<ProcedureReadModel> Procedures { get; set; }
    public string Comment { get; set; }

    public static CustomerReadModel Create(string value)
    {
        var splitClientString = value.Split(',');
        return new CustomerReadModel()
        {
            CustomerName = splitClientString.First(),
            PhoneNumber = splitClientString.Last()
        };
    }

    public override string ToString()
    {
        return $"{CustomerName}, {PhoneNumber}";
    }
}

