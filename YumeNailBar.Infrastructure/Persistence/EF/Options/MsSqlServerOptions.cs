namespace YumeNailBar.Infrastructure.Persistence.EF.Options;

public class MsSqlServerOptions
{
    public string MsSqlDbSectionName { get; set; }
    public string? ConnectionString { get; set; }
}