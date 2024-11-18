using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreEmployeeesAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[,]
                {
                    { 15, "Accounting", "amullaly9@toplist.cz", "Arny", "Male", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", null, "£53201.85" },
                    { 16, "Accounting", "amullaly9@toplist.cz", "Arny", "Male", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", null, "£53201.85" },
                    { 17, "Accounting", "amullaly9@toplist.cz", "Arny", "Male", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", null, "£53201.85" },
                    { 18, "Accounting", "amullaly9@toplist.cz", "Arny", "Male", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", null, "£53201.85" },
                    { 19, "Accounting", "amullaly9@toplist.cz", "Arny", "Male", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", null, "£53201.85" },
                    { 20, "Accounting", "amullaly9@toplist.cz", "Arny", "Male", new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", null, "£53201.85" },
                    { 21, "Accounting", "amullaly9@toplist.cz", "Arny", "Male", new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", null, "£53201.85" },
                    { 22, "Accounting", "amullaly9@toplist.cz", "Arny", "Male", new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", null, "£53201.85" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 22);
        }
    }
}
