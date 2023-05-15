using YumeNailBar.Application.Common.Mappings;
using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;

namespace YumeNailBar.Application.DTO;

public record RegistrationDto(Guid Id, ClientDto Client, DateTime AppointmentDate, bool IsCanceled) 
    : IMapWith<Registration>;