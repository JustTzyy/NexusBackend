using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacherAvailability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    AvailableDayId = table.Column<int>(type: "int", nullable: false),
                    AvailableTimeSlotId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherAvailabilities_AvailableDays_AvailableDayId",
                        column: x => x.AvailableDayId,
                        principalTable: "AvailableDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherAvailabilities_AvailableTimeSlots_AvailableTimeSlotId",
                        column: x => x.AvailableTimeSlotId,
                        principalTable: "AvailableTimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherAvailabilities_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeacherAvailabilities_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherAvailabilities_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1263), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1263) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1268), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1268) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1272), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1273) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1274), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1274) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1277), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1277) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1279), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1279) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1281), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1281) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1283), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1283) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1285), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1286) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1287), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1287) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1289), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1289) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1316), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1317) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1318), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1319) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1320), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1321) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1322), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1323) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1324), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1325) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1327), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1328) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1329), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1329) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1331), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1331) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1333), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1333) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1335), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1335) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1337), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1337) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1339), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1339) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1341), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1341) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1343), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1343) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1344), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1345) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1346), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1347) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1348), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1349) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1350), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1352), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1352) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1354), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1354) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1356), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1356) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1358), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1359) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1360), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1361) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1362), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1363) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1364), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1364) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1366), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1366) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1368), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1368) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1372), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1372) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1373), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1374) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1375), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1376) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1377), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1378) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1379), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1379) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1381), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1381) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1383), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1383) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1384), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1385) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1386), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1387) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1388), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1388) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1392), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1392) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1394), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1394) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1396), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1396) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1397), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1398) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1399), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1400) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1401), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1401) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1403), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1403) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1405), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1470), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1472), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1472) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1474), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1474) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1476), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1476) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1478), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1478) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1480), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1480) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1482), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1483) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1484), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1485) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1486), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1487) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1488), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1489) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1490), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1491) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1492), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1493) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1494), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1494) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1496), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1496) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1498), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1498) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1500), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1500) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1502), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1502) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1504), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1504) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1505), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1506) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1507), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1508) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1092), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1093) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1095), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1095) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1097), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1097) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1099), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1099) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1101), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1101) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1103), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1103) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1116), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1116) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1118), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1118) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$tXwM/6oZ.cDkr1GlMZwLR.z7wKsY2P05yvVyZb0nmxRPaOGqAUnUa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1811), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1811) });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAvailabilities_AvailableDayId",
                table: "TeacherAvailabilities",
                column: "AvailableDayId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAvailabilities_AvailableTimeSlotId",
                table: "TeacherAvailabilities",
                column: "AvailableTimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAvailabilities_CreatedByUserId",
                table: "TeacherAvailabilities",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAvailabilities_TeacherId",
                table: "TeacherAvailabilities",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAvailabilities_UpdatedByUserId",
                table: "TeacherAvailabilities",
                column: "UpdatedByUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherAvailabilities");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5779), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5779) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5781), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5782) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5783), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5784) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5786), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5786) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5787), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5788) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5790), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5791) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5792), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5793) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5794), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5795) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5796), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5797) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5799), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5799) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5801), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5801) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5803), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5803) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5805), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5805) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5806), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5807) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5808), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5809) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5810), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5810) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5837), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5837) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5840), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5840) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5841), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5842) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5843), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5844) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5845), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5846) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5847), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5847) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5849), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5849) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5851), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5851) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5853), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5853) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5855), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5855) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5857), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5857) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5858), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5859) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5860), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5861) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5862), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5862) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5864), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5864) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5866), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5866) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5868), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5868) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5870), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5870) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5872), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5872) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5874), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5874) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5875), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5876) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5877), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5878) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5879), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5879) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5881), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5881) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5883), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5883) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5885), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5885) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5887), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5887) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5889), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5889) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5891), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5891) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5892), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5893) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5894), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5894) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5896), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5896) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5898), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5898) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5900), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5900) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5901), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5902) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5904), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5904) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5906), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5906) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5908), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5908) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5909), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5910) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5911), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5912) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5913), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5914) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5915), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5915) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5917), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5917) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5919), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5919) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5921), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5922) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5923), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5923) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5925), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5925) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5927), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5927) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5944), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5945) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5947), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5949), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5949) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5951), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5951) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5953), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5953) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5955), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5955) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5957), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5957) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5959), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5959) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5960), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5961) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5962), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5963) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5964), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5965) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5966), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5966) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5968), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5968) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5970), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5970) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5971), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5972) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5621), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5622) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5624), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5624) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5626), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5627) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5628), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5629) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5630), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5632), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5632) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5641), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5641) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5643), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5643) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$G/IDYv7dYbjoM1TsPU/yY.FDT9XdB3PcpOSDtS.JYehb59X9n5E4.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(6256), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(6257) });
        }
    }
}
