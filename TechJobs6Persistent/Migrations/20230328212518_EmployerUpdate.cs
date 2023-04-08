using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechJobs6Persistent.Migrations
{
    public partial class EmployerUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employers",
                newName: "EmployerName");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Employers",
                newName: "EmployerLocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployerName",
                table: "Employers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EmployerLocation",
                table: "Employers",
                newName: "Location");
        }
    }
}
