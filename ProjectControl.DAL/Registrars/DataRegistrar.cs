using Microsoft.Extensions.DependencyInjection;
using ProjectControl.DAL.EF;
using ProjectControl.DAL.Repositories.Generic;
using ProjectControl.DAL.UnitOfWorks;
using ProjectControl.Domain.Entities;
using ProjectControl.Domain.Interfaces.Repositories;
using ProjectControl.Domain.Interfaces.UnitOfWorks;

namespace ProjectControl.DAL.Registrars
{
    public static class DataRegistrar
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IGenericRepository<Project>, EFGenericRepository<Project>>()
                    .AddScoped<IGenericRepository<Employee>, EFGenericRepository<Employee>>()
                    .AddScoped<IGenericRepository<Participation>, EFGenericRepository<Participation>>();
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork, EFUnitOfWorks>();
        }

        public static IServiceCollection AddDbContext(this ServiceCollection services)
        {
            return services.AddScoped(provider => new ProjectControlContextFactory().CreateDbContext(null!));
        }
    }
}
