using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateAdminAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { 999, "Software Engineering", "admin@hrapp.co.uk", "Admin", "None", new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Account", null, "£999999.00" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 999);
        }
    }
}
