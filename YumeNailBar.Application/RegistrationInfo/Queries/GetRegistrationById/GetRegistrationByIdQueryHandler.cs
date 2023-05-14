using FluentResults;
using MediatR;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.RegistrationInfo.Queries.GetRegistrationById;

public class GetRegistrationByIdQueryHandler : IRequestHandler<GetRegistrationByIdQuery, Result<RegistrationResponse>>
{
    private readonly IRegistrationRepository _registrationRepository;

    public GetRegistrationByIdQueryHandler(IRegistrationRepository registrationRepository)
    {
        _registrationRepository = registrationRepository;
    }

    public async Task<Result<RegistrationResponse>> Handle(GetRegistrationByIdQuery request, CancellationToken cancellationToken)
    {
        var registration = await _registrationRepository.GetAsync(request.Id);

        if (registration is null)
        {
            return Result.Fail<RegistrationResponse>(new Error($"Registraton with {request.Id} was not found"));
        }

        var response = new RegistrationResponse(request.Id);

        return response;
    }
}