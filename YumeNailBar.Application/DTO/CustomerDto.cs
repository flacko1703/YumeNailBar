namespace YumeNailBar.Application.DTO;

public record CustomerDto(IEnumerable<RegistrationDto> Registrations, string Name, string PhoneNumber, string? Email,
        string? Comment);

