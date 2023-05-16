using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;

namespace YumeNailBar.Infrastructure.EF.Models;

internal class ProcedureReadModel
{
    public ProcedureKind ProcedureKind { get; set; }
    public int Price { get; set; }
    
    public ClientReadModel Client { get; set; }
}