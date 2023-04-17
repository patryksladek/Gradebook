using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gradebook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFkStudentsDepartmentsDepartmentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                schema: "gradebook",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                schema: "gradebook",
                table: "Students",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                schema: "gradebook",
                table: "Students",
                column: "DepartmentId",
                principalSchema: "gradebook",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                schema: "gradebook",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentId",
                schema: "gradebook",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "gradebook",
                table: "Students");
        }
    }
}
