using YumeNailBar.Domain.AggregateModels.CustomerAggregate;

namespace YumeNailBar.Infrastructure.Persistence.EF.Models;

public sealed class RegistrationModel
{
    public Guid Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public ICollection<ProcedureModel> Procedures { get; set; }
    public bool IsCanceled { get; set; }
}