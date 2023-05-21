namespace YumeNailBar.Infrastructure.Persistence.EF.Models;

internal sealed class RegistrationModel
{
    public Guid Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public ICollection<ProcedureModel> Procedures { get; set; }
    public bool IsCanceled { get; set; }
}