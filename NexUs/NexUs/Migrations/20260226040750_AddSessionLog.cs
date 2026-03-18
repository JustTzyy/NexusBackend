using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddSessionLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SessionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutoringRequestId = table.Column<int>(type: "int", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Outcome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AbsentParty = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionLogs_TutoringRequests_TutoringRequestId",
                        column: x => x.TutoringRequestId,
                        principalTable: "TutoringRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionLogs_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionLogs_Users_UpdatedBy",
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
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1401), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1402) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1411), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1412) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1415), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1415) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1417), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1417) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1419), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1419) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1421), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1422) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1423), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1424) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1426), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1426) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1428), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1428) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1431), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1431) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1433), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1433) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1434), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1435) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1436), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1437) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1439), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1439) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1440), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1441) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1442), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1442) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1444), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1444) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1447), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1448) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1451), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1451) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1453), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1453) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1456), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1456) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1458), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1458) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1460), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1461) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1462), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1462) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1465), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1465) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1467), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1467) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1469), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1469) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1471), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1472) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1473), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1474) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1475), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1476) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1478), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1478) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1481), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1481) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1482), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1483) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1485), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1486) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1489), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1489) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1491), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1491) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1493), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1494) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1495), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1496) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1497), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1498) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1499), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1499) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1501), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1501) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1503), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1503) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1505), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1505) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1506), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1507) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1556), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1557) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1558), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1559) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1560), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1561) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1562), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1563) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1564), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1564) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1566), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1566) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1568), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1568) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1570), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1570) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1572), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1572) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1573), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1574) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1575), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1575) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1577), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1577) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1579), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1579) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1581), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1581) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1583), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1584) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1585), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1586) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1587), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1587) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1589), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1589) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1591), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1591) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1592), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1593) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1594), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1595) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1597), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1597) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1599), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1599) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1600), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1601) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1602), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1603) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1604), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1604) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1606), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1606) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1608), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1608) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1609), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1612), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1613) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1614), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1614) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1616), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1616) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1618), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1618) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1622), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1623) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1624), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1624) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1184), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1185) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1188), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1188) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1191), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1191) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1194), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1195) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1196), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1197) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1199), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1199) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1206), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1207) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1209), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1209) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$5qzSP7CaRIOYIYhohiZcFetp9bxTt.Tane8N8Ooa1WIxh9ys/Z7Ei");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1973), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1973) });

            migrationBuilder.CreateIndex(
                name: "IX_SessionLogs_CreatedBy",
                table: "SessionLogs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SessionLogs_TutoringRequestId",
                table: "SessionLogs",
                column: "TutoringRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionLogs_UpdatedBy",
                table: "SessionLogs",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionLogs");

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
        }
    }
}
