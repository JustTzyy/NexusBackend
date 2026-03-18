using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Clean up any existing data that conflicts with the new seed data.
            migrationBuilder.Sql("DELETE FROM [Role_Permissions] WHERE [RoleId] IN (1,2,3,4,5,6,7,8);");
            migrationBuilder.Sql("DELETE FROM [Permissions] WHERE [Id] >= 80;");

            // Re-insert the 158 original Role_Permission rows (IDs 1-158) so the
            // auto-generated UpdateData calls below can modify them correctly.
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT [Role_Permissions] ON;
DECLARE @i INT = 1;
WHILE @i <= 79
BEGIN
    INSERT INTO [Role_Permissions] ([Id], [RoleId], [PermissionId]) VALUES (@i, 1, @i);
    SET @i = @i + 1;
END;
DECLARE @j INT = 80, @p INT = 1;
WHILE @j <= 158
BEGIN
    INSERT INTO [Role_Permissions] ([Id], [RoleId], [PermissionId]) VALUES (@j, 2, @p);
    SET @j = @j + 1;
    SET @p = @p + 1;
END;
SET IDENTITY_INSERT [Role_Permissions] OFF;
");

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

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 80, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4560), null, null, "View admin scheduling and session list", "Scheduling", "ViewScheduling", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4561), null },
                    { 81, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4563), null, null, "Create new scheduling entries and assign teachers", "Scheduling", "CreateScheduling", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4563), null },
                    { 82, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4565), null, null, "Update session assignments and schedules", "Scheduling", "UpdateScheduling", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4566), null },
                    { 83, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4568), null, null, "Cancel or delete scheduled sessions", "Scheduling", "DeleteScheduling", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4568), null },
                    { 84, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4570), null, null, "Archive scheduling entries", "Scheduling", "ArchiveScheduling", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4570), null },
                    { 85, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4572), null, null, "Restore archived scheduling entries", "Scheduling", "RestoreScheduling", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4573), null },
                    { 86, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4575), null, null, "Permanently delete scheduling entries", "Scheduling", "PermanentDeleteScheduling", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4575), null },
                    { 87, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4577), null, null, "View session logs and status history tracking", "SchedulingTracking", "ViewSchedulingTracking", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4577), null },
                    { 88, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4579), null, null, "View lead list and details", "Leads", "ViewLeads", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4580), null },
                    { 89, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4582), null, null, "Create new leads", "Leads", "CreateLeads", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4582), null },
                    { 90, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4585), null, null, "Update lead details and pipeline status", "Leads", "UpdateLeads", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4585), null },
                    { 91, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4587), null, null, "Delete leads", "Leads", "DeleteLeads", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4587), null },
                    { 92, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4589), null, null, "Archive (soft delete) leads", "Leads", "ArchiveLeads", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4590), null },
                    { 93, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4592), null, null, "Restore archived leads", "Leads", "RestoreLeads", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4592), null },
                    { 94, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4594), null, null, "Permanently delete leads", "Leads", "PermanentDeleteLeads", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4595), null },
                    { 95, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4597), null, null, "View customer list and details", "Customers", "ViewCustomers", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4597), null },
                    { 96, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4600), null, null, "Create new customers", "Customers", "CreateCustomers", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4601), null },
                    { 97, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4603), null, null, "Update existing customers", "Customers", "UpdateCustomers", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4603), null },
                    { 98, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4605), null, null, "Delete customers", "Customers", "DeleteCustomers", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4605), null },
                    { 99, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4607), null, null, "Manually convert a lead to a customer", "Customers", "ConvertLead", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4608), null },
                    { 100, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4610), null, null, "Archive (soft delete) customers", "Customers", "ArchiveCustomers", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4610), null },
                    { 101, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4612), null, null, "Restore archived customers", "Customers", "RestoreCustomers", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4612), null },
                    { 102, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4614), null, null, "Permanently delete customers", "Customers", "PermanentDeleteCustomers", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4615), null },
                    { 103, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4617), null, null, "View campaign list and details", "Campaigns", "ViewCampaigns", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4617), null },
                    { 104, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4619), null, null, "Create new campaigns", "Campaigns", "CreateCampaigns", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4619), null },
                    { 105, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4621), null, null, "Update existing campaigns", "Campaigns", "UpdateCampaigns", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4622), null },
                    { 106, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4624), null, null, "Delete campaigns", "Campaigns", "DeleteCampaigns", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4624), null },
                    { 107, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4626), null, null, "Archive (soft delete) campaigns", "Campaigns", "ArchiveCampaigns", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4626), null },
                    { 108, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4628), null, null, "Restore archived campaigns", "Campaigns", "RestoreCampaigns", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4629), null },
                    { 109, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4630), null, null, "Permanently delete campaigns", "Campaigns", "PermanentDeleteCampaigns", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4631), null },
                    { 110, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4633), null, null, "Send or schedule email campaigns", "Campaigns", "SendCampaigns", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4633), null },
                    { 111, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4635), null, null, "View email template list and details", "EmailTemplates", "ViewEmailTemplates", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4635), null },
                    { 112, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4638), null, null, "Create new email templates", "EmailTemplates", "CreateEmailTemplates", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4639), null },
                    { 113, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4640), null, null, "Update existing email templates", "EmailTemplates", "UpdateEmailTemplates", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4641), null },
                    { 114, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4643), null, null, "Delete email templates", "EmailTemplates", "DeleteEmailTemplates", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4643), null },
                    { 115, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4645), null, null, "Archive (soft delete) email templates", "EmailTemplates", "ArchiveEmailTemplates", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4646), null },
                    { 116, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4648), null, null, "Restore archived email templates", "EmailTemplates", "RestoreEmailTemplates", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4648), null },
                    { 117, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4650), null, null, "Permanently delete email templates", "EmailTemplates", "PermanentDeleteEmailTemplates", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4651), null },
                    { 118, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4653), null, null, "View audience segment list and details", "Segments", "ViewSegments", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4653), null },
                    { 119, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4655), null, null, "Create new audience segments", "Segments", "CreateSegments", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4655), null },
                    { 120, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4657), null, null, "Update existing audience segments", "Segments", "UpdateSegments", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4658), null },
                    { 121, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4660), null, null, "Delete audience segments", "Segments", "DeleteSegments", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4660), null },
                    { 122, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4662), null, null, "Archive (soft delete) audience segments", "Segments", "ArchiveSegments", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4663), null },
                    { 123, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4665), null, null, "Restore archived audience segments", "Segments", "RestoreSegments", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4665), null },
                    { 124, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4667), null, null, "Permanently delete audience segments", "Segments", "PermanentDeleteSegments", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4667), null },
                    { 125, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4669), null, null, "View automation rule list and details", "AutomationRules", "ViewAutomationRules", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4670), null },
                    { 126, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4671), null, null, "Create new automation rules", "AutomationRules", "CreateAutomationRules", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4672), null },
                    { 127, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4674), null, null, "Update existing automation rules", "AutomationRules", "UpdateAutomationRules", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4674), null },
                    { 128, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4725), null, null, "Delete automation rules", "AutomationRules", "DeleteAutomationRules", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4725), null },
                    { 129, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4727), null, null, "Archive (soft delete) automation rules", "AutomationRules", "ArchiveAutomationRules", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4728), null },
                    { 130, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4731), null, null, "Restore archived automation rules", "AutomationRules", "RestoreAutomationRules", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4732), null },
                    { 131, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4734), null, null, "Permanently delete automation rules", "AutomationRules", "PermanentDeleteAutomationRules", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4734), null },
                    { 132, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4736), null, null, "View marketing analytics dashboard", "MarketingAnalytics", "ViewMarketingAnalytics", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4737), null },
                    { 133, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4739), null, null, "View email message delivery logs", "EmailLogs", "ViewEmailLogs", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4739), null },
                    { 134, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4742), null, null, "View email suppression list", "Suppressions", "ViewSuppressions", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4742), null },
                    { 135, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4744), null, null, "Add or remove email suppressions", "Suppressions", "ManageSuppressions", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4745), null },
                    { 136, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4747), null, null, "View tutoring session logs and history", "SessionLogs", "ViewSessionLogs", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4747), null },
                    { 137, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4749), null, null, "View student tutoring request logs", "StudentRequestLog", "ViewStudentRequestLog", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4749), null },
                    { 138, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4752), null, null, "View admin scheduling request logs", "AdminRequestLog", "ViewAdminRequestLog", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4752), null },
                    { 139, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4754), null, null, "View client activity logs", "ClientLog", "ViewClientLog", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4754), null },
                    { 140, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4756), null, null, "Create tutoring session logs", "SessionLogs", "CreateSessionLogs", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4757), null },
                    { 141, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4759), null, null, "Update tutoring session logs", "SessionLogs", "UpdateSessionLogs", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4759), null },
                    { 142, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4761), null, null, "Delete tutoring session logs", "SessionLogs", "DeleteSessionLogs", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4762), null },
                    { 143, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4763), null, null, "View student assignment list and details", "StudentAssignments", "ViewStudentAssignments", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4764), null },
                    { 144, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4766), null, null, "Update student assignments", "StudentAssignments", "UpdateStudentAssignments", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4767), null },
                    { 145, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4769), null, null, "Delete student assignments", "StudentAssignments", "DeleteStudentAssignments", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4769), null },
                    { 146, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4771), null, null, "Restore archived student assignments", "StudentAssignments", "RestoreStudentAssignments", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4771), null },
                    { 147, new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4773), null, null, "Permanently delete student assignments", "StudentAssignments", "PermanentDeleteStudentAssignments", new DateTime(2026, 3, 7, 4, 56, 22, 336, DateTimeKind.Utc).AddTicks(4774), null }
                });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 80, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 81, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 82, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 83, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 84, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 85, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 86, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 87, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 88, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 89, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 90, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 91, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 92, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 93, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 94, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 95, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 96, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 97, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 98, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 99, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 100, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 101, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 102, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 103, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 104, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 105, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 106, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 107, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 108, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 109, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 110, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 111, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 112, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 113, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 114, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 115, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 116, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 117, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 118, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 119, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 120, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 121, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 122, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 123, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 124, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 125, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 126, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 127, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 128, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 129, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 130, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 131, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 132, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 133, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 134, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 135, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 136, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 137, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 138, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 139, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 140, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 141, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 142, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 143, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 144, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 145, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 146, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 147, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 148,
                column: "PermissionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 149,
                column: "PermissionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 150,
                column: "PermissionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 151,
                column: "PermissionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 152,
                column: "PermissionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 153,
                column: "PermissionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 154,
                column: "PermissionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 155,
                column: "PermissionId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 156,
                column: "PermissionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 157,
                column: "PermissionId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 158,
                column: "PermissionId",
                value: 11);

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 159, 12, 2 },
                    { 160, 13, 2 },
                    { 161, 14, 2 },
                    { 162, 15, 2 },
                    { 163, 16, 2 },
                    { 164, 17, 2 },
                    { 165, 18, 2 },
                    { 166, 19, 2 },
                    { 167, 20, 2 },
                    { 168, 21, 2 },
                    { 169, 22, 2 },
                    { 170, 23, 2 },
                    { 171, 24, 2 },
                    { 172, 25, 2 },
                    { 173, 26, 2 },
                    { 174, 27, 2 },
                    { 175, 28, 2 },
                    { 176, 29, 2 },
                    { 177, 30, 2 },
                    { 178, 31, 2 },
                    { 179, 32, 2 },
                    { 180, 33, 2 },
                    { 181, 34, 2 },
                    { 182, 35, 2 },
                    { 183, 36, 2 },
                    { 184, 37, 2 },
                    { 185, 38, 2 },
                    { 186, 39, 2 },
                    { 187, 40, 2 },
                    { 188, 41, 2 },
                    { 189, 42, 2 },
                    { 190, 43, 2 },
                    { 191, 44, 2 },
                    { 192, 45, 2 },
                    { 193, 46, 2 },
                    { 194, 47, 2 },
                    { 195, 48, 2 },
                    { 196, 49, 2 },
                    { 197, 50, 2 },
                    { 198, 51, 2 },
                    { 199, 52, 2 },
                    { 200, 53, 2 },
                    { 201, 54, 2 },
                    { 202, 55, 2 },
                    { 203, 56, 2 },
                    { 204, 57, 2 },
                    { 205, 58, 2 },
                    { 206, 59, 2 },
                    { 207, 60, 2 },
                    { 208, 61, 2 },
                    { 209, 62, 2 },
                    { 210, 63, 2 },
                    { 211, 64, 2 },
                    { 212, 65, 2 },
                    { 213, 66, 2 },
                    { 214, 67, 2 },
                    { 215, 68, 2 },
                    { 216, 69, 2 },
                    { 217, 70, 2 },
                    { 218, 71, 2 },
                    { 219, 72, 2 },
                    { 220, 73, 2 },
                    { 221, 74, 2 },
                    { 222, 75, 2 },
                    { 223, 76, 2 },
                    { 224, 77, 2 },
                    { 225, 78, 2 },
                    { 226, 79, 2 },
                    { 366, 15, 5 },
                    { 367, 16, 5 },
                    { 368, 17, 5 },
                    { 369, 18, 5 },
                    { 370, 28, 5 },
                    { 371, 29, 5 },
                    { 372, 31, 5 },
                    { 373, 32, 5 },
                    { 374, 33, 5 },
                    { 375, 34, 5 },
                    { 376, 35, 5 },
                    { 377, 36, 5 },
                    { 378, 38, 5 },
                    { 379, 45, 5 },
                    { 380, 52, 5 },
                    { 381, 59, 5 },
                    { 382, 66, 5 },
                    { 383, 73, 5 },
                    { 387, 66, 6 },
                    { 388, 68, 6 },
                    { 389, 73, 6 },
                    { 394, 52, 6 },
                    { 395, 59, 6 },
                    { 396, 15, 6 },
                    { 397, 31, 6 },
                    { 398, 38, 6 },
                    { 399, 45, 6 },
                    { 400, 73, 7 },
                    { 401, 74, 7 },
                    { 404, 52, 7 },
                    { 405, 59, 7 },
                    { 406, 15, 7 },
                    { 407, 31, 7 },
                    { 408, 38, 7 },
                    { 409, 45, 7 },
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

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 227, 80, 2 },
                    { 228, 81, 2 },
                    { 229, 82, 2 },
                    { 230, 83, 2 },
                    { 231, 84, 2 },
                    { 232, 85, 2 },
                    { 233, 86, 2 },
                    { 234, 87, 2 },
                    { 235, 88, 2 },
                    { 236, 89, 2 },
                    { 237, 90, 2 },
                    { 238, 91, 2 },
                    { 239, 92, 2 },
                    { 240, 93, 2 },
                    { 241, 94, 2 },
                    { 242, 95, 2 },
                    { 243, 96, 2 },
                    { 244, 97, 2 },
                    { 245, 98, 2 },
                    { 246, 99, 2 },
                    { 247, 100, 2 },
                    { 248, 101, 2 },
                    { 249, 102, 2 },
                    { 250, 103, 2 },
                    { 251, 104, 2 },
                    { 252, 105, 2 },
                    { 253, 106, 2 },
                    { 254, 107, 2 },
                    { 255, 108, 2 },
                    { 256, 109, 2 },
                    { 257, 110, 2 },
                    { 258, 111, 2 },
                    { 259, 112, 2 },
                    { 260, 113, 2 },
                    { 261, 114, 2 },
                    { 262, 115, 2 },
                    { 263, 116, 2 },
                    { 264, 117, 2 },
                    { 265, 118, 2 },
                    { 266, 119, 2 },
                    { 267, 120, 2 },
                    { 268, 121, 2 },
                    { 269, 122, 2 },
                    { 270, 123, 2 },
                    { 271, 124, 2 },
                    { 272, 125, 2 },
                    { 273, 126, 2 },
                    { 274, 127, 2 },
                    { 275, 128, 2 },
                    { 276, 129, 2 },
                    { 277, 130, 2 },
                    { 278, 131, 2 },
                    { 279, 132, 2 },
                    { 280, 133, 2 },
                    { 281, 134, 2 },
                    { 282, 135, 2 },
                    { 283, 136, 2 },
                    { 284, 137, 2 },
                    { 285, 138, 2 },
                    { 286, 139, 2 },
                    { 287, 140, 2 },
                    { 288, 141, 2 },
                    { 289, 142, 2 },
                    { 290, 143, 2 },
                    { 291, 144, 2 },
                    { 292, 145, 2 },
                    { 293, 146, 2 },
                    { 294, 147, 2 },
                    { 295, 88, 3 },
                    { 296, 89, 3 },
                    { 297, 90, 3 },
                    { 298, 91, 3 },
                    { 299, 92, 3 },
                    { 300, 93, 3 },
                    { 301, 94, 3 },
                    { 302, 95, 3 },
                    { 303, 96, 3 },
                    { 304, 97, 3 },
                    { 305, 98, 3 },
                    { 306, 99, 3 },
                    { 307, 100, 3 },
                    { 308, 101, 3 },
                    { 309, 102, 3 },
                    { 310, 103, 3 },
                    { 311, 104, 3 },
                    { 312, 105, 3 },
                    { 313, 106, 3 },
                    { 314, 107, 3 },
                    { 315, 108, 3 },
                    { 316, 109, 3 },
                    { 317, 110, 3 },
                    { 318, 111, 3 },
                    { 319, 112, 3 },
                    { 320, 113, 3 },
                    { 321, 114, 3 },
                    { 322, 115, 3 },
                    { 323, 116, 3 },
                    { 324, 117, 3 },
                    { 325, 118, 3 },
                    { 326, 119, 3 },
                    { 327, 120, 3 },
                    { 328, 121, 3 },
                    { 329, 122, 3 },
                    { 330, 123, 3 },
                    { 331, 124, 3 },
                    { 332, 125, 3 },
                    { 333, 126, 3 },
                    { 334, 127, 3 },
                    { 335, 128, 3 },
                    { 336, 129, 3 },
                    { 337, 130, 3 },
                    { 338, 131, 3 },
                    { 339, 132, 3 },
                    { 340, 133, 3 },
                    { 341, 134, 3 },
                    { 342, 135, 3 },
                    { 343, 88, 4 },
                    { 344, 89, 4 },
                    { 345, 90, 4 },
                    { 346, 95, 4 },
                    { 347, 96, 4 },
                    { 348, 97, 4 },
                    { 349, 99, 4 },
                    { 350, 103, 4 },
                    { 351, 104, 4 },
                    { 352, 105, 4 },
                    { 353, 110, 4 },
                    { 354, 111, 4 },
                    { 355, 112, 4 },
                    { 356, 113, 4 },
                    { 357, 118, 4 },
                    { 358, 119, 4 },
                    { 359, 120, 4 },
                    { 360, 125, 4 },
                    { 361, 126, 4 },
                    { 362, 127, 4 },
                    { 363, 132, 4 },
                    { 364, 133, 4 },
                    { 365, 134, 4 },
                    { 384, 80, 5 },
                    { 385, 87, 5 },
                    { 386, 136, 5 },
                    { 390, 136, 6 },
                    { 391, 140, 6 },
                    { 392, 141, 6 },
                    { 393, 80, 6 },
                    { 402, 80, 7 },
                    { 403, 136, 7 },
                    { 410, 143, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 399);

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

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7396), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7397) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7400), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7400) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7402), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7402) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7404), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7404) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7406), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7406) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7409), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7409) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7411), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7411) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7413), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7415), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7417), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7417) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7419), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7419) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7421), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7421) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7423), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7423) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7425), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7425) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7426), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7427) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7428), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7429) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7430), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7432) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7434), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7435) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7436), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7437) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7438), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7438) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7440), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7442), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7442) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7444), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7444) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7445), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7446) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7447), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7448) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7449), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7451), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7451) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7453), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7453) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7455), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7455) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7456), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7457) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7458), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7458) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7460), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7460) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7462), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7462) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7464), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7465) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7466), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7466) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7468), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7468) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7470), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7471), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7472) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7473), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7474) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7475), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7477), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7477) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7504), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7504) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7506), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7506) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7508), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7508) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7510), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7510) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7512), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7513), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7514) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7515), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7516) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7517), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7518) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7519), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7520) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7521), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7521) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7523), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7523) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7525), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7525) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7526), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7527) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7528), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7529) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7530), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7531) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7532), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7532) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7534), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7534) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7536), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7536) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7538), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7538) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7539), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7540) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7541), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7541) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7543), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7543) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7545), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7545) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7547), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7547) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7549), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7550) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7551), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7551) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7553), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7553) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7555), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7555) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7557), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7557) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7558), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7559) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7560), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7561) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7562), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7562) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7564), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7564) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7566), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7566) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7567), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7568) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7569), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7570) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7571), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7571) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7573), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7573) });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 4, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 5, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 6, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 7, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 8, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 9, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 10, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 11, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 12, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 13, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 14, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 15, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 16, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 17, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 18, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 19, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 20, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 21, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 22, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 23, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 24, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 25, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 26, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 27, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 28, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 29, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 30, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 31, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 32, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 33, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 34, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 35, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 36, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 37, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 38, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 39, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 40, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 41, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 42, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 43, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 44, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 45, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 46, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 47, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 48, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 49, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 50, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 51, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 52, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 53, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 54, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 55, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 56, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 57, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 58, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 59, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 60, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 61, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 62, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 63, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 64, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 65, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 66, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 67, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 68, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 148,
                column: "PermissionId",
                value: 69);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 149,
                column: "PermissionId",
                value: 70);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 150,
                column: "PermissionId",
                value: 71);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 151,
                column: "PermissionId",
                value: 72);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 152,
                column: "PermissionId",
                value: 73);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 153,
                column: "PermissionId",
                value: 74);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 154,
                column: "PermissionId",
                value: 75);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 155,
                column: "PermissionId",
                value: 76);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 156,
                column: "PermissionId",
                value: 77);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 157,
                column: "PermissionId",
                value: 78);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 158,
                column: "PermissionId",
                value: 79);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7185), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7186) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7188), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7188) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7190), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7190) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7192), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7192) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7265), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7265) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7278), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7278) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7279), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$m6laWXBKQtieV/i/2Kl0wOH38BJ7vrvkZjrRwSs48DT3gkY2Oz.YG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(8053), new DateTime(2026, 3, 4, 9, 54, 55, 209, DateTimeKind.Utc).AddTicks(8054) });
        }
    }
}
