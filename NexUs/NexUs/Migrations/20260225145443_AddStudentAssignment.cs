using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Buildings_PreferredBuildingId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PreferredBuildingId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PreferredBuildingId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "StudentAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    PreferredBuildingId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAssignments_Buildings_PreferredBuildingId",
                        column: x => x.PreferredBuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StudentAssignments_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAssignments_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAssignments_Users_UpdatedBy",
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
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9959), new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9959) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9990), new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9990) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9992), new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9994), new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9995) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9996), new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9997) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9999), new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9999) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(1), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(1) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(3), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(3) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(5), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(5) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(7), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(8) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(9), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(10) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(11), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(12) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(13), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(14) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(15), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(16) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(17), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(18) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(19), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(20) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(21), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(21) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(24), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(24) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(25), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(26) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(27), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(28) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(29), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(30) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(31), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(32) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(33), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(33) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(35), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(35) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(37), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(37) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(39), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(39) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(41), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(41) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(43), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(43) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(44), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(45) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(46), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(47) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(48), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(49) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(50), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(50) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(52), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(52) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(55), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(55) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(57), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(58) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(59), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(60) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(61), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(62) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(63), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(63) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(65), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(65) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(67), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(67) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(69), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(69) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(71), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(71) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(72), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(73) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(74), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(75) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(76), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(76) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(78), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(78) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(80), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(80) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(109), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(110) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(111), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(112) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(114), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(114) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(116), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(116) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(117), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(118) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(120), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(120) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(121), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(122) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(123), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(125), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(126) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(127), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(127) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(129), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(129) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(131), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(131) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(133), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(133) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(135), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(135) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(137), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(137) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(138), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(139) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(140), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(141) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(142), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(143) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(145), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(146) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(148), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(148) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(150), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(150) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(152), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(152) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(154), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(154) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(155), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(156) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(157), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(157) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(159), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(159) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(161), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(161) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(163), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(163) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(164), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(165) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(166), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(167) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(168), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(168) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(170), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(170) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9826), new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9826) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9829), new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9829) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9831), new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9831) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9833), new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9833) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9835), new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9835) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9837), new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9837) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9844), new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9844) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9846), new DateTime(2026, 2, 25, 14, 54, 42, 736, DateTimeKind.Utc).AddTicks(9846) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$l2FZkkJUWiMB6d4NSW1.l.d3ccb.0re/lZav/I9I1JqC78xBlkcQ.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(458), new DateTime(2026, 2, 25, 14, 54, 42, 737, DateTimeKind.Utc).AddTicks(458) });

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignments_CreatedBy",
                table: "StudentAssignments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignments_PreferredBuildingId",
                table: "StudentAssignments",
                column: "PreferredBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignments_StudentId",
                table: "StudentAssignments",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignments_UpdatedBy",
                table: "StudentAssignments",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAssignments");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreferredBuildingId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8261), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8261) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8265), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8266) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8268), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8268) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8270), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8270) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8272), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8272) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8275), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8275) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8277), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8277) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8279), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8279) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8281), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8281) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8284), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8284) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8286), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8286) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8288), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8288) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8290), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8290) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8292), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8292) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8294), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8294) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8296), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8296) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8298), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8298) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8300), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8301) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8302), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8303) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8304), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8305) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8306), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8307) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8308), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8309) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8310), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8311) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8312), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8313) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8314), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8316), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8316) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8318), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8318) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8320), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8320) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8322), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8322) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8324), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8324) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8326), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8326) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8328), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8328) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8330), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8330) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8348), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8349) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8351), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8351) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8353), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8355), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8355) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8357), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8357) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8359), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8359) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8361), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8363), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8363) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8365), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8367), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8367) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8369), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8369) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8371), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8371) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8373), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8375), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8375) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8377), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8377) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8380), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8380) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8381), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8382) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8383), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8384) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8385), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8386) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8387), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8388) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8389), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8389) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8391), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8391) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8393), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8393) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8395), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8397), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8397) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8399), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8399) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8401), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8401) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8403), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8403) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8405), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8405) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8407), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8407) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8409), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8409) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8410), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8411) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8415), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8415) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8417), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8417) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8418), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8419) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8420), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8421) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8422), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8423) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8424), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8425) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8426), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8426) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8428), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8428) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8430), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8432), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8432) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8479), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8479) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8482), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8482) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8484), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8484) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8486), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8486) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8137), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8138) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8140), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8140) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8142), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8142) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8144), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8146), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8146) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8148), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8148) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8157), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8157) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8159), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8159) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$YOimh3V2vVYKnpTISl5yAOI45ZnE/Gxs5lpyLXoyMVTjkQX/oIoya");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Notes", "PreferredBuildingId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8759), null, null, new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PreferredBuildingId",
                table: "Users",
                column: "PreferredBuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Buildings_PreferredBuildingId",
                table: "Users",
                column: "PreferredBuildingId",
                principalTable: "Buildings",
                principalColumn: "Id");
        }
    }
}
