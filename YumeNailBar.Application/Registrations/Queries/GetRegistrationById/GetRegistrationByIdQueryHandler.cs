using FluentResults;
using MediatR;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.Registrations.Queries.GetRegistrationById;

public class GetRegistrationByIdQueryHandler : IRequestHandler<GetRegistrationByIdQuery, Result<RegistrationDto>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetRegistrationByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<RegistrationDto>> Handle(GetRegistrationByIdQuery request, CancellationToken cancellationToken)
    {
        var registration = await _customerRepository.GetAsync(request.Id);

        if (registration is null)
        {
            return Result.Fail<RegistrationDto>(new Error($"Registraton with {request.Id} was not found"));
        }
        

        return Result.Ok();
    }
}