using FluentResults;
using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.Services;

public class RegistrationSearchService : IRegistrationSearchService
{
    private readonly IClientRepository _clientRepository;

    public RegistrationSearchService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }


    public async Task<Client>? SearchByPhoneNumber(PhoneNumber phoneNumber)
    {
        var client = await _clientRepository.GetAsync(phoneNumber);

        if (client is null)
        {
            Result.Fail(new Error($"Client with phone number {phoneNumber} not exists"));
            return null;
        }

        return client;
    }
}