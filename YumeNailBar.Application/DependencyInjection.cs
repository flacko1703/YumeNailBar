using FluentResults;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.DTO;
using YumeNailBar.Application.Registrations.Commands.CancelRegistrationCommand;
using YumeNailBar.Application.Registrations.Commands.CreateCustomerCommand;
using YumeNailBar.Application.Registrations.Queries.GetRegistrationById;

namespace YumeNailBar.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<CancelRegistrationCommand, Result>, CancelRegistrationCommandHandler>();
        services.AddScoped<IRequestHandler<CreateCustomerCommand, Result>, CreateCustomerCommandHandler>();
        services.AddScoped<IRequestHandler<GetRegistrationByIdQuery, Result<RegistrationDto>>, GetRegistrationByIdQueryHandler>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>());
        return services;
    }
}