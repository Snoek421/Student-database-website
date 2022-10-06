using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_1.Migrations
{
    public partial class part2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SchoolProgramID",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    SchoolProgramID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SchoolProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.SchoolProgramID);
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "SchoolProgramID", "SchoolProgramName" },
                values: new object[,]
                {
                    { "BACS", "Bachelor of Applied Computer Science" },
                    { "CP", "Computer Programmer" },
                    { "CPA", "Computer Programmer Analyst" },
                    { "ITID", "IT Innovation and Design" }
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                column: "SchoolProgramID",
                value: "CPA");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 2,
                column: "SchoolProgramID",
                value: "BACS");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolProgramID",
                table: "Students",
                column: "SchoolProgramID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Programs_SchoolProgramID",
                table: "Students",
                column: "SchoolProgramID",
                principalTable: "Programs",
                principalColumn: "SchoolProgramID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Programs_SchoolProgramID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Students_SchoolProgramID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolProgramID",
                table: "Students");
        }
    }
}
