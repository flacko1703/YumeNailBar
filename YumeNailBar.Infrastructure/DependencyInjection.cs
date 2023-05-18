using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YumeNailBar.Domain.Repositories;
using YumeNailBar.Infrastructure.Persistence.Extensions;
using YumeNailBar.Infrastructure.Persistence.Repositories;

namespace YumeNailBar.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRegistrationRepository, RegistrationRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddPersistence(configuration);
        return services;
    }
}