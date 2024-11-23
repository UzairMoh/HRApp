using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRApp.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BenefitsPackage",
                table: "Employee",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractType",
                table: "Employee",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeType",
                table: "Employee",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsOvertimeEligible",
                table: "Employee",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VacationDaysPerYear",
                table: "Employee",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkingHoursPerWeek",
                table: "Employee",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 999,
                columns: new[] { "BenefitsPackage", "ContractType", "EmployeeType", "IsOvertimeEligible", "VacationDaysPerYear", "WorkingHoursPerWeek" },
                values: new object[] { null, null, 0, false, 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BenefitsPackage",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ContractType",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeType",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IsOvertimeEligible",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "VacationDaysPerYear",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "WorkingHoursPerWeek",
                table: "Employee");
        }
    }
}
