using ProjectControl.Domain.Interfaces.Repositories;

namespace ProjectControl.Domain.Interfaces.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<TEntity> GetGenericRepository<TEntity>() 
        where TEntity : class;

    void SaveChanges();
}
