using System.Linq.Expressions;

namespace ProjectControl.Domain.Interfaces.Repositories;

public interface IGenericRepository<TEntity>
    where TEntity : class
{
    void Create(TEntity entity);

    TEntity? FindById(int id);
    IEnumerable<TEntity> Get();
    IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
    IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
    IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

    void Update(TEntity entity);

    void Remove(TEntity entity);
}
