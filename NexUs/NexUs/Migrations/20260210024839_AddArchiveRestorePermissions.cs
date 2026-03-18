using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddArchiveRestorePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Delete any runtime-created RolePermission records that would conflict with seed data IDs
            migrationBuilder.Sql("DELETE FROM [Role_Permissions] WHERE [Id] >= 37 AND [Id] <= 60");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9714), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9715) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9722), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9722) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9724), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9725) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9726), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9727) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9728), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9729) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9731), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9731) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9733), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9733) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9735), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9735) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9737), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9737) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9739), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9739) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9741), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9741) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9743), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9743) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9745), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9745) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9747), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9747) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9749), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9749) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9750), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9752), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9753) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9755), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9755) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 19, new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9757), null, null, "Archive (soft delete) users", "Users", "ArchiveUsers", new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9757), null },
                    { 20, new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9759), null, null, "Restore archived users", "Users", "RestoreUsers", new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9759), null },
                    { 21, new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9761), null, null, "Permanently delete users", "Users", "PermanentDeleteUsers", new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9761), null },
                    { 22, new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9762), null, null, "Archive (soft delete) roles", "Roles", "ArchiveRoles", new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9763), null },
                    { 23, new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9764), null, null, "Restore archived roles", "Roles", "RestoreRoles", new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9765), null },
                    { 24, new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9766), null, null, "Permanently delete roles", "Roles", "PermanentDeleteRoles", new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9767), null },
                    { 25, new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9768), null, null, "Archive (soft delete) permissions", "Permissions", "ArchivePermissions", new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9768), null },
                    { 26, new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9770), null, null, "Restore archived permissions", "Permissions", "RestorePermissions", new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9770), null },
                    { 27, new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9772), null, null, "Permanently delete permissions", "Permissions", "PermanentDeletePermissions", new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9772), null },
                    { 28, new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9773), null, null, "Archive (soft delete) buildings", "Buildings", "ArchiveBuildings", new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9774), null },
                    { 29, new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9775), null, null, "Restore archived buildings", "Buildings", "RestoreBuildings", new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9776), null },
                    { 30, new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9777), null, null, "Permanently delete buildings", "Buildings", "PermanentDeleteBuildings", new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9778), null }
                });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 19, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 20, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 21, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 22, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 23, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 24, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 25, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 26, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 27, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 28, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 29, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 30, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "PermissionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "PermissionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "PermissionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "PermissionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "PermissionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "PermissionId",
                value: 6);

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 37, 7, 2 },
                    { 38, 8, 2 },
                    { 39, 9, 2 },
                    { 40, 10, 2 },
                    { 41, 11, 2 },
                    { 42, 12, 2 },
                    { 43, 13, 2 },
                    { 44, 14, 2 },
                    { 45, 15, 2 },
                    { 46, 16, 2 },
                    { 47, 17, 2 },
                    { 48, 18, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9577), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9578) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9580), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9580) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9582), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9583) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9584), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9584) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9586), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9586) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9588), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9588) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9593), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9593) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9595), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9595) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$jU4ysL6aBDv7FODSYc92R.Nxxb8Wr3AJA9/bfo1oSceGw4hkhiFj.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9980), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9980) });

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 49, 19, 2 },
                    { 50, 20, 2 },
                    { 51, 21, 2 },
                    { 52, 22, 2 },
                    { 53, 23, 2 },
                    { 54, 24, 2 },
                    { 55, 25, 2 },
                    { 56, 26, 2 },
                    { 57, 27, 2 },
                    { 58, 28, 2 },
                    { 59, 29, 2 },
                    { 60, 30, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30);

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
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 4, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 5, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 6, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 7, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 8, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 9, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 10, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 11, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 12, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "PermissionId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "PermissionId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "PermissionId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 34,
                column: "PermissionId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "PermissionId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "PermissionId",
                value: 18);

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

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1956), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1956) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1957), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1958) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1959), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1960) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1961), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1962) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1968), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1969) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1970), new DateTime(2026, 2, 10, 2, 42, 28, 985, DateTimeKind.Utc).AddTicks(1971) });

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
    }
}
