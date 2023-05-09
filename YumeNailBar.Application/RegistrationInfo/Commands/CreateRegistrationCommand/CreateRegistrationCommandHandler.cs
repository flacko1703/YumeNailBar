using MediatR;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.Exceptions;
using YumeNailBar.Application.Services;
using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;
using YumeNailBar.Domain.Factories;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.RegistrationInfo.Commands.CreateRegistrationCommand;

public class CreateRegistrationCommandHandler : IRequestHandler<CreateRegistrationCommand>
{
    private readonly IRegistrationRepository _registrationRepository;
    private readonly IRegistrationFactory _registrationFactory;
    private readonly IRegistrationSearchService _searchService;

    public CreateRegistrationCommandHandler(IRegistrationRepository registrationRepository,
        IRegistrationFactory registrationFactory, IRegistrationSearchService searchService)
    {
        _registrationRepository = registrationRepository;
        _registrationFactory = registrationFactory;
        _searchService = searchService;
    }
    
    public async Task Handle(CreateRegistrationCommand request, CancellationToken cancellationToken)
    {
        var (id, client, registrationDate, isCanceled) = request;
        
        var isExist = await _searchService.SearchByPhoneNumber(client.PhoneNumber);
        
        if (isExist)
        {
            throw new RegistrationAlreadyExists(client.PhoneNumber);
        }

        var newClient = Client.CreateInstance(client.ClientName, client.PhoneNumber, client.Procedures, client.Comment);

        var registration = _registrationFactory.Create(id, newClient, registrationDate, isCanceled);

        await _registrationRepository.AddAsync(registration);
    }
}