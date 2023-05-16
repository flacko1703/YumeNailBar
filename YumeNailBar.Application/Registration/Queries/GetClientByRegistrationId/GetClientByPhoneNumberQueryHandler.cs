using FluentResults;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.Services;
using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;

namespace YumeNailBar.Application.Registration.Queries.GetClientByRegistrationId;

public class GetClientByPhoneNumberQueryHandler : IQueryHandler<GetClientByPhoneNumberQuery, Client>
{
    private readonly IRegistrationSearchService _searchService;

    public GetClientByPhoneNumberQueryHandler(IRegistrationSearchService searchService)
    {
        _searchService = searchService;
    }


    public async Task<Result<Client>> Handle(GetClientByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var client = await _searchService.SearchByPhoneNumber(request.PhoneNumber);

        return Result.Ok(client);

    }
}