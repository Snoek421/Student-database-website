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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GPA = table.Column<double>(type: "float", nullable: false),
                    GpaScale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "DateOfBirth", "FirstName", "GPA", "GpaScale", "LastName" },
                values: new object[] { 1, null, new DateTime(1971, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bart", 2.7000000000000002, "", "Simpson" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "DateOfBirth", "FirstName", "GPA", "GpaScale", "LastName" },
                values: new object[] { 2, null, new DateTime(1973, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisa", 4.0, "", "Simpson" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
