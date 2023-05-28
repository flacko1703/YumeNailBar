using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

namespace YumeNailBar.Infrastructure.Persistence.EF.Models;

public sealed class CustomerModel
{
    public Guid Id { get; set; }
    public RegistrationModel Registration { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Comment { get; set; }
}