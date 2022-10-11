using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectControl.Domain.Entities;

namespace ProjectControlApp.DAL.EF;

public class ProjectControlAppContext : DbContext
{
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Participation> Participations { get; set; } = null!;

    public ProjectControlAppContext(DbContextOptions<ProjectControlAppContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(projectBuilder => SetUp(projectBuilder));

        modelBuilder.Entity<Employee>(employeeBuilder => SetUp(employeeBuilder));

        modelBuilder.Entity<Participation>(participationBuilder => SetUp(participationBuilder));

        //use fluentAPI for configuring many-to-many relationship
        modelBuilder.Entity<Employee>()
            .HasMany(employee => employee.Projects)
            .WithMany(project => project.Employees)

            .UsingEntity<Participation>(

                //setting relation between participation and project
                typeBuilder => typeBuilder
                .HasOne(participation => participation.Project)
                .WithMany(project => project.Participations)
                .HasForeignKey(participation => participation.ProjectId),

            //setting relation between participation and employee
            typeBuilder => typeBuilder
                .HasOne(participation => participation.Employee)
                .WithMany(employee => employee.Participations)
                .HasForeignKey(participation => participation.EmployeeId),

            //define key for participation(composite key) and rename the intermediate table
            typeBuilder =>
            {
                typeBuilder.HasKey(participation => new { participation.ProjectId, participation.EmployeeId });
                typeBuilder.ToTable(nameof(Participation));
            });
    }

    private static void SetUp(EntityTypeBuilder<Project> project)
    {
        project.HasKey(p => p.ProjectId);
        project.Property(p => p.Name).IsRequired().HasMaxLength(30);
        project.Property(p => p.Client).IsRequired();
        project.Property(p => p.Executor).IsRequired();
        project.Property(p => p.Priority).IsRequired();
        project.Property(p => p.StartDate).IsRequired();
        project.Property(p => p.EndDate).IsRequired();
        project.HasCheckConstraint("CH_EndDate", "EndDate > StartDate");
    }
    private static void SetUp(EntityTypeBuilder<Employee> employee)
    {
        employee.HasKey(e => e.EmployeeId);
        employee.Property(e => e.LastName).IsRequired().HasMaxLength(30);
        employee.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
        employee.Property(e => e.Patronymic).IsRequired().HasMaxLength(30);
        employee.Property(e => e.Email).HasMaxLength(30);
    }
    private static void SetUp(EntityTypeBuilder<Participation> participation)
    {
        participation
            .HasOne<Project>()
            .WithMany()
            .HasForeignKey(p => p.ProjectId);

        participation
            .HasOne<Employee>()
            .WithMany()
            .HasForeignKey(p => p.EmployeeId);
    }
}
