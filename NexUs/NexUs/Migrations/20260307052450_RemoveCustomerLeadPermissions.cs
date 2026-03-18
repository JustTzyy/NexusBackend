using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCustomerLeadPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Safety: delete any Role_Permissions for Customer (7) and Lead (8) regardless of Id
            migrationBuilder.Sql("DELETE FROM [Role_Permissions] WHERE RoleId IN (7, 8)");

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1651), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1651) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1662), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1663) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1664), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1665) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1667), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1667) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1668), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1669) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1671), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1671) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1673), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1673) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1675), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1675) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1676), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1677) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1679), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1679) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1681), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1681) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1683), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1683) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1684), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1686), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1687) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1688), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1688) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1690), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1690) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1692), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1693) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1695), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1695) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1697), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1697) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1698), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1699) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1700), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1701) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1702), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1702) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1704), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1704) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1706), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1706) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1708), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1708) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1709), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1710) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1711), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1712) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1713), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1713) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1715), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1715) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1717), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1717) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1719), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1719) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1720), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1721) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1723), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1723) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1726), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1726) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1727), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1728) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1729), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1729) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1731), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1731) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1733), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1733) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1734), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1735) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1736), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1737) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1738), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1738) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1740), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1778), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1779) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1780), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1781) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1782), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1782) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1784), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1784) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1786), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1786) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1788), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1788) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1789), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1790) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1791), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1792) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1793), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1793) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1795), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1795) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1797), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1797) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1798), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1799) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1800), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1800) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1802), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1802) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1804), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1804) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1805), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1806) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1807), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1807) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1809), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1809) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1811), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1811) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1812), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1813) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1814), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1815) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1816), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1816) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1819), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1819) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1821), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1822) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1823), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1823) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1825), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1825) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1827), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1827) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1828), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1829) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1830), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1830) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1832), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1832) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1833), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1834) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1835), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1835) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1837), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1837) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1839), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1839) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1840), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1841) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1842), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1842) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1844), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1844) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1845), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1847) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1848), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1848) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1850), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1850) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1852), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1852) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1853), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1854) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1855), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1855) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1857), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1857) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1859), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1859) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1860), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1861) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1862), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1862) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1898), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1898) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1899), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1900) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1901), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1902) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1903), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1903) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1905), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1905) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1907), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1907) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1909), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1909) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1911), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1911) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1912), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1913) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1914), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1915) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1916), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1916) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1918), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1918) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1920), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1920) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1921), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1922) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1923), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1923) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1925), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1925) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1927), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1927) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1928), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1929) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1930), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1930) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1932), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1932) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1934), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1934) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1936), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1936) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1937), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1938) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1939), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1939) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1941), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1941) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1943), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1943) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1944), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1945) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1946), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1946) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1948), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1948) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1949), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1950) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1951), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1951) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1953), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1953) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1955), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1955) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1956), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1957) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1958), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1958) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1960), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1960) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1961), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1962) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1963), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1963) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1966), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1966) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1968), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1968) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2007), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2008) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2009), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2010) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2011), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2011) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2013), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2013) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2015), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2015) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2017), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2017) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2019), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2019) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2020), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2021) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2022), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2022) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2024), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2024) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2026), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2026) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2027), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2028) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2029), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2029) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2031), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2031) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2033), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2034) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2035), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2036) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2037), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2037) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2039), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2039) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1487), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1487) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1489), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1490) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1491), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1492) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1493), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1493) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1495), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1495) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1533), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1533) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1540), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1540) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1542), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1542) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$6rDsi4r2NpvPhhHvaIOfXubMSmYTgE2/XetiOcgjujl6v78NYrGMm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(4158), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(4158) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4261), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4262) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4277), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4277) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4280), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4280) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4282), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4283) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4285), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4285) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4288), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4289) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4291), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4291) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4293), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4294) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4296), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4296) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4299), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4302), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4302) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4304), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4305) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4307), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4307) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4309), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4309) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4311), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4312) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4314), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4314) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4317), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4317) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4321) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4323), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4323) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4325), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4325) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4327), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4328) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4330), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4330) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4332), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4333) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4334), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4335) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4337), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4337) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4339), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4339) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4341), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4342) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4344), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4344) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4346), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4346) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4348), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4348) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4350), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4351) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4380), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4383), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4383) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4386), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4387) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4389), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4389) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4391), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4392) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4394), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4394) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4396), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4396) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4398), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4399) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4401), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4401) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4403), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4403) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4405), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4406) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4408), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4408) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4410), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4412), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4413) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4415), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4415) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4417), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4417) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4419), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4420) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4422), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4423) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4425), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4425) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4427), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4427) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4429), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4430) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4432), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4432) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4434), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4434) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4436), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4437) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4438), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4439) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4441), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4441) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4443), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4444) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4445), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4446) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4448), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4448) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4450), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4450) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4452), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4453) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4454), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4455) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4457), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4457) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4460), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4460) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4463), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4464) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4466), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4466) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4468), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4468) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4470), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4471) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4472), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4473) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4475), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4475) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4477), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4477) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4479), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4480) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4545), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4546) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4548), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4548) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4550), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4551) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4553), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4553) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4555), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4555) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4557), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4558) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4560), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4561) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4563), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4563) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4565), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4566) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4568), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4568) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4570), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4570) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4572), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4573) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4575), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4575) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4577), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4577) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4579), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4580) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4582), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4582) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4585), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4585) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4587), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4587) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4589), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4590) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4592), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4592) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4594), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4595) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4597), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4597) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4600), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4601) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4603), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4603) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4605), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4605) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4607), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4610), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4610) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4612), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4612) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4614), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4615) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4617), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4617) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4619), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4619) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4621), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4622) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4624), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4624) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4626), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4626) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4628), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4629) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4630), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4631) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4633), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4633) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4635), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4635) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4638), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4639) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4640), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4641) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4643), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4643) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4645), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4646) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4648), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4648) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4650), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4651) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4653), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4653) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4655), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4655) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4657), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4658) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4660), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4662), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4663) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4665), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4665) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4667), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4667) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4669), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4671), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4672) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4674), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4674) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4725), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4725) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4727), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4728) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4731), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4732) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4734), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4734) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4736), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4737) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4739), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4739) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4742), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4742) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4744), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4745) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4747), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4747) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4749), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4749) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4752), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4752) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4754), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4754) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4756), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4757) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4759), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4759) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4761), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4762) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4763), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4764) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4766), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4767) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4769), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4769) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4771), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4771) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4773), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4774) });

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 400, 73, 7 },
                    { 401, 74, 7 },
                    { 402, 80, 7 },
                    { 403, 136, 7 },
                    { 404, 52, 7 },
                    { 405, 59, 7 },
                    { 406, 15, 7 },
                    { 407, 31, 7 },
                    { 408, 38, 7 },
                    { 409, 45, 7 },
                    { 410, 143, 7 },
                    { 411, 15, 8 },
                    { 412, 38, 8 },
                    { 413, 45, 8 },
                    { 414, 52, 8 },
                    { 415, 59, 8 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4058), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4059) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4062), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4062) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4064), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4065) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4067), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4067) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4069), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4072), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4072) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4086), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4087) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4089), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$LiN8HpZhfln0tVQDUkIy3efRU5Q6dcw1y7EQEcd81kOG0rX6rKQrq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(8014), new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(8015) });
        }
    }
}
