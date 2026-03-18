using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_Users_UpdatedBy",
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
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7773), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7773) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7777), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7777) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7779), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7779) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7781), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7781) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7783), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7786), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7786) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7788), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7788) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7790), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7792), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7792) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7795), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7795) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7797), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7797) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7799), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7799) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7801), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7801) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7802), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7803) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7804), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7805) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7806), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7807) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7808), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7808) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7811), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7811) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7812), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7813) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7814), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7815) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7816), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7817) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7818), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7818) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7822), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7822) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7823), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7824) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7825), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7826) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7827), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7830), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7832), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7832) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7833), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7834) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 31, new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7835), null, null, "View room list and details", "Rooms", "ViewRooms", new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7836), null },
                    { 32, new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7837), null, null, "Create new rooms", "Rooms", "CreateRooms", new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7837), null },
                    { 33, new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7839), null, null, "Update existing rooms", "Rooms", "UpdateRooms", new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7839), null },
                    { 34, new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7841), null, null, "Delete rooms", "Rooms", "DeleteRooms", new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7842), null },
                    { 35, new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7843), null, null, "Archive (soft delete) rooms", "Rooms", "ArchiveRooms", new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7844), null },
                    { 36, new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7845), null, null, "Restore archived rooms", "Rooms", "RestoreRooms", new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7845), null },
                    { 37, new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7847), null, null, "Permanently delete rooms", "Rooms", "PermanentDeleteRooms", new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7847), null }
                });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 31, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 32, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 33, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 34, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 35, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 36, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 37, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "PermissionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "PermissionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "PermissionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "PermissionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "PermissionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "PermissionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "PermissionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "PermissionId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "PermissionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "PermissionId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "PermissionId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "PermissionId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "PermissionId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "PermissionId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "PermissionId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "PermissionId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "PermissionId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "PermissionId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "PermissionId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "PermissionId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "PermissionId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "PermissionId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "PermissionId",
                value: 23);

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 61, 24, 2 },
                    { 62, 25, 2 },
                    { 63, 26, 2 },
                    { 64, 27, 2 },
                    { 65, 28, 2 },
                    { 66, 29, 2 },
                    { 67, 30, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7607), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7608) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7610), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7611) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7612), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7613) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7614), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7615) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7616), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7616) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7618), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7618) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7626), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7626) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7628), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7628) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$69H2CbUh0/qNrS.4sheTRePxbeL1qmFiR9DLZydRbuo6Fm5Q6gy0O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(8064), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(8064) });

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 68, 31, 2 },
                    { 69, 32, 2 },
                    { 70, 33, 2 },
                    { 71, 34, 2 },
                    { 72, 35, 2 },
                    { 73, 36, 2 },
                    { 74, 37, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildingId",
                table: "Rooms",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CreatedBy",
                table: "Rooms",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UpdatedBy",
                table: "Rooms",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37);

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

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9757), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9757) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9759), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9759) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9761), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9761) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9762), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9763) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9764), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9765) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9766), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9767) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9768), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9768) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9770), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9770) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9772), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9772) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9773), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9774) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9775), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9776) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9777), new DateTime(2026, 2, 10, 2, 48, 38, 603, DateTimeKind.Utc).AddTicks(9778) });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 4, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 5, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 6, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 7, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "PermissionId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 39,
                column: "PermissionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 40,
                column: "PermissionId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 41,
                column: "PermissionId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 42,
                column: "PermissionId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 43,
                column: "PermissionId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 44,
                column: "PermissionId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 45,
                column: "PermissionId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 46,
                column: "PermissionId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "PermissionId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 48,
                column: "PermissionId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 49,
                column: "PermissionId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 50,
                column: "PermissionId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 51,
                column: "PermissionId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "PermissionId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "PermissionId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "PermissionId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "PermissionId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "PermissionId",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "PermissionId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "PermissionId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "PermissionId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "PermissionId",
                value: 30);

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
        }
    }
}
