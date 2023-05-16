using YumeNailBar.Application.Abstractions;
using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;

namespace YumeNailBar.Application.Registration.Queries.GetClientByRegistrationId;

public record GetClientByPhoneNumberQuery(string PhoneNumber) : IQuery<Client>;