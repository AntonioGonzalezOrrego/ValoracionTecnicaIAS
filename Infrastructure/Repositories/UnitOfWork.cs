using IAS.Application.Contracts.Persistence;
using IAS.Domain.Common;
using IAS.Infrastructure.Persistence;
using System.Collections;

namespace IAS.Infrastructure.Repositories
{  
  public class UnitOfWork : IUnitOfWork
  {
    private Hashtable _repositories;
    private readonly ServiceDbContext _context;

    private IServiceRepository _serviceRepository;

    public IServiceRepository ServiceRepository => _serviceRepository ??= new ServiceRepository(_context);

    public UnitOfWork(Hashtable repositories, ServiceDbContext context)
    {
      _repositories = repositories;
      _context = context;
    }
    

    public ServiceDbContext serviceDbContext => _context;

    public async Task<int> Complete()
    {
      try
      {
        return await _context.SaveChangesAsync();
      }catch (Exception)
      {
        throw new Exception("Error");
      }
    }

    public void Dispose()
    {
      _context.Dispose();
    }

    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
    {
      if(_serviceRepository == null)
      {
        _repositories = new Hashtable();
      }

      var type = typeof(TEntity).Name;

      if (!_repositories.ContainsKey(type))
      {
        var repositoryType = typeof(RepositotyBase<>);
        var repositorInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
        _repositories.Add(type, repositorInstance);
        
      }
      return (IAsyncRepository<TEntity>)_repositories[type];
    }
  }
}
