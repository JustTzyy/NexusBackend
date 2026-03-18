using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordResetTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordResetTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordResetTokens_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PasswordResetTokens_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PasswordResetTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5232), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5233) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5242), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5242) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5244), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5245) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5246), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5247) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5253), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5253) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5255), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5256) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5257), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5258) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5259), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5260) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5261), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5261) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5285), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5285) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5287), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5287) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5289), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5289) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5291), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5291) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5293), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5293) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5127), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5128) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5131), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5131) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$SKOUerqeBBN93d1PH2xCPeYiwwTdabc.hIZtYwzQ/0d0EnZ0RTl16");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5422), new DateTime(2026, 2, 8, 15, 21, 40, 64, DateTimeKind.Utc).AddTicks(5422) });

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetTokens_CreatedBy",
                table: "PasswordResetTokens",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetTokens_UpdatedBy",
                table: "PasswordResetTokens",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetTokens_UserId",
                table: "PasswordResetTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordResetTokens");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6676), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6677) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6685), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6685) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6687), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6688) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6689), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6690) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6696), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6696) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6699), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6699) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6701), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6701) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6703), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6703) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6705), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6705) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6707), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6708) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6709), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6711), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6712) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6713), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6714) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6715), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6715) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6584), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6585) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6587), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6587) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$ZniH0AFSr5gdpU1tvqvq2eW7afZ9dJFTfDQaOfFKvMpHN1RVUdgAu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6871), new DateTime(2026, 2, 8, 7, 11, 38, 156, DateTimeKind.Utc).AddTicks(6871) });
        }
    }
}
