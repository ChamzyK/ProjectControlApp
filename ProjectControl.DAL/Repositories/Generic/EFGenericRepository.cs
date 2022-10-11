using Microsoft.EntityFrameworkCore;
using ProjectControl.Domain.Interfaces.Repositories;
using ProjectControl.DAL.EF;
using System.Linq.Expressions;

namespace ProjectControl.DAL.Repositories.Generic;

internal class EFGenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
{
    private readonly ProjectControlContext _context;
    private readonly DbSet<TEntity> _set;

    public EFGenericRepository(ProjectControlContext context)
    {
        _context = context;
        _set = context.Set<TEntity>();
    }

    public void Create(TEntity entity)
    {
        _set.Add(entity);
    }

    public TEntity? FindById(params int[] id)
    {
        return _set.Find(id);
    }

    public IEnumerable<TEntity> Get()
    {
        return _set.AsNoTracking().ToList();
    }

    public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
    {
        return _set.AsNoTracking().Where(predicate).ToList();
    }

    public void Update(TEntity entity)
    {
        _context.ChangeTracker.Clear(); //TODO: crutch
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Remove(TEntity entity)
    {
        _set.Remove(entity);
    }

    public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }
    public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }
    private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = _set.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}
