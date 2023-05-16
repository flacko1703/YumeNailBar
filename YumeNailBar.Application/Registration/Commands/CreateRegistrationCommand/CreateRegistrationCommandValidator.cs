using FluentValidation;

namespace YumeNailBar.Application.Registration.Commands.CreateRegistrationCommand;

public class CreateRegistrationCommandValidator : AbstractValidator<CreateRegistrationCommand>
{
    public CreateRegistrationCommandValidator()
    {
        RuleFor(x => x.Client).NotNull();
        RuleFor(x => x.Client.PhoneNumber).NotEmpty();
        RuleFor(x => x.Client.ClientName).NotEmpty();
        RuleFor(x => x.AppointmentDate).NotNull();
    }
}