using Microsoft.Extensions.Configuration;

namespace YumeNailBar.Infrastructure.Persistence.Extensions;

public static class MsSqlConfigurationExtension
{
    public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string sectionName)
        where TOptions : new()
    {
        var options = new TOptions();
        configuration.GetSection(sectionName).Bind(options);
        return options;
    }
}