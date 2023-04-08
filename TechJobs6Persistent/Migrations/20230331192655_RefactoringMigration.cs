using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechJobs6Persistent.Migrations
{
    public partial class RefactoringMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_Jobs_JobsJobId",
                table: "JobSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_Skills_SkillsSkillId",
                table: "JobSkills");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "Skills",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SkillsSkillId",
                table: "JobSkills",
                newName: "SkillsId");

            migrationBuilder.RenameColumn(
                name: "JobsJobId",
                table: "JobSkills",
                newName: "JobsId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSkills_SkillsSkillId",
                table: "JobSkills",
                newName: "IX_JobSkills_SkillsId");

            migrationBuilder.RenameColumn(
                name: "JobName",
                table: "Jobs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Jobs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmployerName",
                table: "Employers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EmployerLocation",
                table: "Employers",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "EmployerId",
                table: "Employers",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "SkillName",
                table: "Skills",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_Jobs_JobsId",
                table: "JobSkills",
                column: "JobsId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_Skills_SkillsId",
                table: "JobSkills",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_Jobs_JobsId",
                table: "JobSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_Skills_SkillsId",
                table: "JobSkills");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Skills",
                newName: "SkillId");

            migrationBuilder.RenameColumn(
                name: "SkillsId",
                table: "JobSkills",
                newName: "SkillsSkillId");

            migrationBuilder.RenameColumn(
                name: "JobsId",
                table: "JobSkills",
                newName: "JobsJobId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSkills_SkillsId",
                table: "JobSkills",
                newName: "IX_JobSkills_SkillsSkillId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Jobs",
                newName: "JobName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Jobs",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employers",
                newName: "EmployerName");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Employers",
                newName: "EmployerLocation");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employers",
                newName: "EmployerId");

            migrationBuilder.AlterColumn<string>(
                name: "SkillName",
                table: "Skills",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_Jobs_JobsJobId",
                table: "JobSkills",
                column: "JobsJobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_Skills_SkillsSkillId",
                table: "JobSkills",
                column: "SkillsSkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
