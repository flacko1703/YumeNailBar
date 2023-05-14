using FluentResults;
using YumeNailBar.Application.Abstractions;

namespace YumeNailBar.Application.RegistrationInfo.Queries.GetRegistrationById;

public record GetRegistrationByIdQuery(Guid Id) : IQuery<RegistrationResponse>;