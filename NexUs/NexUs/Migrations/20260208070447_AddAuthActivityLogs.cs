using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthActivityLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Roles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permissions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.CreateTable(
                name: "auth_activity_logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Device = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_activity_logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_auth_activity_logs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_auth_activity_logs_UserId",
                table: "auth_activity_logs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auth_activity_logs");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Roles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permissions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

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
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9090), new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9090) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9092), new DateTime(2026, 2, 6, 3, 19, 1, 845, DateTimeKind.Utc).AddTicks(9093) });
        }
    }
}
