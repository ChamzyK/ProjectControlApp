using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectControl.DAL.Migrations
{
    public partial class GenData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Executor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.CheckConstraint("CH_EndDate", "EndDate > StartDate");
                });

            migrationBuilder.CreateTable(
                name: "Participation",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IsManaged = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participation", x => new { x.ProjectId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_Participation_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participation_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "LastName", "Patronymic" },
                values: new object[,]
                {
                    { 1, "Email0", "Edmond", "Runge", "Patronymic0" },
                    { 2, null, "Avi", "Javier", "Patronymic1" },
                    { 3, "Email2", "Kaelynn", "Javier", "Patronymic2" },
                    { 4, "Email3", "Cadence", "Westermeier", "Patronymic3" },
                    { 5, "Email4", "Avi", "Smarsh", "Patronymic4" },
                    { 6, "Email5", "Edmond", "Platter", "Patronymic5" },
                    { 7, "Email6", "Cadence", "Chenot", "Patronymic6" },
                    { 8, "Email7", "Kaelynn", "Smarsh", "Patronymic7" },
                    { 9, "Email8", "Edmond", "Platter", "Patronymic8" },
                    { 10, "Email9", "Edmond", "Smarsh", "Patronymic9" },
                    { 11, "Email10", "Todd", "Javier", "Patronymic10" },
                    { 12, "Email11", "Kaelynn", "Baskind", "Patronymic11" },
                    { 13, null, "Kaelynn", "Runge", "Patronymic12" },
                    { 14, "Email13", "Edmond", "Runge", "Patronymic13" },
                    { 15, "Email14", "Davian", "Westermeier", "Patronymic14" },
                    { 16, "Email15", "Kaelynn", "Westermeier", "Patronymic15" },
                    { 17, "Email16", "Avi", "Chenot", "Patronymic16" },
                    { 18, "Email17", "Edmond", "Westermeier", "Patronymic17" },
                    { 19, "Email18", "Todd", "Chenot", "Patronymic18" },
                    { 20, "Email19", "Todd", "Platter", "Patronymic19" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Client", "EndDate", "Executor", "Name", "Priority", "StartDate" },
                values: new object[,]
                {
                    { 1, "Fonie", new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nodesmith", "Odyssey", 1, new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Wunderwerk", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Techolite", "Techaza", 1, new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Fonie", new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Techolite", "Luminous", 3, new DateTime(2019, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Lodex", new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neobot", "Techfluent", 5, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Bitwise", new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "MakersLabs", "Techfluent", 2, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Participation",
                columns: new[] { "EmployeeId", "ProjectId", "IsManaged" },
                values: new object[,]
                {
                    { 2, 1, false },
                    { 3, 1, false },
                    { 7, 1, false },
                    { 8, 1, false },
                    { 10, 1, false },
                    { 11, 1, true },
                    { 16, 1, false },
                    { 17, 1, false },
                    { 20, 1, false },
                    { 3, 2, false },
                    { 5, 2, false },
                    { 6, 2, false },
                    { 10, 2, false },
                    { 11, 2, false },
                    { 13, 2, false },
                    { 16, 2, false },
                    { 18, 2, true },
                    { 19, 2, false },
                    { 20, 2, false },
                    { 1, 3, false },
                    { 2, 3, true },
                    { 3, 3, false },
                    { 4, 3, false },
                    { 5, 3, false },
                    { 6, 3, false },
                    { 9, 3, false },
                    { 10, 3, false },
                    { 13, 3, false },
                    { 16, 3, false },
                    { 17, 3, false },
                    { 19, 3, false },
                    { 2, 4, false },
                    { 4, 4, false },
                    { 5, 4, false },
                    { 6, 4, false },
                    { 8, 4, false },
                    { 12, 4, false },
                    { 13, 4, false },
                    { 16, 4, true },
                    { 19, 4, false },
                    { 20, 4, false },
                    { 1, 5, false }
                });

            migrationBuilder.InsertData(
                table: "Participation",
                columns: new[] { "EmployeeId", "ProjectId", "IsManaged" },
                values: new object[,]
                {
                    { 5, 5, false },
                    { 7, 5, false },
                    { 8, 5, false },
                    { 10, 5, false },
                    { 12, 5, false },
                    { 14, 5, false },
                    { 16, 5, false },
                    { 19, 5, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participation_EmployeeId",
                table: "Participation",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participation");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
