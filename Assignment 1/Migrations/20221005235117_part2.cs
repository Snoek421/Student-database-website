using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_1.Migrations
{
    public partial class part2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    ProgramID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.ProgramID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GPA = table.Column<double>(type: "float", nullable: false),
                    GpaScale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    ProgramID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolProgramProgramID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Programs_SchoolProgramProgramID",
                        column: x => x.SchoolProgramProgramID,
                        principalTable: "Programs",
                        principalColumn: "ProgramID");
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramID", "Name" },
                values: new object[,]
                {
                    { "BACS", "Bachelor of Applied Computer Science" },
                    { "CP", "Computer Programmer" },
                    { "CPA", "Computer Programmer Analyst" },
                    { "ITID", "IT Innovation and Design" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "Age", "DateOfBirth", "FirstName", "GPA", "GpaScale", "LastName", "ProgramID", "SchoolProgramProgramID" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1971, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bart", 2.7000000000000002, null, "Simpson", "CPA", null },
                    { 2, null, new DateTime(1973, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisa", 4.0, null, "Simpson", "BACS", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolProgramProgramID",
                table: "Students",
                column: "SchoolProgramProgramID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Programs");
        }
    }
}
