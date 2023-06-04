namespace YumeNailBar.Infrastructure.Persistence.EF.Options;

public class PostgresOptions
{
    public string PostgresDbSectionName { get; set; }
    public string? ConnectionString { get; set; }
}