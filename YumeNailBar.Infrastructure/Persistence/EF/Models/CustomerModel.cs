namespace YumeNailBar.Infrastructure.Persistence.EF.Models;

internal sealed class CustomerModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Comment { get; set; }
    
    public RegistrationModel RegistrationModel { get; set; }
}