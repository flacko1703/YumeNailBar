namespace YumeNailBar.Infrastructure.Persistence.EF.Models;

internal class CustomerModel
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }

    public static CustomerModel Create(string value)
    {
        var splitClientString = value.Split(',');
        return new CustomerModel()
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

