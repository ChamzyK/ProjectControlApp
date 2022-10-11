using ProjectControl.DAL.Repositories.Generic;
using ProjectControl.DAL.UnitOfWorks;
using ProjectControl.Domain.Entities;
using ProjectControl.Domain.Interfaces.Repositories;
using ProjectControl.Domain.Interfaces.UnitOfWorks;

namespace ProjectControl.WEB.Services
{
    public static class DataRegistrar
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
            .AddScoped<IGenericRepository<Project>, EFGenericRepository<Project>>()
            .AddScoped<IGenericRepository<Employee>, EFGenericRepository<Employee>>()
            .AddScoped<IGenericRepository<Participation>, EFGenericRepository<Participation>>();

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
            => services.AddScoped<IUnitOfWork, EFUnitOfWork>();
    }
}
