namespace YumeNailBar.Application.DTO;

public record CustomerDto(RegistrationDto Registration, string Name, string PhoneNumber, string? Email,
        string? Comment);

