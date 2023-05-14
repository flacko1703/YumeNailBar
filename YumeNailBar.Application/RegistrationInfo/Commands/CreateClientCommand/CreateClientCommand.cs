using FluentResults;
using MediatR;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;

namespace YumeNailBar.Application.RegistrationInfo.Commands.CreateClientCommand;

public record CreateClientCommand(string Name, PhoneNumber PhoneNumber) : IRequest<Result>;