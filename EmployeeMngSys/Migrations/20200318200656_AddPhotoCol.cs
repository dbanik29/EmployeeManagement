using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeMngSys.Migrations
{
    public partial class AddPhotoCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoFile",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoFile",
                table: "Employees");
        }
    }
}
