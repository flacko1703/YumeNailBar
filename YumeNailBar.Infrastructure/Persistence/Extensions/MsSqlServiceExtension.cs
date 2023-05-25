using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Infrastructure.Persistence.EF.Contexts.ApplicationContext;
using YumeNailBar.Infrastructure.Persistence.EF.Options;

namespace YumeNailBar.Infrastructure.Persistence.Extensions;

public static class MsSqlServiceExtension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<MsSqlServerOptions>("MsSqlServer");
        services.AddDbContext<CustomerDbContext>(ctx 
            => ctx.UseSqlServer(options.ConnectionString));

        services.AddScoped<ICustomerDbContext>(s 
            => s.GetRequiredService<CustomerDbContext>());
        
        services.AddScoped<IUnitOfWork>(s 
            => s.GetRequiredService<CustomerDbContext>());
        
        return services;
    }
}