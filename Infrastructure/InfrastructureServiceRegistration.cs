using IAS.Application.Contracts.Persistence;
using IAS.Infrastructure.Persistence;
using IAS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IAS.Infrastructure
{
  public static class InfrastructureServiceRegistration
  {
    public static IServiceCollection InfrastructureServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<ServiceDbContext>(options =>
      options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositotyBase<>));
      services.AddScoped(IServiceRepository, ServiceRepository);

      return services;
    }
  }
}
