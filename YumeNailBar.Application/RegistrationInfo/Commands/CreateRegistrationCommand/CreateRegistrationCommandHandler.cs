using FluentResults;
using MediatR;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.Services;
using YumeNailBar.Domain.Factories;
using YumeNailBar.Domain.Repositories;
using YumeNailBar.Domain.SeedWork.ValueObjects;

namespace YumeNailBar.Application.RegistrationInfo.Commands.CreateRegistrationCommand;

public class CreateRegistrationCommandHandler : IRequestHandler<CreateRegistrationCommand, Result>
{
    private readonly IRegistrationRepository _registrationRepository;
    private readonly IRegistrationFactory _registrationFactory;
    private readonly IRegistrationSearchService _searchService;
    private readonly IClientFactory _clientFactory;

    public CreateRegistrationCommandHandler(IRegistrationRepository registrationRepository,
        IRegistrationFactory registrationFactory, IRegistrationSearchService searchService, IClientFactory clientFactory)
    {
        _registrationRepository = registrationRepository;
        _registrationFactory = registrationFactory;
        _searchService = searchService;
        _clientFactory = clientFactory;
    }
    
    public async Task<Result> Handle(CreateRegistrationCommand request, CancellationToken cancellationToken)
    {
        var (id, client, registrationDate, isCanceled) = request;
        
        var searchResult = await _searchService.SearchByPhoneNumber(client.PhoneNumber);
        
        if (searchResult.ToResult().IsSuccess)
        {
            return Result.Fail(new Error($"Client with phone number {client.PhoneNumber} already exists"));
            //throw new RegistrationAlreadyExists(client.PhoneNumber);
        }

        var newClient = _clientFactory.Create(client.ClientName, client.PhoneNumber); 

        var registration = _registrationFactory.Create(id, newClient, registrationDate, isCanceled);

        await _registrationRepository.AddAsync(registration);

        return Result.Ok();
    }
}