using YumeNailBar.Application.Common.Mappings;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

namespace YumeNailBar.Application.DTO;

public record RegistrationDto(Guid Id, CustomerDto Customer, DateTime AppointmentDate, 
        IEnumerable<ProcedureDto> Procedures, string? Comment, bool IsCanceled) 
            : IMapWith<Domain.AggregateModels.RegistrationAggregate.Registration>;