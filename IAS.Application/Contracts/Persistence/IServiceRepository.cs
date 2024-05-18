using IAS.Domain.Models;

namespace IAS.Application.Contracts.Persistence
{
  public interface IServiceRepository : IAsyncRepository<Service>
  {
    Task<IEnumerable<Service>> GetServices(int idTec, string fechaInicio, string fechaFin);
  }
}
