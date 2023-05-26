using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

namespace YumeNailBar.Application.Common.Mappings.Manual;

public static class RegistrationMap
{
    public static Registration ToDomainModel(this RegistrationDto registrationDto)
    {
        var procedures = registrationDto.Procedures.Select(procedure => procedure.ToDomainModel()).ToList();

        var registration = Registration.Create(procedures, registrationDto.AppointmentDate,
            registrationDto.IsCanceled);

        return registration;
    }
    
    public static RegistrationDto ToDto(this Registration registration)
    {
        var dto = new RegistrationDto(registration.GetAppointmentDate(),
            registration.GetProcedures().Select(p => p.ToDto()),
            registration.GetStatus());
        return dto;
    }
}