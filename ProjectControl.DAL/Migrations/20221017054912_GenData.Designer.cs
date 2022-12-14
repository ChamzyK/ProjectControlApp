// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectControl.DAL.EF;

#nullable disable

namespace ProjectControl.DAL.Migrations
{
    [DbContext(typeof(ProjectControlContext))]
    [Migration("20221017054912_GenData")]
    partial class GenData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectControl.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Email = "Email0",
                            FirstName = "Edmond",
                            LastName = "Runge",
                            Patronymic = "Patronymic0"
                        },
                        new
                        {
                            EmployeeId = 2,
                            FirstName = "Avi",
                            LastName = "Javier",
                            Patronymic = "Patronymic1"
                        },
                        new
                        {
                            EmployeeId = 3,
                            Email = "Email2",
                            FirstName = "Kaelynn",
                            LastName = "Javier",
                            Patronymic = "Patronymic2"
                        },
                        new
                        {
                            EmployeeId = 4,
                            Email = "Email3",
                            FirstName = "Cadence",
                            LastName = "Westermeier",
                            Patronymic = "Patronymic3"
                        },
                        new
                        {
                            EmployeeId = 5,
                            Email = "Email4",
                            FirstName = "Avi",
                            LastName = "Smarsh",
                            Patronymic = "Patronymic4"
                        },
                        new
                        {
                            EmployeeId = 6,
                            Email = "Email5",
                            FirstName = "Edmond",
                            LastName = "Platter",
                            Patronymic = "Patronymic5"
                        },
                        new
                        {
                            EmployeeId = 7,
                            Email = "Email6",
                            FirstName = "Cadence",
                            LastName = "Chenot",
                            Patronymic = "Patronymic6"
                        },
                        new
                        {
                            EmployeeId = 8,
                            Email = "Email7",
                            FirstName = "Kaelynn",
                            LastName = "Smarsh",
                            Patronymic = "Patronymic7"
                        },
                        new
                        {
                            EmployeeId = 9,
                            Email = "Email8",
                            FirstName = "Edmond",
                            LastName = "Platter",
                            Patronymic = "Patronymic8"
                        },
                        new
                        {
                            EmployeeId = 10,
                            Email = "Email9",
                            FirstName = "Edmond",
                            LastName = "Smarsh",
                            Patronymic = "Patronymic9"
                        },
                        new
                        {
                            EmployeeId = 11,
                            Email = "Email10",
                            FirstName = "Todd",
                            LastName = "Javier",
                            Patronymic = "Patronymic10"
                        },
                        new
                        {
                            EmployeeId = 12,
                            Email = "Email11",
                            FirstName = "Kaelynn",
                            LastName = "Baskind",
                            Patronymic = "Patronymic11"
                        },
                        new
                        {
                            EmployeeId = 13,
                            FirstName = "Kaelynn",
                            LastName = "Runge",
                            Patronymic = "Patronymic12"
                        },
                        new
                        {
                            EmployeeId = 14,
                            Email = "Email13",
                            FirstName = "Edmond",
                            LastName = "Runge",
                            Patronymic = "Patronymic13"
                        },
                        new
                        {
                            EmployeeId = 15,
                            Email = "Email14",
                            FirstName = "Davian",
                            LastName = "Westermeier",
                            Patronymic = "Patronymic14"
                        },
                        new
                        {
                            EmployeeId = 16,
                            Email = "Email15",
                            FirstName = "Kaelynn",
                            LastName = "Westermeier",
                            Patronymic = "Patronymic15"
                        },
                        new
                        {
                            EmployeeId = 17,
                            Email = "Email16",
                            FirstName = "Avi",
                            LastName = "Chenot",
                            Patronymic = "Patronymic16"
                        },
                        new
                        {
                            EmployeeId = 18,
                            Email = "Email17",
                            FirstName = "Edmond",
                            LastName = "Westermeier",
                            Patronymic = "Patronymic17"
                        },
                        new
                        {
                            EmployeeId = 19,
                            Email = "Email18",
                            FirstName = "Todd",
                            LastName = "Chenot",
                            Patronymic = "Patronymic18"
                        },
                        new
                        {
                            EmployeeId = 20,
                            Email = "Email19",
                            FirstName = "Todd",
                            LastName = "Platter",
                            Patronymic = "Patronymic19"
                        });
                });

            modelBuilder.Entity("ProjectControl.Domain.Entities.Participation", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsManaged")
                        .HasColumnType("bit");

                    b.HasKey("ProjectId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Participation", (string)null);

                    b.HasData(
                        new
                        {
                            ProjectId = 2,
                            EmployeeId = 10,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 5,
                            EmployeeId = 16,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 1,
                            EmployeeId = 17,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 4,
                            EmployeeId = 16,
                            IsManaged = true
                        },
                        new
                        {
                            ProjectId = 3,
                            EmployeeId = 3,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 4,
                            EmployeeId = 5,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 3,
                            EmployeeId = 6,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 1,
                            EmployeeId = 20,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 3,
                            EmployeeId = 5,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 2,
                            EmployeeId = 3,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 1,
                            EmployeeId = 3,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 5,
                            EmployeeId = 10,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 2,
                            EmployeeId = 16,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 2,
                            EmployeeId = 20,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 1,
                            EmployeeId = 11,
                            IsManaged = true
                        },
                        new
                        {
                            ProjectId = 3,
                            EmployeeId = 4,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 3,
                            EmployeeId = 10,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 3,
                            EmployeeId = 2,
                            IsManaged = true
                        },
                        new
                        {
                            ProjectId = 2,
                            EmployeeId = 18,
                            IsManaged = true
                        },
                        new
                        {
                            ProjectId = 5,
                            EmployeeId = 8,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 5,
                            EmployeeId = 12,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 1,
                            EmployeeId = 2,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 2,
                            EmployeeId = 6,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 2,
                            EmployeeId = 5,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 4,
                            EmployeeId = 6,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 2,
                            EmployeeId = 19,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 3,
                            EmployeeId = 13,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 3,
                            EmployeeId = 9,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 3,
                            EmployeeId = 17,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 4,
                            EmployeeId = 2,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 4,
                            EmployeeId = 13,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 4,
                            EmployeeId = 19,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 4,
                            EmployeeId = 20,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 4,
                            EmployeeId = 12,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 2,
                            EmployeeId = 11,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 1,
                            EmployeeId = 16,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 3,
                            EmployeeId = 1,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 1,
                            EmployeeId = 10,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 1,
                            EmployeeId = 8,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 3,
                            EmployeeId = 16,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 5,
                            EmployeeId = 1,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 5,
                            EmployeeId = 19,
                            IsManaged = true
                        },
                        new
                        {
                            ProjectId = 2,
                            EmployeeId = 13,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 4,
                            EmployeeId = 8,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 3,
                            EmployeeId = 19,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 5,
                            EmployeeId = 5,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 5,
                            EmployeeId = 14,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 5,
                            EmployeeId = 7,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 1,
                            EmployeeId = 7,
                            IsManaged = false
                        },
                        new
                        {
                            ProjectId = 4,
                            EmployeeId = 4,
                            IsManaged = false
                        });
                });

            modelBuilder.Entity("ProjectControl.Domain.Entities.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<string>("Client")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Executor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");

                    b.HasCheckConstraint("CH_EndDate", "EndDate > StartDate");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            Client = "Fonie",
                            EndDate = new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Executor = "Nodesmith",
                            Name = "Odyssey",
                            Priority = 1,
                            StartDate = new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProjectId = 2,
                            Client = "Wunderwerk",
                            EndDate = new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Executor = "Techolite",
                            Name = "Techaza",
                            Priority = 1,
                            StartDate = new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProjectId = 3,
                            Client = "Fonie",
                            EndDate = new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Executor = "Techolite",
                            Name = "Luminous",
                            Priority = 3,
                            StartDate = new DateTime(2019, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProjectId = 4,
                            Client = "Lodex",
                            EndDate = new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Executor = "Neobot",
                            Name = "Techfluent",
                            Priority = 5,
                            StartDate = new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProjectId = 5,
                            Client = "Bitwise",
                            EndDate = new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Executor = "MakersLabs",
                            Name = "Techfluent",
                            Priority = 2,
                            StartDate = new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ProjectControl.Domain.Entities.Participation", b =>
                {
                    b.HasOne("ProjectControl.Domain.Entities.Employee", "Employee")
                        .WithMany("Participations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectControl.Domain.Entities.Project", "Project")
                        .WithMany("Participations")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectControl.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Participations");
                });

            modelBuilder.Entity("ProjectControl.Domain.Entities.Project", b =>
                {
                    b.Navigation("Participations");
                });
#pragma warning restore 612, 618
        }
    }
}
