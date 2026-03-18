using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRolesToSuperAdminAndAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9233), new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9234) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9236), new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9236) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9238), new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9238) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9240), new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9240) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9242), new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9242) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9245), new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9246) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9247), new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9248) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9249), new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9250) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9251), new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9251) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9254), new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9254) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9255), new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9256) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9257), new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9257) });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "PermissionId",
                value: 2);

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
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 4, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 5, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 6, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "RoleId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 20, 8, 2 },
                    { 21, 9, 2 },
                    { 22, 10, 2 },
                    { 23, 11, 2 },
                    { 24, 12, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9090), "Super Administrator with unrestricted access to all system features", "Super Admin", new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9090) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9092), "Administrator with full access to manage users, roles, and permissions", "Admin", new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9093) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8387), new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8388) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8390), new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8390) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8392), new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8392) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8394), new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8394) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8396), new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8396) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8399), new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8400) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8401), new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8401) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8403), new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8403) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8405), new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8405) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8407), new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8408) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8409), new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8409) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8411), new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8411) });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "PermissionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "PermissionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 5, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "RoleId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8275), "Administrator with full access", "Admin", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8275) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8277), "Standard user with basic access", "User", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8278) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 3, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8279), null, null, "Manager with elevated privileges", "Manager", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8280), null });
        }
    }
}
