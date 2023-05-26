namespace YumeNailBar.Application.DTO;

public record RegistrationDto(DateTime AppointmentDate,
        IEnumerable<ProcedureDto> Procedures, bool IsCanceled);