using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectControl.Domain.Entities;

namespace ProjectControl.DAL.EF;

internal class ProjectControlContext : DbContext
{
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Participation> Participations { get; set; } = null!;

    public ProjectControlContext(DbContextOptions<ProjectControlContext> options) : base(options) { }

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

        modelBuilder.Entity<Participation>().HasData(GetProjects());
        modelBuilder.Entity<Participation>().HasData(GetEmployees());
        modelBuilder.Entity<Participation>().HasData(GetParticipations());
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

    private static Project[] GetProjects()
    {
        var projects = new Project[5];

        projects[0] = new Project
        {
            ProjectId = 1,
            Name = "Odyssey",
            Client = "Fonie",
            Executor = "Nodesmith",
            StartDate = new DateTime(2020, 6, 12),
            EndDate = new DateTime(2020, 8, 6),
        };

        projects[1] = new Project
        {
            ProjectId = 2,
            Name = "Techaza",
            Client = "Wunderwerk",
            Executor = "Techolite",
            StartDate = new DateTime(2022, 1, 25),
            EndDate = new DateTime(2023, 8, 15),
        };

        projects[2] = new Project
        {
            ProjectId = 3,
            Name = "Luminous",
            Client = "Fonie",
            Executor = "Techolite",
            StartDate = new DateTime(2019, 3, 20),
            EndDate = new DateTime(2021, 12, 31),
        };

        projects[3] = new Project
        {
            ProjectId = 4,
            Name = "Techfluent",
            Client = "Lodex",
            Executor = "Neobot",
            StartDate = new DateTime(2022, 2, 16),
            EndDate = new DateTime(2022, 9, 5),
        };

        projects[4] = new Project
        {
            ProjectId = 5,
            Name = "Techfluent",
            Client = "Bitwise",
            Executor = "MakersLabs",
            StartDate = new DateTime(2023, 6, 10),
            EndDate = new DateTime(2023, 9, 10),
        };
        return projects;
    }
    private static Employee[] GetEmployees()
    {
        var employees = new Employee[20];

        string[] lastNames = { "Smarsh", "Chenot", "Baskind", "Javier", "Westermeier", "Platter", "Runge" };
        string[] firstNames = { "Davian", "Maisie", "Kaelynn", "Edmond", "Cadence", "Todd", "Avi" };

        var random = new Random(Guid.NewGuid().GetHashCode());

        for (int i = 0; i < employees.Length; i++)
        {
            employees[i] = new Employee
            {
                EmployeeId = i + 1,
                LastName = lastNames[random.Next(0, 7)],
                FirstName = firstNames[random.Next(0, 7)],
                Patronymic = "Patronymic" + i,
                Email = random.Next(0, 100) < 15 ? null : "Email" + i
            };
        }
        return employees;
    }

    private static Participation[] GetParticipations()
    {
        var participations = new Participation[50];
        var random = new Random(Guid.NewGuid().GetHashCode());
        for (int i = 0; i < participations.Length; i++)
        {
            var projectId = 0;
            var employeeId = 0;

            do
            {
                projectId = random.Next(0, 5) + 1;
                employeeId = random.Next(0, 20) + 1;
            }
            while (participations.FirstOrDefault(p => p.EmployeeId == employeeId && p.ProjectId == projectId) != null);

            participations[i] = new Participation
            {
                ProjectId = projectId,
                EmployeeId = employeeId,
                IsManaged = false
            };
        }
        var group = participations.GroupBy(p => p.ProjectId);

        foreach (var item in group)
        {
            var arr = item.ToArray();
            arr[random.Next(0, arr.Length)].IsManaged = true;
        }
        return participations.Where(p => p != null).ToArray();
    }
}
