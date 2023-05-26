using FluentResults;
using MediatR;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application.Customers.Queries.GetRegistrationById;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Result<RegistrationDto>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<RegistrationDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var registration = await _customerRepository.GetAsync(request.Id);

        if (registration is null)
        {
            return Result.Fail<RegistrationDto>(new Error($"Registraton with {request.Id} was not found"));
        }
        

        return Result.Ok();
    }
}