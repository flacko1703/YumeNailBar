using YumeNailBar.Application.Common.Mappings;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

namespace YumeNailBar.Application.DTO;

public record RegistrationDto(Guid Id, DateTime AppointmentDate,
        IEnumerable<ProcedureDto> Procedures, bool IsCanceled)
    : IMapWith<Registration>
{
    public Registration ToDomainModel()
    {
        var procedureList = Procedures.Select(procedure => procedure.ToDomainModel()).ToList();
        return Registration.Create(procedureList, AppointmentDate, IsCanceled);
    }
}