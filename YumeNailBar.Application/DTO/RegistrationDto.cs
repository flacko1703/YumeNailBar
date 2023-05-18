using YumeNailBar.Application.Common.Mappings;

namespace YumeNailBar.Application.DTO;

public record RegistrationDto(Guid Id, Guid CustomerId, DateTime AppointmentDate, 
        string CustomerName, string PhoneNumber,
        IEnumerable<ProcedureDto> Procedures, string? Comment, bool IsCanceled) 
            : IMapWith<Domain.AggregateModels.RegistrationAggregate.Registration>;