using FluentResults;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.Services;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

namespace YumeNailBar.Application.Registration.Queries.GetClientByRegistrationId;

public class GetCustomerByPhoneNumberQueryHandler : IQueryHandler<GetCustomerByPhoneNumberQuery, Customer>
{
    private readonly IRegistrationSearchService _searchService;

    public GetCustomerByPhoneNumberQueryHandler(IRegistrationSearchService searchService)
    {
        _searchService = searchService;
    }


    public async Task<Result<Customer>> Handle(GetCustomerByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var client = await _searchService.SearchByPhoneNumber(request.PhoneNumber);

        return Result.Ok(client);

    }
}