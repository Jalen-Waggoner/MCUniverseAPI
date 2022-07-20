using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCUniverse.Data.Migrations
{
    public partial class Student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEntityStudent_Student_StudentsId",
                table: "CourseEntityStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEntityStudent_Students_StudentsId",
                table: "CourseEntityStudent",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEntityStudent_Students_StudentsId",
                table: "CourseEntityStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEntityStudent_Student_StudentsId",
                table: "CourseEntityStudent",
                column: "StudentsId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
