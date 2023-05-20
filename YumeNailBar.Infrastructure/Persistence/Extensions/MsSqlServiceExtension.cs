using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Infrastructure.Persistence.EF.Contexts.ApplicationContext;
using YumeNailBar.Infrastructure.Persistence.EF.Contexts.EntityContexts;
using YumeNailBar.Infrastructure.Persistence.EF.Options;

namespace YumeNailBar.Infrastructure.Persistence.Extensions;

public static class MsSqlServiceExtension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<MsSqlServerOptions>("MsSqlServer");
        services.AddDbContext<ApplicationDbContext>(ctx 
            => ctx.UseSqlServer(options.ConnectionString));

        services.AddScoped<IApplicationDbContext>(s 
            => s.GetRequiredService<ApplicationDbContext>());
        
        services.AddScoped<IUnitOfWork>(s 
            => s.GetRequiredService<ApplicationDbContext>());
        services.AddDbContext<RegistrationDbContext>(ctx => 
            ctx.UseSqlServer(options.ConnectionString));
        services.AddDbContext<CustomerDbContext>(ctx => 
            ctx.UseSqlServer(options.ConnectionString));
        services.AddDbContext<ProcedureDbContext>(ctx => 
            ctx.UseSqlServer(options.ConnectionString));
        return services;
    }
}