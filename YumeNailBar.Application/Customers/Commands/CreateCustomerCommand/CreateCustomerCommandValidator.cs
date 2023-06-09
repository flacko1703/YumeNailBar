﻿using FluentValidation;

namespace YumeNailBar.Application.Customers.Commands.CreateCustomerCommand;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Registrations).NotNull();
        RuleFor(x => x.PhoneNumber).NotNull();
        RuleFor(x => x.Name).NotEmpty().NotNull();
    }
}