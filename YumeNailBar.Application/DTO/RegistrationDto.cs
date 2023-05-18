using YumeNailBar.Application.Common.Mappings;

namespace YumeNailBar.Application.DTO;

public record RegistrationDto(Guid Id, Guid ClientId, DateTime AppointmentDate, 
        IEnumerable<ProcedureDto> Procedures, string? Comment, bool IsCanceled) 
            : IMapWith<Domain.AggregateModels.RegistrationAggregate.Registration>;