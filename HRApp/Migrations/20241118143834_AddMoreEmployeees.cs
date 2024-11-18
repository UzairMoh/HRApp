using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreEmployeees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Marketing", "sthompson2@abc.net.au", "Sarah", "Female", new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thompson", "£42150.89" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "IT", "jchen3@abc.net.au", "James", "Male", new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chen", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "£51275.33" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "HR", "ewright4@abc.net.au", "Emma", new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wright", "£38992.45" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Sales", "mobrien5@abc.net.au", "Michael", new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "O'Brien", new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "£45678.90" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Product Management", "rquadrio2@wufoo.com", "Ronni", "Male", new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quadrio", null, "£56447.51" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Services", "cbroseman3@cam.ac.uk", "Chery", "Female", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Broseman", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "£42535.58" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Human Resources", "lbeadnall4@livejournal.com", "Lelia", new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beadnall", "£57500.48" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Legal", "aeslinger5@cam.ac.uk", "Archibold", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eslinger", "£32775.63" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[,]
                {
                    { 11, "Research and Development", "vmacarthur6@desdev.cn", "Vida", "Female", new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "MacArthur", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "£58116.07" },
                    { 12, "Training", "orapin7@guardian.co.uk", "Odey", "Male", new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rapin", null, "£32643.37" },
                    { 13, "Support", "jcottem8@fotki.com", "Jacquenetta", "Female", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cottem", null, "£20902.55" },
                    { 14, "Accounting", "amullaly9@toplist.cz", "Arny", "Male", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", null, "£53201.85" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Product Management", "rquadrio2@wufoo.com", "Ronni", "Male", new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quadrio", "£56447.51" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Services", "cbroseman3@cam.ac.uk", "Chery", "Female", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Broseman", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "£42535.58" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Human Resources", "lbeadnall4@livejournal.com", "Lelia", new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beadnall", "£57500.48" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Legal", "aeslinger5@cam.ac.uk", "Archibold", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eslinger", null, "£32775.63" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Research and Development", "vmacarthur6@desdev.cn", "Vida", "Female", new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "MacArthur", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "£58116.07" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Training", "orapin7@guardian.co.uk", "Odey", "Male", new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rapin", null, "£32643.37" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Support", "jcottem8@fotki.com", "Jacquenetta", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cottem", "£20902.55" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Accounting", "amullaly9@toplist.cz", "Arny", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", "£53201.85" });
        }
    }
}
