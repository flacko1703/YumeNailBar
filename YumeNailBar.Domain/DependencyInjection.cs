using Microsoft.Extensions.DependencyInjection;

namespace YumeNailBar.Domain;

public static class DependencyInjection
{
    
    public static IServiceCollection AddDomainLayer(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DomainAssemblyReference>());
        return services;
    }
}