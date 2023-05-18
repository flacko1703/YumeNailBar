using FluentValidation;

namespace YumeNailBar.Application.Registration.Commands.CreateRegistrationCommand;

public class CreateRegistrationCommandValidator : AbstractValidator<CreateRegistrationCommand>
{
    public CreateRegistrationCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.CustomerId).NotNull();
        RuleFor(x => x.AppointmentDate).NotNull();
    }
}