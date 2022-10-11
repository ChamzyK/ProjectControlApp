using ProjectControl.Domain.Entities;
using ProjectControl.Domain.Interfaces.Repositories;
using ProjectControl.Domain.Interfaces.UnitOfWorks;
using ProjectControl.DAL.EF;
using ProjectControl.DAL.Repositories.Generic;

namespace ProjectControl.DAL.UnitOfWorks;

internal class EFUnitOfWorks : IUnitOfWork
{
    private readonly ProjectControlContext _context;
    private bool _disposed;

    public Dictionary<Type, object> Repositories { get; set; }

    public EFUnitOfWorks(ProjectControlContext context)
    {
        _context = context;

        //TODO:get objects from outside (maybe injection?)
        Repositories = new Dictionary<Type, object>
        {
            { typeof(Project), new EFGenericRepository<Project>(_context) },
            { typeof(Employee), new EFGenericRepository<Employee>(_context) },
            { typeof(Participation), new EFGenericRepository<Participation>(_context) }
        };
    }

    public IGenericRepository<TEntity> GetGenericRepository<TEntity>()
        where TEntity : class
    {
        return (IGenericRepository<TEntity>)Repositories[typeof(TEntity)];
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    void IDisposable.Dispose()
    {
        if (_disposed || _context == null)
        {
            return;
        }
        _disposed = true;
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
