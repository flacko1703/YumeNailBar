using FluentResults;
using MediatR;
using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;

namespace YumeNailBar.Application.Registration.Commands.CreateClientCommand;

public record CreateClientCommand(string Name, PhoneNumber PhoneNumber) : IRequest<Result>;