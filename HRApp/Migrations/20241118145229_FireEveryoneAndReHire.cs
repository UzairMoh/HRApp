using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRApp.Migrations
{
    /// <inheritdoc />
    public partial class FireEveryoneAndReHire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Software Engineering", "schen@company.com", "Sarah", new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chen", "£65000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Software Engineering", "jwilson@company.com", "James", new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wilson", null, "£62000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Product Management", "epatel@company.com", "Emily", new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patel", "£68000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Sales", "mthompson@company.com", "Michael", new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thompson", new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "£55000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Marketing", "jkumar@company.com", "Jessica", new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar", "£52000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Software Engineering", "dzhang@company.com", "David", new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zhang", null, "£63000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Human Resources", "lmartinez@company.com", "Lisa", "Female", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martinez", "£48000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Software Engineering", "rsingh@company.com", "Robert", "Male", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singh", new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "£64000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Product Management", "mlee@company.com", "Michelle", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lee", "£66000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Sales", "wbrown@company.com", "William", new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown", "£54000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Software Engineering", "ejohnson@company.com", "Emma", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", null, "£61000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Marketing", "dkim@company.com", "Daniel", new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kim", new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "£51000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Software Engineering", "rgarcia@company.com", "Rachel", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garcia", "£63000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Product Management", "tanderson@company.com", "Thomas", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anderson", "£67000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Software Engineering", "swang@company.com", "Sophia", "Female", new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wang", "£62000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Sales", "ktaylor@company.com", "Kevin", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor", "£56000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Marketing", "arodriguez@company.com", "Anna", "Female", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodriguez", "£53000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Software Engineering", "cgupta@company.com", "Christopher", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gupta", new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "£65000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Human Resources", "anguyen@company.com", "Alexandra", "Female", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen", "£49000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Software Engineering", "rwhite@company.com", "Ryan", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "White", "£64000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Product Management", "isantos@company.com", "Isabella", "Female", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Santos", "£65000.00" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Software Engineering", "jpark@company.com", "Jonathan", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Park", "£63000.00" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[,]
                {
                    { 23, "Marketing", "mcollins@company.com", "Maria", "Female", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Collins", null, "£52000.00" },
                    { 24, "Sales", "amurphy@company.com", "Andrew", "Male", new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Murphy", null, "£55000.00" },
                    { 25, "Software Engineering", "jcohen@company.com", "Julia", "Female", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cohen", null, "£61000.00" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Engineering", "ebissill0@mac.com", "Evaleen", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bissill", "£28110.63" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Accounting", "cmulvey1@abc.net.au", "Chrisy", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mulvey", new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "£34886.72" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Marketing", "sthompson2@abc.net.au", "Sarah", new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thompson", "£42150.89" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "IT", "jchen3@abc.net.au", "James", new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chen", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "£51275.33" });

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
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Product Management", "rquadrio2@wufoo.com", "Ronni", "Male", new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quadrio", "£56447.51" });

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

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Research and Development", "vmacarthur6@desdev.cn", "Vida", new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "MacArthur", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "£58116.07" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Training", "orapin7@guardian.co.uk", "Odey", new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rapin", null, "£32643.37" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Support", "jcottem8@fotki.com", "Jacquenetta", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cottem", "£20902.55" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Accounting", "amullaly9@toplist.cz", "Arny", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", "£53201.85" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Accounting", "amullaly9@toplist.cz", "Arny", "Male", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", "£53201.85" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Accounting", "amullaly9@toplist.cz", "Arny", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", "£53201.85" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Accounting", "amullaly9@toplist.cz", "Arny", "Male", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", "£53201.85" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "LeaveDate", "Salary" },
                values: new object[] { "Accounting", "amullaly9@toplist.cz", "Arny", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", null, "£53201.85" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Accounting", "amullaly9@toplist.cz", "Arny", "Male", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", "£53201.85" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Accounting", "amullaly9@toplist.cz", "Arny", new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", "£53201.85" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Department", "Email", "FirstName", "Gender", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Accounting", "amullaly9@toplist.cz", "Arny", "Male", new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", "£53201.85" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Department", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Accounting", "amullaly9@toplist.cz", "Arny", new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mullaly", "£53201.85" });
        }
    }
}
