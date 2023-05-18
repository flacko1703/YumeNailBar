namespace YumeNailBar.Infrastructure.Persistence.EF.Models;

internal class RegistrationReadModel
{
    public Guid Id { get; set; }
    public CustomerReadModel Customer { get; set; }
    public DateTime AppointmentDate { get; set; }
    public bool IsCanceled { get; set; }
}