using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_1.Migrations
{
    public partial class part1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    GPA = table.Column<double>(type: "float", nullable: false),
                    GpaScale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "Age", "DateOfBirth", "FirstName", "GPA", "GpaScale", "LastName" },
                values: new object[] { 1, 51, "05/31/1971", "Bart", 2.7000000000000002, "Satisfactory", "Simpson" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "Age", "DateOfBirth", "FirstName", "GPA", "GpaScale", "LastName" },
                values: new object[] { 2, 49, "08/05/1973", "Lisa", 4.0, "Excellent", "Simpson" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
