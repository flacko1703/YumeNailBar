using MediatR;
using Microsoft.EntityFrameworkCore;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;
using YumeNailBar.Infrastructure.Persistence.EF.Configuration;

namespace YumeNailBar.Infrastructure.Persistence.EF.Contexts.ApplicationContext;

internal sealed class CustomerDbContext : DbContext, ICustomerDbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options, 
        IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
    }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
}