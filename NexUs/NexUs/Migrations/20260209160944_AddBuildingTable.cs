using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddBuildingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ManagedBy = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Buildings_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buildings_Users_ManagedBy",
                        column: x => x.ManagedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Buildings_Users_UpdatedBy",
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
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9605), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9606) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9612), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9613) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9615), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9615) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9617), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9617) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9626), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9626) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9629), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9629) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9631), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9631) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9633), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9633) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9635), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9635) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9637), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9637) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9639), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9639) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9641), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9641) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9643), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9643) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9645), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9645) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9483), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9483) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9486), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9486) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$gIsv8aVmnbUWcY.uwVjFc.HlPw6poq.7kmULEVS6vFbFgbIwKNg8K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9833), new DateTime(2026, 2, 9, 16, 9, 43, 716, DateTimeKind.Utc).AddTicks(9833) });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_AddressId",
                table: "Buildings",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CreatedBy",
                table: "Buildings",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_ManagedBy",
                table: "Buildings",
                column: "ManagedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_UpdatedBy",
                table: "Buildings",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");

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
        }
    }
}
