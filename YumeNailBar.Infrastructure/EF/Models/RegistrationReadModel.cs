namespace YumeNailBar.Infrastructure.EF.Models;

internal class RegistrationReadModel
{
    public Guid Id { get; set; }
    public ClientReadModel Client { get; set; }
    public DateTime AppointmentDate { get; set; }
    public bool IsCanceled { get; set; }
}