using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Department = table.Column<string>(type: "TEXT", nullable: true),
                    Salary = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Department", "Email", "FirstName", "Gender", "LastName", "Salary" },
                values: new object[,]
                {
                    { 1, "Engineering", "ebissill0@mac.com", "Evaleen", "Female", "Bissill", "£28110.63" },
                    { 2, "Accounting", "cmulvey1@abc.net.au", "Chrisy", "Male", "Mulvey", "£34886.72" },
                    { 3, "Product Management", "rquadrio2@wufoo.com", "Ronni", "Male", "Quadrio", "£56447.51" },
                    { 4, "Services", "cbroseman3@cam.ac.uk", "Chery", "Female", "Broseman", "£42535.58" },
                    { 5, "Human Resources", "lbeadnall4@livejournal.com", "Lelia", "Female", "Beadnall", "£57500.48" },
                    { 6, "Legal", "aeslinger5@cam.ac.uk", "Archibold", "Male", "Eslinger", "£32775.63" },
                    { 7, "Research and Development", "vmacarthur6@desdev.cn", "Vida", "Female", "MacArthur", "£58116.07" },
                    { 8, "Training", "orapin7@guardian.co.uk", "Odey", "Male", "Rapin", "£32643.37" },
                    { 9, "Support", "jcottem8@fotki.com", "Jacquenetta", "Female", "Cottem", "£20902.55" },
                    { 10, "Accounting", "amullaly9@toplist.cz", "Arny", "Male", "Mullaly", "£53201.85" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
