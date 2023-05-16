using YumeNailBar.Application.Common.Mappings;

namespace YumeNailBar.Application.DTO;

public record RegistrationDto(Guid Id, ClientDto Client, DateTime AppointmentDate, bool IsCanceled) 
    : IMapWith<Domain.AggregatesModel.RegistrationAggregate.Registration>;