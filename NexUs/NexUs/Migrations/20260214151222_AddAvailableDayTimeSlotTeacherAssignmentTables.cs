using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddAvailableDayTimeSlotTeacherAssignmentTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableDays_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvailableDays_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvailableTimeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableTimeSlots_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvailableTimeSlots_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherAssignments_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherAssignments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherAssignments_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherAssignments_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherAssignments_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4085), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4085) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4088), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4088) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4090), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4092), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4092) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4094), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4094) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4097), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4099), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4099) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4101), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4101) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4103), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4103) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4105), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4106) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4107), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4108) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4109), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4110) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4111), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4112) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4113), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4113) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4115), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4115) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4117), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4117) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4119), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4119) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4121), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4121) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4123), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4123) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4125), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4125) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4127), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4127) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4128), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4129) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4130), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4131) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4132), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4132) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4134), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4134) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4136), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4136) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4138), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4138) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4140), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4141), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4142) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4143), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4144) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4145), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4180), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4181) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4182), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4183) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4185), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4186) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4187), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4188) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4189), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4189) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4191), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4191) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4193), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4195), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4195) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4197), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4197) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4199), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4199) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4201), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4201) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4202), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4203) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4204), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4205) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4206), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4206) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4208), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4208) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4210), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4212), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4212) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4214), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4214) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4215), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4217), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4218) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 52, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4219), null, null, "View available day list and details", "AvailableDays", "ViewAvailableDays", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4219), null },
                    { 53, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4221), null, null, "Create new available days", "AvailableDays", "CreateAvailableDays", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4221), null },
                    { 54, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4223), null, null, "Update existing available days", "AvailableDays", "UpdateAvailableDays", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4223), null },
                    { 55, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4225), null, null, "Delete available days", "AvailableDays", "DeleteAvailableDays", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4225), null },
                    { 56, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4226), null, null, "Archive (soft delete) available days", "AvailableDays", "ArchiveAvailableDays", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4227), null },
                    { 57, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4228), null, null, "Restore archived available days", "AvailableDays", "RestoreAvailableDays", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4229), null },
                    { 58, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4230), null, null, "Permanently delete available days", "AvailableDays", "PermanentDeleteAvailableDays", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4230), null },
                    { 59, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4232), null, null, "View time slot list and details", "AvailableTimeSlots", "ViewAvailableTimeSlots", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4232), null },
                    { 60, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4234), null, null, "Create new time slots", "AvailableTimeSlots", "CreateAvailableTimeSlots", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4234), null },
                    { 61, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4236), null, null, "Update existing time slots", "AvailableTimeSlots", "UpdateAvailableTimeSlots", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4236), null },
                    { 62, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4237), null, null, "Delete time slots", "AvailableTimeSlots", "DeleteAvailableTimeSlots", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4238), null },
                    { 63, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4239), null, null, "Archive (soft delete) time slots", "AvailableTimeSlots", "ArchiveAvailableTimeSlots", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4240), null },
                    { 64, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4241), null, null, "Restore archived time slots", "AvailableTimeSlots", "RestoreAvailableTimeSlots", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4241), null },
                    { 65, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4243), null, null, "Permanently delete time slots", "AvailableTimeSlots", "PermanentDeleteAvailableTimeSlots", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4243), null },
                    { 66, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4246), null, null, "View teacher assignment list and details", "TeacherAssignments", "ViewTeacherAssignments", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4246), null },
                    { 67, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4248), null, null, "Create new teacher assignments", "TeacherAssignments", "CreateTeacherAssignments", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4248), null },
                    { 68, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4250), null, null, "Update existing teacher assignments", "TeacherAssignments", "UpdateTeacherAssignments", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4250), null },
                    { 69, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4251), null, null, "Delete teacher assignments", "TeacherAssignments", "DeleteTeacherAssignments", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4252), null },
                    { 70, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4253), null, null, "Archive (soft delete) teacher assignments", "TeacherAssignments", "ArchiveTeacherAssignments", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4254), null },
                    { 71, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4255), null, null, "Restore archived teacher assignments", "TeacherAssignments", "RestoreTeacherAssignments", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4255), null },
                    { 72, new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4257), null, null, "Permanently delete teacher assignments", "TeacherAssignments", "PermanentDeleteTeacherAssignments", new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4257), null }
                });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 52, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 53, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 54, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 55, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 56, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 57, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 58, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 59, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 60, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 61, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 62, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 63, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 64, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 65, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 66, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 67, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 68, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 69, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 70, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 71, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 72, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 73,
                column: "PermissionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 74,
                column: "PermissionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 75,
                column: "PermissionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 76,
                column: "PermissionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 77,
                column: "PermissionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 78,
                column: "PermissionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 79,
                column: "PermissionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 80,
                column: "PermissionId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 81,
                column: "PermissionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 82,
                column: "PermissionId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 83,
                column: "PermissionId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 84,
                column: "PermissionId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 85,
                column: "PermissionId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 86,
                column: "PermissionId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 87,
                column: "PermissionId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 88,
                column: "PermissionId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 89,
                column: "PermissionId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 90,
                column: "PermissionId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 91,
                column: "PermissionId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 92,
                column: "PermissionId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 93,
                column: "PermissionId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 94,
                column: "PermissionId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 95,
                column: "PermissionId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 96,
                column: "PermissionId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 97,
                column: "PermissionId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 98,
                column: "PermissionId",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 99,
                column: "PermissionId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 100,
                column: "PermissionId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 101,
                column: "PermissionId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 102,
                column: "PermissionId",
                value: 30);

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 103, 31, 2 },
                    { 104, 32, 2 },
                    { 105, 33, 2 },
                    { 106, 34, 2 },
                    { 107, 35, 2 },
                    { 108, 36, 2 },
                    { 109, 37, 2 },
                    { 110, 38, 2 },
                    { 111, 39, 2 },
                    { 112, 40, 2 },
                    { 113, 41, 2 },
                    { 114, 42, 2 },
                    { 115, 43, 2 },
                    { 116, 44, 2 },
                    { 117, 45, 2 },
                    { 118, 46, 2 },
                    { 119, 47, 2 },
                    { 120, 48, 2 },
                    { 121, 49, 2 },
                    { 122, 50, 2 },
                    { 123, 51, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3945), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3946) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3948), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3949) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3951) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3952), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3953) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3954), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3955) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3956), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3956) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3962), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3962) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3964), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(3964) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$Cjd6xNHItG7R0TRWAGTlYO2K9rw1Y5y3fvwaLeKwGhUiW7T2CMUBG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4521), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4521) });

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 124, 52, 2 },
                    { 125, 53, 2 },
                    { 126, 54, 2 },
                    { 127, 55, 2 },
                    { 128, 56, 2 },
                    { 129, 57, 2 },
                    { 130, 58, 2 },
                    { 131, 59, 2 },
                    { 132, 60, 2 },
                    { 133, 61, 2 },
                    { 134, 62, 2 },
                    { 135, 63, 2 },
                    { 136, 64, 2 },
                    { 137, 65, 2 },
                    { 138, 66, 2 },
                    { 139, 67, 2 },
                    { 140, 68, 2 },
                    { 141, 69, 2 },
                    { 142, 70, 2 },
                    { 143, 71, 2 },
                    { 144, 72, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableDays_CreatedBy",
                table: "AvailableDays",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableDays_UpdatedBy",
                table: "AvailableDays",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTimeSlots_CreatedBy",
                table: "AvailableTimeSlots",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTimeSlots_UpdatedBy",
                table: "AvailableTimeSlots",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAssignments_BuildingId",
                table: "TeacherAssignments",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAssignments_CreatedBy",
                table: "TeacherAssignments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAssignments_DepartmentId",
                table: "TeacherAssignments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAssignments_TeacherId",
                table: "TeacherAssignments",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAssignments_UpdatedBy",
                table: "TeacherAssignments",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableDays");

            migrationBuilder.DropTable(
                name: "AvailableTimeSlots");

            migrationBuilder.DropTable(
                name: "TeacherAssignments");

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7177), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7177) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7186), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7187) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7188), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7189) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7190), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7191) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7192), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7193) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7195), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7195) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7197), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7197) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7199), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7199) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7200), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7201) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7203), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7203) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7205), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7205) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7206), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7207) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7208), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7209) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7210), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7212), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7212) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7214), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7214) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7215), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7216) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7239), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7241), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7242) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7243), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7244) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7246) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7247), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7248) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7249), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7249) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7251), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7251) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7253), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7253) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7255), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7255) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7256), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7257) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7258), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7259) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7261), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7261) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7263), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7263) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7264), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7265) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7266), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7267) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7268), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7268) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7270), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7271) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7272), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7273) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7274), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7274) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7276), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7276) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7278), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7278) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7279), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7281), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7281) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7283), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7283) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7285), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7285) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7286), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7287) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7288), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7289) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7290), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7290) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7292), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7292) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7294), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7294) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7295), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7296) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7297), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7297) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7299), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7299) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7301), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7301) });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 4, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 5, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 6, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 7, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 8, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 9, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 10, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 11, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 12, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 13, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 14, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 15, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 16, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 17, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 18, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 19, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 20, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 21, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 73,
                column: "PermissionId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 74,
                column: "PermissionId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 75,
                column: "PermissionId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 76,
                column: "PermissionId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 77,
                column: "PermissionId",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 78,
                column: "PermissionId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 79,
                column: "PermissionId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 80,
                column: "PermissionId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 81,
                column: "PermissionId",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 82,
                column: "PermissionId",
                value: 31);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 83,
                column: "PermissionId",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 84,
                column: "PermissionId",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 85,
                column: "PermissionId",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 86,
                column: "PermissionId",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 87,
                column: "PermissionId",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 88,
                column: "PermissionId",
                value: 37);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 89,
                column: "PermissionId",
                value: 38);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 90,
                column: "PermissionId",
                value: 39);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 91,
                column: "PermissionId",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 92,
                column: "PermissionId",
                value: 41);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 93,
                column: "PermissionId",
                value: 42);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 94,
                column: "PermissionId",
                value: 43);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 95,
                column: "PermissionId",
                value: 44);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 96,
                column: "PermissionId",
                value: 45);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 97,
                column: "PermissionId",
                value: 46);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 98,
                column: "PermissionId",
                value: 47);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 99,
                column: "PermissionId",
                value: 48);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 100,
                column: "PermissionId",
                value: 49);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 101,
                column: "PermissionId",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 102,
                column: "PermissionId",
                value: 51);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7041), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7041) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7044), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7044) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7046), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7046) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7048), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7048) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7050), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7050) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7052), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7052) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7058), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7059) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7060), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7060) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$b2gnxSH6qGyjmQke4Vst7eXBOrotSz6yyryl/325U7T61CkOnanBm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7537), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7538) });
        }
    }
}
