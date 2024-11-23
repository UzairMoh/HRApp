using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRApp.Migrations
{
    /// <inheritdoc />
    public partial class TimeOffRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminComments",
                table: "TimeOffRequests",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewedAt",
                table: "TimeOffRequests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewedBy",
                table: "TimeOffRequests",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminComments",
                table: "TimeOffRequests");

            migrationBuilder.DropColumn(
                name: "ReviewedAt",
                table: "TimeOffRequests");

            migrationBuilder.DropColumn(
                name: "ReviewedBy",
                table: "TimeOffRequests");
        }
    }
}
