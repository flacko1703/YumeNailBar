using FluentResults;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.Services;

public class RegistrationSearchService : IRegistrationSearchService
{
    private readonly ICustomerRepository _customerRepository;

    public RegistrationSearchService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }


    public async Task<Customer>? SearchByPhoneNumber(PhoneNumber phoneNumber)
    {
        var customer = await _customerRepository.GetAsync(phoneNumber);

        if (customer is null)
        {
            Result.Fail(new Error($"Customer with phone number {phoneNumber} not exists"));
            return null;
        }

        return customer;
    }
}