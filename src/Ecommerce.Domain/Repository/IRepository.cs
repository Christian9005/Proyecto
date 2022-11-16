
using System.Linq.Expressions;
namespace Ecommerce.Domain;

public interface IRepository<TEntity, TId> where TEntity: class
{
    IUnitOfWork UnitOfWork {get;}
    IQueryable<TEntity> GetAll(bool asNoTracking = true);
    Task<TEntity> GetByIdAsync(TId id);
    Task<TEntity> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    void Delete(TEntity entity);
    IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

}
