using Microsoft.EntityFrameworkCore;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;

namespace YumeNailBar.Infrastructure.Persistence.EF.Contexts.ApplicationContext;

public interface ICustomerDbContext
{
    public DbSet<Customer> Customers { get; set; }
}