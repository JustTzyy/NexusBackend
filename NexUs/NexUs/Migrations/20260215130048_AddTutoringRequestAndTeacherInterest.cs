using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddTutoringRequestAndTeacherInterest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TutoringRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AssignedTeacherId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    AvailableDayId = table.Column<int>(type: "int", nullable: true),
                    AvailableTimeSlotId = table.Column<int>(type: "int", nullable: true),
                    ScheduledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelledBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutoringRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TutoringRequests_AvailableDays_AvailableDayId",
                        column: x => x.AvailableDayId,
                        principalTable: "AvailableDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TutoringRequests_AvailableTimeSlots_AvailableTimeSlotId",
                        column: x => x.AvailableTimeSlotId,
                        principalTable: "AvailableTimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TutoringRequests_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TutoringRequests_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TutoringRequests_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TutoringRequests_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TutoringRequests_Users_AssignedTeacherId",
                        column: x => x.AssignedTeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TutoringRequests_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TutoringRequests_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TutoringRequests_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherInterests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutoringRequestId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherInterests_TutoringRequests_TutoringRequestId",
                        column: x => x.TutoringRequestId,
                        principalTable: "TutoringRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherInterests_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherInterests_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherInterests_Users_UpdatedBy",
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
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4028), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4028) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4032), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4032) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4034), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4035) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4037), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4037) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4039), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4039) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4042), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4042) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4044), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4044) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4046), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4047) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4049), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4049) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4052), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4052) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4054), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4054) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4056), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4057) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4059), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4059) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4061), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4061) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4063), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4064) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4065), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4066) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4068), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4068) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4071), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4071) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4073), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4073) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4140), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4142), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4143) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4144), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4147), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4147) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4149), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4149) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4151), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4151) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4153), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4154) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4155), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4156) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4157), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4158) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4159), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4162), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4162) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4164), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4164) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4166), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4166) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4168), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4168) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4173), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4174) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4177), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4177) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4179), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4179) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4181), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4181) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4183), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4183) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4184), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4185) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4186), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4187) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4188), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4189) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4190), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4190) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4192), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4192) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4194), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4194) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4196), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4196) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4197), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4198) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4199), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4200) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4201), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4202) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4203), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4203) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4205), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4205) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4209), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4211), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4211) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4213), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4213) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4214), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4215) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4216), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4217) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4218), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4220), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4221) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4222), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4223) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4224), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4225) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4226), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4226) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4228), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4228) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4230), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4232), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4232) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4234), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4236), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4236) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4301), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4301) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4304), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4304) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4306), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4307) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4308), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4309) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4310), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4312), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4312) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4314), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4314) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 73, new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4316), null, null, "View tutoring request list and details", "TutoringRequests", "ViewTutoringRequests", new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4316), null },
                    { 74, new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4318), null, null, "Create new tutoring requests", "TutoringRequests", "CreateTutoringRequests", new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4318), null },
                    { 75, new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4320), null, null, "Update existing tutoring requests", "TutoringRequests", "UpdateTutoringRequests", new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4320), null },
                    { 76, new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4322), null, null, "Delete tutoring requests", "TutoringRequests", "DeleteTutoringRequests", new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4322), null },
                    { 77, new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4324), null, null, "Archive (soft delete) tutoring requests", "TutoringRequests", "ArchiveTutoringRequests", new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4324), null },
                    { 78, new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4326), null, null, "Restore archived tutoring requests", "TutoringRequests", "RestoreTutoringRequests", new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4326), null },
                    { 79, new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4328), null, null, "Permanently delete tutoring requests", "TutoringRequests", "PermanentDeleteTutoringRequests", new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4328), null }
                });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 73, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 74, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 75, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 76, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 77, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 78, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 79, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 80,
                column: "PermissionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 81,
                column: "PermissionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 82,
                column: "PermissionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 83,
                column: "PermissionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 84,
                column: "PermissionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 85,
                column: "PermissionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 86,
                column: "PermissionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 87,
                column: "PermissionId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 88,
                column: "PermissionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 89,
                column: "PermissionId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 90,
                column: "PermissionId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 91,
                column: "PermissionId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 92,
                column: "PermissionId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 93,
                column: "PermissionId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 94,
                column: "PermissionId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 95,
                column: "PermissionId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 96,
                column: "PermissionId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 97,
                column: "PermissionId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 98,
                column: "PermissionId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 99,
                column: "PermissionId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 100,
                column: "PermissionId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 101,
                column: "PermissionId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 102,
                column: "PermissionId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 103,
                column: "PermissionId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 104,
                column: "PermissionId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 105,
                column: "PermissionId",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 106,
                column: "PermissionId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 107,
                column: "PermissionId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 108,
                column: "PermissionId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 109,
                column: "PermissionId",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 110,
                column: "PermissionId",
                value: 31);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 111,
                column: "PermissionId",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 112,
                column: "PermissionId",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 113,
                column: "PermissionId",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 114,
                column: "PermissionId",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 115,
                column: "PermissionId",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 116,
                column: "PermissionId",
                value: 37);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 117,
                column: "PermissionId",
                value: 38);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 118,
                column: "PermissionId",
                value: 39);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 119,
                column: "PermissionId",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 120,
                column: "PermissionId",
                value: 41);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 121,
                column: "PermissionId",
                value: 42);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 122,
                column: "PermissionId",
                value: 43);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 123,
                column: "PermissionId",
                value: 44);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 124,
                column: "PermissionId",
                value: 45);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 125,
                column: "PermissionId",
                value: 46);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 126,
                column: "PermissionId",
                value: 47);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 127,
                column: "PermissionId",
                value: 48);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 128,
                column: "PermissionId",
                value: 49);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 129,
                column: "PermissionId",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 130,
                column: "PermissionId",
                value: 51);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 131,
                column: "PermissionId",
                value: 52);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 132,
                column: "PermissionId",
                value: 53);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 133,
                column: "PermissionId",
                value: 54);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 134,
                column: "PermissionId",
                value: 55);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 135,
                column: "PermissionId",
                value: 56);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 136,
                column: "PermissionId",
                value: 57);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 137,
                column: "PermissionId",
                value: 58);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 138,
                column: "PermissionId",
                value: 59);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 139,
                column: "PermissionId",
                value: 60);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 140,
                column: "PermissionId",
                value: 61);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 141,
                column: "PermissionId",
                value: 62);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 142,
                column: "PermissionId",
                value: 63);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 143,
                column: "PermissionId",
                value: 64);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 144,
                column: "PermissionId",
                value: 65);

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 145, 66, 2 },
                    { 146, 67, 2 },
                    { 147, 68, 2 },
                    { 148, 69, 2 },
                    { 149, 70, 2 },
                    { 150, 71, 2 },
                    { 151, 72, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3847), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3847) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3849), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3851), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3852) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3853), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3854) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3855), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3855) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3857), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3857) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3866), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3866) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3868), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3868) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$e5eveTjDJbCWvrtXfnGm6.0NX8H1Ir37F79UBBZUW4bTtp974drCi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4705), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4706) });

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 152, 73, 2 },
                    { 153, 74, 2 },
                    { 154, 75, 2 },
                    { 155, 76, 2 },
                    { 156, 77, 2 },
                    { 157, 78, 2 },
                    { 158, 79, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherInterests_CreatedBy",
                table: "TeacherInterests",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherInterests_TeacherId",
                table: "TeacherInterests",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherInterests_TutoringRequestId",
                table: "TeacherInterests",
                column: "TutoringRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherInterests_UpdatedBy",
                table: "TeacherInterests",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringRequests_AssignedTeacherId",
                table: "TutoringRequests",
                column: "AssignedTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringRequests_AvailableDayId",
                table: "TutoringRequests",
                column: "AvailableDayId");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringRequests_AvailableTimeSlotId",
                table: "TutoringRequests",
                column: "AvailableTimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringRequests_BuildingId",
                table: "TutoringRequests",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringRequests_CreatedBy",
                table: "TutoringRequests",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringRequests_DepartmentId",
                table: "TutoringRequests",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringRequests_RoomId",
                table: "TutoringRequests",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringRequests_StudentId",
                table: "TutoringRequests",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringRequests_SubjectId",
                table: "TutoringRequests",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringRequests_UpdatedBy",
                table: "TutoringRequests",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherInterests");

            migrationBuilder.DropTable(
                name: "TutoringRequests");

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79);

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

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4219), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4221), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4221) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4223), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4223) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4225), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4225) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4226), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4227) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4228), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4229) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4230), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4232), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4232) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4234), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4236), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4236) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4237), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4238) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4239), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4240) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4241), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4241) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4243), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4243) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4246), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4246) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4248), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4248) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4250), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4251), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4252) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4253), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4254) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4255), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4255) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4257), new DateTime(2026, 2, 14, 15, 12, 21, 243, DateTimeKind.Utc).AddTicks(4257) });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 4, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 5, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 6, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 7, 2 });

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

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 103,
                column: "PermissionId",
                value: 31);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 104,
                column: "PermissionId",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 105,
                column: "PermissionId",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 106,
                column: "PermissionId",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 107,
                column: "PermissionId",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 108,
                column: "PermissionId",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 109,
                column: "PermissionId",
                value: 37);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 110,
                column: "PermissionId",
                value: 38);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 111,
                column: "PermissionId",
                value: 39);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 112,
                column: "PermissionId",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 113,
                column: "PermissionId",
                value: 41);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 114,
                column: "PermissionId",
                value: 42);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 115,
                column: "PermissionId",
                value: 43);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 116,
                column: "PermissionId",
                value: 44);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 117,
                column: "PermissionId",
                value: 45);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 118,
                column: "PermissionId",
                value: 46);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 119,
                column: "PermissionId",
                value: 47);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 120,
                column: "PermissionId",
                value: 48);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 121,
                column: "PermissionId",
                value: 49);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 122,
                column: "PermissionId",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 123,
                column: "PermissionId",
                value: 51);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 124,
                column: "PermissionId",
                value: 52);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 125,
                column: "PermissionId",
                value: 53);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 126,
                column: "PermissionId",
                value: 54);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 127,
                column: "PermissionId",
                value: 55);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 128,
                column: "PermissionId",
                value: 56);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 129,
                column: "PermissionId",
                value: 57);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 130,
                column: "PermissionId",
                value: 58);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 131,
                column: "PermissionId",
                value: 59);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 132,
                column: "PermissionId",
                value: 60);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 133,
                column: "PermissionId",
                value: 61);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 134,
                column: "PermissionId",
                value: 62);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 135,
                column: "PermissionId",
                value: 63);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 136,
                column: "PermissionId",
                value: 64);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 137,
                column: "PermissionId",
                value: 65);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 138,
                column: "PermissionId",
                value: 66);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 139,
                column: "PermissionId",
                value: 67);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 140,
                column: "PermissionId",
                value: 68);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 141,
                column: "PermissionId",
                value: 69);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 142,
                column: "PermissionId",
                value: 70);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 143,
                column: "PermissionId",
                value: 71);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 144,
                column: "PermissionId",
                value: 72);

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
        }
    }
}
