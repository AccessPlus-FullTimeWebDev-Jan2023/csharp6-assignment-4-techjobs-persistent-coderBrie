using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechJobs6Persistent.Migrations
{
    public partial class refactorSkillsAndJobMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_Jobs_JobsId",
                table: "JobSkills");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Skills",
                newName: "SkillName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Skills",
                newName: "SkillDescription");

            migrationBuilder.RenameColumn(
                name: "JobsId",
                table: "JobSkills",
                newName: "JobsJobId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Jobs",
                newName: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_Jobs_JobsJobId",
                table: "JobSkills",
                column: "JobsJobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_Jobs_JobsJobId",
                table: "JobSkills");

            migrationBuilder.RenameColumn(
                name: "SkillName",
                table: "Skills",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SkillDescription",
                table: "Skills",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "JobsJobId",
                table: "JobSkills",
                newName: "JobsId");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Jobs",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_Jobs_JobsId",
                table: "JobSkills",
                column: "JobsId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
