using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YumeNailBar.Domain.Repositories;
using YumeNailBar.Infrastructure.Persistence.EF.Repositories;
using YumeNailBar.Infrastructure.Persistence.Extensions;

namespace YumeNailBar.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddPersistence(configuration);
        return services;
    }
}