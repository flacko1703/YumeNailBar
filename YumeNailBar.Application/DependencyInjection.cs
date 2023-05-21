using FluentResults;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.DTO;
using YumeNailBar.Application.Registrations.Commands.CancelRegistrationCommand;
using YumeNailBar.Application.Registrations.Commands.CreateRegistrationCommand;
using YumeNailBar.Application.Registrations.Queries.GetRegistrationById;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

namespace YumeNailBar.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<CancelRegistrationCommand, Result>, CancelRegistrationCommandHandler>();
        services.AddScoped<IRequestHandler<CreateRegistrationCommand, Result>, CreateRegistrationCommandHandler>();
        services.AddScoped<IRequestHandler<GetRegistrationByIdQuery, Result<RegistrationDto>>, GetRegistrationByIdQueryHandler>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>());
        return services;
    }
}