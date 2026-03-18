using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditAndOperationLogPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(532), new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(532) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(535), new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(535) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(537), new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(537) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(539), new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(539) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(541), new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(541) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(544), new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(544) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(546), new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(548), new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(548) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(549), new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(550) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(552), new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(552) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(554), new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(554) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(555), new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(556) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 13, new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(557), null, null, "View audit log list and details", "AuditLog", "ViewAuditLogs", new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(558), null },
                    { 14, new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(559), null, null, "View operation log list and details", "OperationLog", "ViewOperationLogs", new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(560), null }
                });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 13, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 14, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "PermissionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "PermissionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "PermissionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "PermissionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "PermissionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "PermissionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "PermissionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "PermissionId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "PermissionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "PermissionId",
                value: 10);

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 25, 11, 2 },
                    { 26, 12, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(426), new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(429), new DateTime(2026, 2, 8, 7, 8, 53, 208, DateTimeKind.Utc).AddTicks(429) });

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 27, 13, 2 },
                    { 28, 14, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7518), new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7519) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7521), new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7522) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7523), new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7524) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7525), new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7526) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7527), new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7528) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7531), new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7531) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7533), new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7533) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7535), new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7535) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7537), new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7537) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7539), new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7540) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7541), new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7541) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7543), new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7543) });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "PermissionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "PermissionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "PermissionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "PermissionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "PermissionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "PermissionId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "PermissionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "PermissionId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "PermissionId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "PermissionId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7362), new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7362) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7364), new DateTime(2026, 2, 8, 7, 4, 47, 461, DateTimeKind.Utc).AddTicks(7365) });
        }
    }
}
