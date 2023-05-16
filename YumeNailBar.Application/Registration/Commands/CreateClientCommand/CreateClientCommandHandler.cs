using FluentResults;
using MediatR;
using YumeNailBar.Application.Services;
using YumeNailBar.Domain.Factories;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.Registration.Commands.CreateClientCommand;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Result>
{
    private readonly IClientFactory _clientFactory;
    private readonly IRegistrationSearchService _searchService;

    public CreateClientCommandHandler(IClientFactory clientFactory, IRegistrationSearchService searchService)
    {
        _clientFactory = clientFactory;
        _searchService = searchService;
    }

    public async Task<Result> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _searchService.SearchByPhoneNumber(request.PhoneNumber);
        
        return Result.Ok();
    }
}