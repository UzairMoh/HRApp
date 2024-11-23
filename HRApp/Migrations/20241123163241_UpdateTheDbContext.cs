using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTheDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 14);

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

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BenefitsPackage", "ContractType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { "Full Benefits Package", "Permanent", true, 25, 40 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BenefitsPackage", "ContractType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { "Full Benefits Package", "Permanent", true, 25, 40 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 999,
                columns: new[] { "BenefitsPackage", "ContractType", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { "Executive Benefits Package", "Permanent Executive", 30, 40 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BenefitsPackage", "ContractType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BenefitsPackage", "ContractType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 999,
                columns: new[] { "BenefitsPackage", "ContractType", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, 0 });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "BenefitsPackage", "ContractType", "Department", "Email", "EmployeeType", "FirstName", "Gender", "IsOvertimeEligible", "JoinDate", "LastName", "LeaveDate", "Salary", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[,]
                {
                    { 3, null, null, "Product Management", "epatel@company.com", 0, "Emily", "Female", false, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patel", null, "£68000.00", 0, 0 },
                    { 4, null, null, "Sales", "mthompson@company.com", 0, "Michael", "Male", false, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thompson", new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "£55000.00", 0, 0 },
                    { 5, null, null, "Marketing", "jkumar@company.com", 0, "Jessica", "Female", false, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar", null, "£52000.00", 0, 0 },
                    { 6, null, null, "Software Engineering", "dzhang@company.com", 0, "David", "Male", false, new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zhang", null, "£63000.00", 0, 0 },
                    { 7, null, null, "Human Resources", "lmartinez@company.com", 0, "Lisa", "Female", false, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martinez", null, "£48000.00", 0, 0 },
                    { 8, null, null, "Software Engineering", "rsingh@company.com", 0, "Robert", "Male", false, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singh", new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "£64000.00", 0, 0 },
                    { 9, null, null, "Product Management", "mlee@company.com", 0, "Michelle", "Female", false, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lee", null, "£66000.00", 0, 0 },
                    { 10, null, null, "Sales", "wbrown@company.com", 0, "William", "Male", false, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown", null, "£54000.00", 0, 0 },
                    { 11, null, null, "Software Engineering", "ejohnson@company.com", 0, "Emma", "Female", false, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", null, "£61000.00", 0, 0 },
                    { 12, null, null, "Marketing", "dkim@company.com", 0, "Daniel", "Male", false, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kim", new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "£51000.00", 0, 0 },
                    { 13, null, null, "Software Engineering", "rgarcia@company.com", 0, "Rachel", "Female", false, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garcia", null, "£63000.00", 0, 0 },
                    { 14, null, null, "Product Management", "tanderson@company.com", 0, "Thomas", "Male", false, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anderson", null, "£67000.00", 0, 0 },
                    { 15, null, null, "Software Engineering", "swang@company.com", 0, "Sophia", "Female", false, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wang", null, "£62000.00", 0, 0 },
                    { 16, null, null, "Sales", "ktaylor@company.com", 0, "Kevin", "Male", false, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor", null, "£56000.00", 0, 0 },
                    { 17, null, null, "Marketing", "arodriguez@company.com", 0, "Anna", "Female", false, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodriguez", null, "£53000.00", 0, 0 },
                    { 18, null, null, "Software Engineering", "cgupta@company.com", 0, "Christopher", "Male", false, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gupta", new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "£65000.00", 0, 0 },
                    { 19, null, null, "Human Resources", "anguyen@company.com", 0, "Alexandra", "Female", false, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen", null, "£49000.00", 0, 0 },
                    { 20, null, null, "Software Engineering", "rwhite@company.com", 0, "Ryan", "Male", false, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "White", null, "£64000.00", 0, 0 },
                    { 21, null, null, "Product Management", "isantos@company.com", 0, "Isabella", "Female", false, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Santos", null, "£65000.00", 0, 0 },
                    { 22, null, null, "Software Engineering", "jpark@company.com", 0, "Jonathan", "Male", false, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Park", null, "£63000.00", 0, 0 },
                    { 23, null, null, "Marketing", "mcollins@company.com", 0, "Maria", "Female", false, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Collins", null, "£52000.00", 0, 0 },
                    { 24, null, null, "Sales", "amurphy@company.com", 0, "Andrew", "Male", false, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Murphy", null, "£55000.00", 0, 0 },
                    { 25, null, null, "Software Engineering", "jcohen@company.com", 0, "Julia", "Female", false, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cohen", null, "£61000.00", 0, 0 }
                });
        }
    }
}
