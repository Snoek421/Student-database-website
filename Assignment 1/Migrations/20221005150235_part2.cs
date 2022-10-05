using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_1.Migrations
{
    public partial class part2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProgramId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolProgramProgramId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    ProgramId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.ProgramId);
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramId", "ProgramName" },
                values: new object[,]
                {
                    { "BACS", "Bachelor of Applied Computer Science" },
                    { "CP", "Computer Programmer" },
                    { "CPA", "Computer Programmer Analyst" },
                    { "ITID", "IT Innovation and Design" }
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProgramId",
                value: "CPA");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProgramId",
                value: "BACS");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolProgramProgramId",
                table: "Students",
                column: "SchoolProgramProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Programs_SchoolProgramProgramId",
                table: "Students",
                column: "SchoolProgramProgramId",
                principalTable: "Programs",
                principalColumn: "ProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Programs_SchoolProgramProgramId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Students_SchoolProgramProgramId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolProgramProgramId",
                table: "Students");
        }
    }
}
