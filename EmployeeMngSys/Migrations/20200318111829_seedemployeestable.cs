using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeMngSys.Migrations
{
    public partial class seedemployeestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Name", "Phone_No" },
                values: new object[] { 1, 1, "dbt@gmail.com", "Dolon Banik", 1700000000 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Name", "Phone_No" },
                values: new object[] { 2, 2, "tanni@gmail.com", "Tanni Banik", 1700000000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
