using FluentValidation;

namespace YumeNailBar.Application.Registrations.Commands.CreateRegistrationCommand;

public class CreateRegistrationCommandValidator : AbstractValidator<CreateRegistrationCommand>
{
    public CreateRegistrationCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.AppointmentDate).NotNull();
    }
}