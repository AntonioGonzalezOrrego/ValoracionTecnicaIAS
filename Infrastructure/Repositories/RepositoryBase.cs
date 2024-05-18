using IAS.Application.Contracts.Persistence;
using IAS.Domain.Common;
using IAS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IAS.Infrastructure.Repositories
{
  public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseDomainModel
  {

    protected readonly ServiceDbContext _context;

    public RepositoryBase(ServiceDbContext context)
    {
      _context = context;
    }

    public async Task<T> AddAsync(T entity)
    {
      _context.Set<T>().Add(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public void AddEntity(T entity)
    {
      _context.Set<T>().Add(entity);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
    {
      return await _context.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
      Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
      string? includeString = null,
      bool disableTracking = true)
    {
      IQueryable<T> query = _context.Set<T>();
      if (disableTracking) query = query.AsNoTracking();

      if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

      if (predicate != null) query = query.Where(predicate);

      if (orderBy != null) return await orderBy(query).ToListAsync();

      return await query.ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<Expression<Func<T, object>>> includeString = null, bool disableTracking = true)
    {
      IQueryable<T> query = _context.Set<T>();
      if (disableTracking) query = query.AsNoTracking();

      if(includeString != null) query = includeString.Aggregate(query, (current, includeString) => current.Include(includeString));

      if(predicate != null) query = query.Where(predicate);

      if (orderBy != null) return await orderBy(query).ToListAsync();

      return await query.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
      return await _context.Set<T>().FindAsync(id);
    }
  }
}
