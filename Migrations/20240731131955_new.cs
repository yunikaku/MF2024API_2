using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MF2024API_2.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserSlackId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserSlackUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPasswoedUpdataTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserNameKana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserIndustry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDateOfEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserDateOfRetirement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdataDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdataUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientCompany",
                columns: table => new
                {
                    ClientCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientCompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientCompanyPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientCompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCompany", x => x.ClientCompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanySlakId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandardWorkingHours = table.Column<int>(type: "int", nullable: false),
                    DateOfGrantWithPay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstDayOfTheCalendarYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionSlackId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionSlakURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.SectionId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Status__C8EE20632C92258B", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "UserPosition",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserPositionUpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPosition", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConferenceRoom",
                columns: table => new
                {
                    ConferenceRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConferenceRoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConferenceRoomCapacity = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceRoom", x => x.ConferenceRoomId);
                    table.ForeignKey(
                        name: "FK_ConferenceRoom_UpdateUser",
                        column: x => x.UpdateUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceUpdateUser = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.DeviceId);
                    table.ForeignKey(
                        name: "FK_Device_DeviceUpdateUser",
                        column: x => x.DeviceUpdateUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClientCompanyEmployees",
                columns: table => new
                {
                    ClientCompanyEmployeesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCompanyId = table.Column<int>(type: "int", nullable: false),
                    ClientCompanyEmployeesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientCompanyEmployeesNameKana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientCompanyEmployeesEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientCompanyEmployeesPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientCompanyEmployeesSection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientCompanyEmployeesPosition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCompanyEmployees", x => x.ClientCompanyEmployeesId);
                    table.ForeignKey(
                        name: "FK_ClientCompanyEmployees_ClientCompanyId",
                        column: x => x.ClientCompanyId,
                        principalTable: "ClientCompany",
                        principalColumn: "ClientCompanyId");
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentSlackId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Department_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "SectionId");
                });

            migrationBuilder.CreateTable(
                name: "ConferenceRoomReservations",
                columns: table => new
                {
                    ConferenceRoomReservationsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConferenceRoomId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Requirement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceRoomReservations", x => x.ConferenceRoomReservationsId);
                    table.ForeignKey(
                        name: "FK_ConferenceRoomReservations_ConferenceRoomId",
                        column: x => x.ConferenceRoomId,
                        principalTable: "ConferenceRoom",
                        principalColumn: "ConferenceRoomId");
                    table.ForeignKey(
                        name: "FK_ConferenceRoomReservations_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConferenceRoomUse",
                columns: table => new
                {
                    ConferenceRoomUseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConferenceRoomId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompleteFlag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceRoomUse", x => x.ConferenceRoomUseId);
                    table.ForeignKey(
                        name: "FK_ConferenceRoomUse_ConferenceRoomId",
                        column: x => x.ConferenceRoomId,
                        principalTable: "ConferenceRoom",
                        principalColumn: "ConferenceRoomId");
                    table.ForeignKey(
                        name: "FK_ConferenceRoomUse_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeReservations",
                columns: table => new
                {
                    EmployeeReservationsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientCompanyEmployeesId = table.Column<int>(type: "int", nullable: false),
                    ReservationsTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QR = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CompleteFlag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requirement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeReservations", x => x.EmployeeReservationsId);
                    table.ForeignKey(
                        name: "FK_EmployeeReservations_ClientCompanyEmployeesId",
                        column: x => x.ClientCompanyEmployeesId,
                        principalTable: "ClientCompanyEmployees",
                        principalColumn: "ClientCompanyEmployeesId");
                    table.ForeignKey(
                        name: "FK_EmployeeReservations_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nfc",
                columns: table => new
                {
                    NfcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NfcUid = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AlloottedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NfcPayload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientCompanyEmployeesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nfc", x => x.NfcId);
                    table.ForeignKey(
                        name: "FK_Nfc_ClientCompanyEmployeesId",
                        column: x => x.ClientCompanyEmployeesId,
                        principalTable: "ClientCompanyEmployees",
                        principalColumn: "ClientCompanyEmployeesId");
                    table.ForeignKey(
                        name: "FK_Nfc_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EnteringAndLeaving",
                columns: table => new
                {
                    EnteringAndLeavingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnteringAndLeavingAdmissionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    NfcId = table.Column<int>(type: "int", nullable: false),
                    CompleteFlg = table.Column<int>(type: "int", nullable: false),
                    EnteringAndLeavingExitTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnteringAndLeaving", x => x.EnteringAndLeavingId);
                    table.ForeignKey(
                        name: "FK_EnteringAndLeaving_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "DeviceId");
                    table.ForeignKey(
                        name: "FK_EnteringAndLeaving_NfcUid",
                        column: x => x.NfcId,
                        principalTable: "Nfc",
                        principalColumn: "NfcId");
                    table.ForeignKey(
                        name: "FK_EnteringAndLeaving_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCompanyEmployees_ClientCompanyId",
                table: "ClientCompanyEmployees",
                column: "ClientCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceRoom_UpdateUser",
                table: "ConferenceRoom",
                column: "UpdateUser");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceRoomReservations_ConferenceRoomId",
                table: "ConferenceRoomReservations",
                column: "ConferenceRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceRoomReservations_UserId",
                table: "ConferenceRoomReservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceRoomUse_ConferenceRoomId",
                table: "ConferenceRoomUse",
                column: "ConferenceRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceRoomUse_UserId",
                table: "ConferenceRoomUse",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_SectionId",
                table: "Department",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_DeviceUpdateUser",
                table: "Device",
                column: "DeviceUpdateUser");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeReservations_ClientCompanyEmployeesId",
                table: "EmployeeReservations",
                column: "ClientCompanyEmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeReservations_UserId",
                table: "EmployeeReservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EnteringAndLeaving_DeviceId",
                table: "EnteringAndLeaving",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_EnteringAndLeaving_NfcId",
                table: "EnteringAndLeaving",
                column: "NfcId");

            migrationBuilder.CreateIndex(
                name: "IX_EnteringAndLeaving_StatusId",
                table: "EnteringAndLeaving",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Nfc_ClientCompanyEmployeesId",
                table: "Nfc",
                column: "ClientCompanyEmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Nfc_UserId",
                table: "Nfc",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "ConferenceRoomReservations");

            migrationBuilder.DropTable(
                name: "ConferenceRoomUse");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "EmployeeReservations");

            migrationBuilder.DropTable(
                name: "EnteringAndLeaving");

            migrationBuilder.DropTable(
                name: "UserPosition");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ConferenceRoom");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "Nfc");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "ClientCompanyEmployees");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ClientCompany");
        }
    }
}
