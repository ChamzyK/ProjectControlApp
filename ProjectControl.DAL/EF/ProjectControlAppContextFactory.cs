using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProjectControl.DAL.EF;

public class ProjectControlAppContextFactory : IDesignTimeDbContextFactory<ProjectControlAppContext>
{
    //TODO: make a separate config file
    private static readonly string _connectionString = "Server=(localdb)\\MsSqlLocalDB; Database=ProjectControlAppDb; Trusted_Connection=True;";

    public ProjectControlAppContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<ProjectControlAppContext>()
            .UseSqlServer(_connectionString)
            .Options;

        return new ProjectControlAppContext(options);
    }
}
