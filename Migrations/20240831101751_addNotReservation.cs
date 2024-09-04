using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MF2024API_2.Migrations
{
    /// <inheritdoc />
    public partial class addNotReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeviceUpdateUser",
                table: "Device",
                newName: "DeviceUpdateUserID");

            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "Status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NotReservationId",
                table: "Nfc",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientCompanyId",
                table: "ClientCompanyEmployees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "NotReservation",
                columns: table => new
                {
                    NotReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotReservationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotReservationRequirement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotReservationCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotReservation", x => x.NotReservationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nfc_NotReservationId",
                table: "Nfc",
                column: "NotReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nfc_NotReservation_NotReservationId",
                table: "Nfc",
                column: "NotReservationId",
                principalTable: "NotReservation",
                principalColumn: "NotReservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nfc_NotReservation_NotReservationId",
                table: "Nfc");

            migrationBuilder.DropTable(
                name: "NotReservation");

            migrationBuilder.DropIndex(
                name: "IX_Nfc_NotReservationId",
                table: "Nfc");

            migrationBuilder.DropColumn(
                name: "NotReservationId",
                table: "Nfc");

            migrationBuilder.RenameColumn(
                name: "DeviceUpdateUserID",
                table: "Device",
                newName: "DeviceUpdateUser");

            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "Status",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ClientCompanyId",
                table: "ClientCompanyEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
