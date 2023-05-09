using MediatR;
using YumeNailBar.Domain.Factories;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.RegistrationInfo.Commands.CreateClientCommand;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand>
{
    private readonly IClientFactory _clientFactory;
    private readonly IClientRepository _clientRepository;

    public CreateClientCommandHandler(IClientFactory clientFactory, IClientRepository clientRepository)
    {
        _clientFactory = clientFactory;
        _clientRepository = clientRepository;
    }

    public async Task Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.GetAsync(request.PhoneNumber);
        
        
    }
}