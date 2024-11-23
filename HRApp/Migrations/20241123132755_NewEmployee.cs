using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRApp.Migrations
{
    /// <inheritdoc />
    public partial class NewEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "Gender", "LastName" },
                values: new object[] { "uzairmohammedpc@gmail.com", "Uzair", "Male", "Mohammed" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "Gender", "LastName" },
                values: new object[] { "schen@company.com", "Sarah", "Female", "Chen" });
        }
    }
}
