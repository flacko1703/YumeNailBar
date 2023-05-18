using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

namespace YumeNailBar.Infrastructure.Persistence.EF.Models;

internal class RegistrationModel
{
    public Guid Id { get; set; }
    public CustomerId CustomerId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public IEnumerable<ProcedureModel> Procedures { get; set; }
    public string Comment { get; set; }
    public bool IsCanceled { get; set; }
}