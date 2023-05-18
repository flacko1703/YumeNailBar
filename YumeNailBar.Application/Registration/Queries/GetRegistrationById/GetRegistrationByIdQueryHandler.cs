using FluentResults;
using MediatR;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.Factories;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.Registration.Queries.GetRegistrationById;

public class GetRegistrationByIdQueryHandler : IRequestHandler<GetRegistrationByIdQuery, Result<RegistrationDto>>
{
    private readonly IRegistrationRepository _registrationRepository;
    private readonly IRegistrationFactory _registrationFactory;

    public GetRegistrationByIdQueryHandler(IRegistrationRepository registrationRepository, IRegistrationFactory registrationFactory)
    {
        _registrationRepository = registrationRepository;
        _registrationFactory = registrationFactory;
    }

    public async Task<Result<RegistrationDto>> Handle(GetRegistrationByIdQuery request, CancellationToken cancellationToken)
    {
        var registration = await _registrationRepository.GetAsync(request.Id);

        if (registration is null)
        {
            return Result.Fail<RegistrationDto>(new Error($"Registraton with {request.Id} was not found"));
        }

        return Result.Ok();
    }
}