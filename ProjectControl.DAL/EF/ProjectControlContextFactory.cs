using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProjectControl.DAL.EF;

internal class ProjectControlContextFactory : IDesignTimeDbContextFactory<ProjectControlContext>
{
    //TODO: make a separate config file
    private static readonly string _connectionString = "Server=(localdb)\\MsSqlLocalDB; Database=ProjectControlDb; Trusted_Connection=True;";

    public ProjectControlContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<ProjectControlContext>()
            .UseSqlServer(_connectionString)
            .Options;

        return new ProjectControlContext(options);
    }
}
