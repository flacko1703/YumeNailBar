using YumeNailBar.Application.Abstractions;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

namespace YumeNailBar.Application.Registration.Queries.GetClientByRegistrationId;

public record GetCustomerByPhoneNumberQuery(string PhoneNumber) : IQuery<Customer>;