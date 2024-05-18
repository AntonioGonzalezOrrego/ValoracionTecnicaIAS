using IAS.Application.Contracts.Persistence;
using IAS.Domain.Models;
using IAS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IAS.Infrastructure.Repositories
{
  public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
  {

    public ServiceRepository(ServiceDbContext context) : base(context)
    {

    }

    public async Task<IEnumerable<Service>> GetServices(int idTec, string fechaInicio, string fechaFin)
    {
      return await _context.Services.Where(t => t.InitDateService == fechaInicio).ToListAsync();
    }
  }
}
