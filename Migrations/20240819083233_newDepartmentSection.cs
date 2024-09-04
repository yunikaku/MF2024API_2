using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MF2024API_2.Migrations
{
    /// <inheritdoc />
    public partial class newDepartmentSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_SectionId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_SectionId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Department");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Section",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Section_DepartmentId",
                table: "Section",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Department_DepartmentId",
                table: "Section",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_Department_DepartmentId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Section_DepartmentId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Section");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Department_SectionId",
                table: "Department",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_SectionId",
                table: "Department",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "SectionId");
        }
    }
}
