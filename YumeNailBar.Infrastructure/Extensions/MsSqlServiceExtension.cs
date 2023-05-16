using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YumeNailBar.Infrastructure.EF.Contexts;
using YumeNailBar.Infrastructure.EF.Options;

namespace YumeNailBar.Infrastructure.Extensions;

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