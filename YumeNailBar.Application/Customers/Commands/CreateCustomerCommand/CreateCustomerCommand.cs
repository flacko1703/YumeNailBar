using FluentResults;
using MediatR;
using YumeNailBar.Application.DTO;

namespace YumeNailBar.Application.Customers.Commands.CreateCustomerCommand;

public record CreateCustomerCommand(RegistrationDto Registration, string Name, string PhoneNumber, string? Email, string? Comment)
    : IRequest<Result<CustomerDto>>;

