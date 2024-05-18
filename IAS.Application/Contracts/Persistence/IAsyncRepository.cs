using IAS.Domain.Common;
using System.Linq.Expressions;

namespace IAS.Application.Contracts.Persistence
{
  public interface IAsyncRepository<T> where T : BaseDomainModel
  {
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
      Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
      string? includeString = null,
      bool disableTracking = true);

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
      Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
      List<Expression<Func<T, object>>> includeString = null,
      bool disableTracking = true);

    void AddEntity(T entity);

    //Implementar la paginación si queda tiempo..

  }
}
