using FluentResults;
using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;
using MediatR;

namespace YumeNailBar.Application.Services;

public interface IRegistrationSearchService
{
    Task<Client>? SearchByPhoneNumber(PhoneNumber phoneNumber);
}