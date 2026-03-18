using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddNewRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2097), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2098) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2104), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2105) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2107), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2107) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2108), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2109) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2110), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2111) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2113), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2114) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2115), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2116) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2117), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2118) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2119), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2119) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2122), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2122) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2124), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2124) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2125), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2126) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2127), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2128) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2129), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2129) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2131), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2131) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2133), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2133) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2135), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2135) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2137), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2137) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1951), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1951) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1954), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1954) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 3, new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1956), null, null, "Manages marketing operations and campaigns", "Marketing Manager", new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1956), null },
                    { 4, new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1957), null, null, "Marketing team member", "Marketing Staff", new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1958), null },
                    { 5, new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1959), null, null, "Manages building operations and maintenance", "Building Manager", new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1960), null },
                    { 6, new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1961), null, null, "Educational staff member", "Teacher", new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1962), null },
                    { 7, new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1968), null, null, "Team or project lead", "Lead", new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1969), null },
                    { 8, new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1970), null, null, "External user or customer", "Customer", new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1971), null }
                });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$8p8vo9NFICWzOT5.fLh3AuJDTzjhtSFN1vPO31PrR6kdwEo11vi3G");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2360), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(2360) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2576), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2577) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2583), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2583) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2585), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2585) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2587), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2587) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2594), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2595) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2597), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2598) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2599), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2599) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2601), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2601) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2603), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2603) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2605), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2606) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2607), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2608) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2609), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2610) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2611), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2612) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2613), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2614) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2615), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2615) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2617), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2617) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2619), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2619) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2621), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2621) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2465), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2466) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2468), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2469) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$6baKngMpnCXnuVd.aBU8iu/VZTTCEhDy7Q864e9Hwb5mE.BWW9zQq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2812), new DateTime(2026, 2, 10, 2, 20, 53, 370, DateTimeKind.Utc).AddTicks(2813) });
        }
    }
}
