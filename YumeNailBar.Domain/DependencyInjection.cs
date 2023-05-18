using Microsoft.Extensions.DependencyInjection;
using YumeNailBar.Domain.Factories;

namespace YumeNailBar.Domain;

public static class DependencyInjection
{
    
    public static IServiceCollection AddDomainLayer(this IServiceCollection services)
    {
        services.AddScoped<ICustomerFactory, CustomerFactory>();
        services.AddScoped<IRegistrationFactory, RegistrationFactory>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DomainAssemblyReference>());
        return services;
    }
}