using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

namespace YumeNailBar.Application.Common.Mappings.ManualMappings;

public static class RegistrationMapping
{
    public static RegistrationDto MapToDto(this Registration registration)
    {
        return new RegistrationDto(registration.GetAppointmentDate(), 
            registration.GetProcedures().MapCollectionToDtos(),
            registration.GetStatus());
    }

    public static Registration MapToModel(this RegistrationDto dto)
    {
        return Registration.Create(dto.Procedures.MapCollectionToModels(),
            dto.AppointmentDate, dto.IsCanceled);
    }
    
    public static IEnumerable<RegistrationDto> MapCollectionToDtos(this IEnumerable<Registration> registrations)
    {
        return registrations.Select(registration 
            => new RegistrationDto(registration.GetAppointmentDate(), 
                registration.GetProcedures().MapCollectionToDtos(), 
                registration.GetStatus()))
            .ToList();
    }
    
    public static IEnumerable<Registration> MapCollectionToModels(this IEnumerable<RegistrationDto> registrations)
    {
        return registrations.Select(registrationDto 
            => Registration.Create(registrationDto.Procedures.MapCollectionToModels(), 
                registrationDto.AppointmentDate, 
                registrationDto.IsCanceled))
            .ToList();
    }
}