using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MF2024API_2.Migrations
{
    /// <inheritdoc />
    public partial class new1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientCompanyEmployeesId",
                table: "EnteringAndLeaving",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "EnteringAndLeaving",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_EnteringAndLeaving_ClientCompanyEmployeesId",
                table: "EnteringAndLeaving",
                column: "ClientCompanyEmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_EnteringAndLeaving_UserId",
                table: "EnteringAndLeaving",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnteringAndLeaving_ClientCompanyEmployeesId",
                table: "EnteringAndLeaving",
                column: "ClientCompanyEmployeesId",
                principalTable: "ClientCompanyEmployees",
                principalColumn: "ClientCompanyEmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnteringAndLeaving_UserId",
                table: "EnteringAndLeaving",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnteringAndLeaving_ClientCompanyEmployeesId",
                table: "EnteringAndLeaving");

            migrationBuilder.DropForeignKey(
                name: "FK_EnteringAndLeaving_UserId",
                table: "EnteringAndLeaving");

            migrationBuilder.DropIndex(
                name: "IX_EnteringAndLeaving_ClientCompanyEmployeesId",
                table: "EnteringAndLeaving");

            migrationBuilder.DropIndex(
                name: "IX_EnteringAndLeaving_UserId",
                table: "EnteringAndLeaving");

            migrationBuilder.DropColumn(
                name: "ClientCompanyEmployeesId",
                table: "EnteringAndLeaving");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EnteringAndLeaving");
        }
    }
}
