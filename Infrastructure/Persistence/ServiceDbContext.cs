using IAS.Domain.Common;
using IAS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IAS.Infrastructure.Persistence
{
  public class ServiceDbContext : DbContext
  {
    public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options) { }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      foreach(var entry in ChangeTracker.Entries<BaseDomainModel>())
      {
        switch (entry.State)
        {
          case EntityState.Added:
            entry.Entity.CreatedDate = DateTime.UtcNow;
            entry.Entity.User = "AntonioG";
            break;
        }
      }
      return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<Service> Services { get; set; }
    public DbSet<Technician> Technicianes { get; set; }
  }
}
