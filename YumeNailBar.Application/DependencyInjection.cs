using System.Reflection;
using FluentResults;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.Services;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddSingleton<IRegistrationRepository>();
        services.AddSingleton<IClientRepository>();
        services.AddScoped<IRegistrationSearchService, RegistrationSearchService>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>());
        return services;
    }
}