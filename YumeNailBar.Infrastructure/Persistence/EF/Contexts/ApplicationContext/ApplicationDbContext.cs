using MediatR;
using Microsoft.EntityFrameworkCore;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

namespace YumeNailBar.Infrastructure.Persistence.EF.Contexts.ApplicationContext;

internal sealed class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;
    public ApplicationDbContext(DbContextOptions options, 
        IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
    }

    public DbSet<Registration> Registrations { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Procedure> Procedures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
}