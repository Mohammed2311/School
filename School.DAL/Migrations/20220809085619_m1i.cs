using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.DAL.Migrations
{
    public partial class m1i : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClass_Classes_ClassId",
                table: "TeacherClass");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClass_Teachers_TeacherId",
                table: "TeacherClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherClass",
                table: "TeacherClass");

            migrationBuilder.RenameTable(
                name: "TeacherClass",
                newName: "TeacherClasses");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherClass_ClassId",
                table: "TeacherClasses",
                newName: "IX_TeacherClasses_ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherClasses",
                table: "TeacherClasses",
                columns: new[] { "TeacherId", "ClassId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClasses_Classes_ClassId",
                table: "TeacherClasses",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClasses_Teachers_TeacherId",
                table: "TeacherClasses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClasses_Classes_ClassId",
                table: "TeacherClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClasses_Teachers_TeacherId",
                table: "TeacherClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherClasses",
                table: "TeacherClasses");

            migrationBuilder.RenameTable(
                name: "TeacherClasses",
                newName: "TeacherClass");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherClasses_ClassId",
                table: "TeacherClass",
                newName: "IX_TeacherClass_ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherClass",
                table: "TeacherClass",
                columns: new[] { "TeacherId", "ClassId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClass_Classes_ClassId",
                table: "TeacherClass",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClass_Teachers_TeacherId",
                table: "TeacherClass",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
