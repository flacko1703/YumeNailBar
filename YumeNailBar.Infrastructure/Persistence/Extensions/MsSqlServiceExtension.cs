using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YumeNailBar.Infrastructure.Persistence.EF.Contexts;
using YumeNailBar.Infrastructure.Persistence.EF.Options;

namespace YumeNailBar.Infrastructure.Persistence.Extensions;

public static class MsSqlServiceExtension
{
    public static IServiceCollection AddMsSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<MsSqlServerOptions>("MsSqlServer");
        services.AddDbContext<ReadDbContext>(ctx => 
            ctx.UseSqlServer(options.ConnectionString));
        services.AddDbContext<WriteDbContext>(ctx => 
            ctx.UseSqlServer(options.ConnectionString));
        return services;
    }
}