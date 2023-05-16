using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YumeNailBar.Domain.Repositories;
using YumeNailBar.Infrastructure.Extensions;
using YumeNailBar.Infrastructure.Repositories;

namespace YumeNailBar.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRegistrationRepository, RegistrationRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddMsSqlServer(configuration);
        return services;
    }
}