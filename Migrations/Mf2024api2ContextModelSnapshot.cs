﻿// <auto-generated />
using System;
using MF2024API_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MF2024API_2.Migrations
{
    [DbContext(typeof(Mf2024api2Context))]
    partial class Mf2024api2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MF2024API_2.Models.ClientCompany", b =>
                {
                    b.Property<int>("ClientCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientCompanyId"));

                    b.Property<string>("ClientCompanyAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientCompanyEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientCompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientCompanyPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientCompanyId");

                    b.ToTable("ClientCompany", (string)null);
                });

            modelBuilder.Entity("MF2024API_2.Models.ClientCompanyEmployee", b =>
                {
                    b.Property<int>("ClientCompanyEmployeesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientCompanyEmployeesId"));

                    b.Property<string>("ClientCompanyEmployeesEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientCompanyEmployeesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientCompanyEmployeesNameKana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientCompanyEmployeesPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientCompanyEmployeesPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientCompanyEmployeesSection")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClientCompanyId")
                        .HasColumnType("int");

                    b.HasKey("ClientCompanyEmployeesId");

                    b.HasIndex(new[] { "ClientCompanyId" }, "IX_ClientCompanyEmployees_ClientCompanyId");

                    b.ToTable("ClientCompanyEmployees");
                });

            modelBuilder.Entity("MF2024API_2.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanySlakId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfGrantWithPay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FirstDayOfTheCalendarYear")
                        .HasColumnType("datetime2");

                    b.Property<int>("StandardWorkingHours")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("MF2024API_2.Models.ConferenceRoom", b =>
                {
                    b.Property<int>("ConferenceRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConferenceRoomId"));

                    b.Property<int>("ConferenceRoomCapacity")
                        .HasColumnType("int");

                    b.Property<string>("ConferenceRoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ConferenceRoomId");

                    b.HasIndex(new[] { "UpdateUser" }, "IX_ConferenceRoom_UpdateUser");

                    b.ToTable("ConferenceRoom", (string)null);
                });

            modelBuilder.Entity("MF2024API_2.Models.ConferenceRoomReservation", b =>
                {
                    b.Property<int>("ConferenceRoomReservationsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConferenceRoomReservationsId"));

                    b.Property<int>("ConferenceRoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Requirement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ConferenceRoomReservationsId");

                    b.HasIndex(new[] { "ConferenceRoomId" }, "IX_ConferenceRoomReservations_ConferenceRoomId");

                    b.HasIndex(new[] { "UserId" }, "IX_ConferenceRoomReservations_UserId");

                    b.ToTable("ConferenceRoomReservations");
                });

            modelBuilder.Entity("MF2024API_2.Models.ConferenceRoomUse", b =>
                {
                    b.Property<int>("ConferenceRoomUseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConferenceRoomUseId"));

                    b.Property<string>("CompleteFlag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConferenceRoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ConferenceRoomUseId");

                    b.HasIndex(new[] { "ConferenceRoomId" }, "IX_ConferenceRoomUse_ConferenceRoomId");

                    b.HasIndex(new[] { "UserId" }, "IX_ConferenceRoomUse_UserId");

                    b.ToTable("ConferenceRoomUse", (string)null);
                });

            modelBuilder.Entity("MF2024API_2.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentSlackId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("MF2024API_2.Models.Device", b =>
                {
                    b.Property<int>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceId"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceUpdateUserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("DeviceId");

                    b.HasIndex(new[] { "DeviceUpdateUserID" }, "IX_Device_DeviceUpdateUser");

                    b.ToTable("Device", (string)null);
                });

            modelBuilder.Entity("MF2024API_2.Models.EmployeeReservation", b =>
                {
                    b.Property<int>("EmployeeReservationsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeReservationsId"));

                    b.Property<int>("ClientCompanyEmployeesId")
                        .HasColumnType("int");

                    b.Property<string>("CompleteFlag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Qr")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("QR");

                    b.Property<string>("Requirement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationsTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EmployeeReservationsId");

                    b.HasIndex(new[] { "ClientCompanyEmployeesId" }, "IX_EmployeeReservations_ClientCompanyEmployeesId");

                    b.HasIndex(new[] { "UserId" }, "IX_EmployeeReservations_UserId");

                    b.ToTable("EmployeeReservations");
                });

            modelBuilder.Entity("MF2024API_2.Models.EnteringAndLeaving", b =>
                {
                    b.Property<int>("EnteringAndLeavingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnteringAndLeavingId"));

                    b.Property<int>("ClientCompanyEmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("CompleteFlg")
                        .HasColumnType("int");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EnteringAndLeavingAdmissionTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EnteringAndLeavingExitTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("NfcId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EnteringAndLeavingId");

                    b.HasIndex("ClientCompanyEmployeesId");

                    b.HasIndex("NfcId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.HasIndex(new[] { "DeviceId" }, "IX_EnteringAndLeaving_DeviceId");

                    b.ToTable("EnteringAndLeaving", (string)null);
                });

            modelBuilder.Entity("MF2024API_2.Models.Nfc", b =>
                {
                    b.Property<int>("NfcId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NfcId"));

                    b.Property<DateTime>("AlloottedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ClientCompanyEmployeesId")
                        .HasColumnType("int");

                    b.Property<string>("NfcPayload")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NfcUid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NotReservationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NfcId");

                    b.HasIndex("ClientCompanyEmployeesId");

                    b.HasIndex("NotReservationId");

                    b.HasIndex(new[] { "UserId" }, "IX_Nfc_UserId");

                    b.ToTable("Nfc", (string)null);
                });

            modelBuilder.Entity("MF2024API_2.Models.NotReservation", b =>
                {
                    b.Property<int>("NotReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotReservationId"));

                    b.Property<string>("NotReservationCompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotReservationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotReservationRequirement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotReservationId");

                    b.ToTable("NotReservation");
                });

            modelBuilder.Entity("MF2024API_2.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectionId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectionSlackId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectionSlakUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SectionSlakURL");

                    b.HasKey("SectionId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Section", (string)null);
                });

            modelBuilder.Entity("MF2024API_2.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId")
                        .HasName("PK__Status__C8EE20632C92258B");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("MF2024API_2.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UserDateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UserDateOfEntry")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UserDateOfRetirement")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserIndustry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserNameKana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UserPasswoedUpdataTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserSlackId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserSlackUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UserUpdataDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserUpdataUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("MF2024API_2.Models.UserPosition", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserPositionUpdateUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserPosition", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MF2024API_2.Models.ClientCompanyEmployee", b =>
                {
                    b.HasOne("MF2024API_2.Models.ClientCompany", "ClientCompany")
                        .WithMany("ClientCompanyEmployees")
                        .HasForeignKey("ClientCompanyId")
                        .HasConstraintName("FK_ClientCompanyEmployees_ClientCompanyId");

                    b.Navigation("ClientCompany");
                });

            modelBuilder.Entity("MF2024API_2.Models.ConferenceRoom", b =>
                {
                    b.HasOne("MF2024API_2.Models.User", "UpdateUserNavigation")
                        .WithMany("ConferenceRooms")
                        .HasForeignKey("UpdateUser")
                        .IsRequired()
                        .HasConstraintName("FK_ConferenceRoom_UpdateUser");

                    b.Navigation("UpdateUserNavigation");
                });

            modelBuilder.Entity("MF2024API_2.Models.ConferenceRoomReservation", b =>
                {
                    b.HasOne("MF2024API_2.Models.ConferenceRoom", "ConferenceRoom")
                        .WithMany("ConferenceRoomReservations")
                        .HasForeignKey("ConferenceRoomId")
                        .IsRequired()
                        .HasConstraintName("FK_ConferenceRoomReservations_ConferenceRoomId");

                    b.HasOne("MF2024API_2.Models.User", "User")
                        .WithMany("ConferenceRoomReservations")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_ConferenceRoomReservations_UserId");

                    b.Navigation("ConferenceRoom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MF2024API_2.Models.ConferenceRoomUse", b =>
                {
                    b.HasOne("MF2024API_2.Models.ConferenceRoom", "ConferenceRoom")
                        .WithMany("ConferenceRoomUses")
                        .HasForeignKey("ConferenceRoomId")
                        .IsRequired()
                        .HasConstraintName("FK_ConferenceRoomUse_ConferenceRoomId");

                    b.HasOne("MF2024API_2.Models.User", "User")
                        .WithMany("ConferenceRoomUses")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_ConferenceRoomUse_UserId");

                    b.Navigation("ConferenceRoom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MF2024API_2.Models.Device", b =>
                {
                    b.HasOne("MF2024API_2.Models.User", "DeviceUpdateUserNavigation")
                        .WithMany("Devices")
                        .HasForeignKey("DeviceUpdateUserID")
                        .IsRequired()
                        .HasConstraintName("FK_Device_DeviceUpdateUser");

                    b.Navigation("DeviceUpdateUserNavigation");
                });

            modelBuilder.Entity("MF2024API_2.Models.EmployeeReservation", b =>
                {
                    b.HasOne("MF2024API_2.Models.ClientCompanyEmployee", "ClientCompanyEmployees")
                        .WithMany("EmployeeReservations")
                        .HasForeignKey("ClientCompanyEmployeesId")
                        .IsRequired()
                        .HasConstraintName("FK_EmployeeReservations_ClientCompanyEmployeesId");

                    b.HasOne("MF2024API_2.Models.User", "User")
                        .WithMany("EmployeeReservations")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_EmployeeReservations_UserId");

                    b.Navigation("ClientCompanyEmployees");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MF2024API_2.Models.EnteringAndLeaving", b =>
                {
                    b.HasOne("MF2024API_2.Models.ClientCompanyEmployee", "ClientCompanyEmployees")
                        .WithMany("EnteringAndLeavings")
                        .HasForeignKey("ClientCompanyEmployeesId")
                        .IsRequired()
                        .HasConstraintName("FK_EnteringAndLeaving_ClientCompanyEmployeesId");

                    b.HasOne("MF2024API_2.Models.Device", "Device")
                        .WithMany("EnteringAndLeavings")
                        .HasForeignKey("DeviceId")
                        .IsRequired()
                        .HasConstraintName("FK_EnteringAndLeaving_DeviceId");

                    b.HasOne("MF2024API_2.Models.Nfc", "Nfc")
                        .WithMany("EnteringAndLeavings")
                        .HasForeignKey("NfcId")
                        .IsRequired()
                        .HasConstraintName("FK_EnteringAndLeaving_NfcUid");

                    b.HasOne("MF2024API_2.Models.Status", "Status")
                        .WithMany("EnteringAndLeavings")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK_EnteringAndLeaving_StatusId");

                    b.HasOne("MF2024API_2.Models.User", "User")
                        .WithMany("EnteringAndLeavings")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_EnteringAndLeaving_UserId");

                    b.Navigation("ClientCompanyEmployees");

                    b.Navigation("Device");

                    b.Navigation("Nfc");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MF2024API_2.Models.Nfc", b =>
                {
                    b.HasOne("MF2024API_2.Models.ClientCompanyEmployee", "ClientCompanyEmployees")
                        .WithMany("Nfcs")
                        .HasForeignKey("ClientCompanyEmployeesId")
                        .HasConstraintName("FK_Nfc_ClientCompanyEmployeesId");

                    b.HasOne("MF2024API_2.Models.NotReservation", "NotReservation")
                        .WithMany("Nfcs")
                        .HasForeignKey("NotReservationId");

                    b.HasOne("MF2024API_2.Models.User", "User")
                        .WithMany("Nfcs")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Nfc_UserId");

                    b.Navigation("ClientCompanyEmployees");

                    b.Navigation("NotReservation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MF2024API_2.Models.Section", b =>
                {
                    b.HasOne("MF2024API_2.Models.Department", "Department")
                        .WithMany("Sections")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MF2024API_2.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MF2024API_2.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MF2024API_2.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MF2024API_2.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MF2024API_2.Models.ClientCompany", b =>
                {
                    b.Navigation("ClientCompanyEmployees");
                });

            modelBuilder.Entity("MF2024API_2.Models.ClientCompanyEmployee", b =>
                {
                    b.Navigation("EmployeeReservations");

                    b.Navigation("EnteringAndLeavings");

                    b.Navigation("Nfcs");
                });

            modelBuilder.Entity("MF2024API_2.Models.ConferenceRoom", b =>
                {
                    b.Navigation("ConferenceRoomReservations");

                    b.Navigation("ConferenceRoomUses");
                });

            modelBuilder.Entity("MF2024API_2.Models.Department", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("MF2024API_2.Models.Device", b =>
                {
                    b.Navigation("EnteringAndLeavings");
                });

            modelBuilder.Entity("MF2024API_2.Models.Nfc", b =>
                {
                    b.Navigation("EnteringAndLeavings");
                });

            modelBuilder.Entity("MF2024API_2.Models.NotReservation", b =>
                {
                    b.Navigation("Nfcs");
                });

            modelBuilder.Entity("MF2024API_2.Models.Status", b =>
                {
                    b.Navigation("EnteringAndLeavings");
                });

            modelBuilder.Entity("MF2024API_2.Models.User", b =>
                {
                    b.Navigation("ConferenceRoomReservations");

                    b.Navigation("ConferenceRoomUses");

                    b.Navigation("ConferenceRooms");

                    b.Navigation("Devices");

                    b.Navigation("EmployeeReservations");

                    b.Navigation("EnteringAndLeavings");

                    b.Navigation("Nfcs");
                });
#pragma warning restore 612, 618
        }
    }
}
