using IAS.Application.Contracts.Persistence;
using IAS.Domain.Common;
using IAS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IAS.Infrastructure.Repositories
{
  public class RepositotyBase<T> : IAsyncRepository<T> where T : BaseDomainModel
  {

    protected readonly ServiceDbContext _context;

    public RepositotyBase(ServiceDbContext context)
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

    public Task<IReadOnlyList<T>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
    {
      throw new NotImplementedException();
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

    public Task<T> GetByIdAsync(int id)
    {
      throw new NotImplementedException();
    }
  }
}
