using IAS.Domain.Common;

namespace IAS.Application.Contracts.Persistence
{
  public interface IUnitOfWork : IDisposable
  {
    IServiceRepository ServiceRepository { get; }
    IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

    Task<int> Complete();

    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}
