using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class ActivateAllAutomationRules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VariablesJson",
                table: "EmailMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5105), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5105) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5116), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5116) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5118), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5118) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5120), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5120) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5122), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5122) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5125), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5125) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5127), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5127) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5129), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5129) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5130), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5131) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5133), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5133) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5135), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5135) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5137), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5137) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5138), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5139) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5140), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5141) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5142), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5142) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5144), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5144) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5146), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5146) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5148), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5148) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5177), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5178) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5179), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5180) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5181), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5182) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5187), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5188) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5191), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5193), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5195), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5195) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5197), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5197) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5199), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5199) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5201), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5201) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5202), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5203) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5222), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5222) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5223), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5224) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5225), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5226) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5227), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5227) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5230), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5230) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5232), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5232) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5233), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5234) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5235), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5236) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5237), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5237) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5239), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5239) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5241), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5241) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5243), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5243) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5244), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5245) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5246), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5247) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5248), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5248) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5250), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5250) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5252), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5252) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5254), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5254) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5256), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5256) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5257), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5258) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5259), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5260) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5261), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5261) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5263), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5263) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5265), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5265) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5266), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5267) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5268), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5269) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5271), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5271) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5273), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5273) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5274), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5275) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5276), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5277) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5278), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5278) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5280), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5280) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5282), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5282) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5283), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5284) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5285), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5285) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5287), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5287) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5306), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5307) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5308), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5309) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5310), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5310) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5312), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5312) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5314), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5314) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5315), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5316) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5317), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5317) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5319), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5319) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5321), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5321) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5323), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5323) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5324), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5325) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5326), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5326) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5328), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5328) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5330), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5330) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4971), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4973) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4975), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4975) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4977), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4977) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4979), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4979) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4981), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4981) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4983), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4983) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4994), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4994) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4995), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(4996) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$UGElF6.tPVwgnU.birgOiua3Dqo4B8PpyJb1PurdyXg01d6xyvQ5G");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5643), new DateTime(2026, 3, 1, 4, 33, 29, 567, DateTimeKind.Utc).AddTicks(5643) });

            // Activate all automation rules so the automation pipeline is the single source of truth for emails
            migrationBuilder.Sql("UPDATE AutomationRules SET IsActive = 1, UpdatedAt = GETUTCDATE() WHERE Id IN (4,5,6,7,8,9,10,11,12);");
            migrationBuilder.Sql("UPDATE AutomationActions SET IsActive = 1, UpdatedAt = GETUTCDATE() WHERE Id IN (4,5,6,7,8,9,10,11,12);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE AutomationRules SET IsActive = 0, UpdatedAt = GETUTCDATE() WHERE Id IN (4,5,6,7,8,9,10,11,12);");
            migrationBuilder.Sql("UPDATE AutomationActions SET IsActive = 0, UpdatedAt = GETUTCDATE() WHERE Id IN (4,5,6,7,8,9,10,11,12);");

            migrationBuilder.DropColumn(
                name: "VariablesJson",
                table: "EmailMessages");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4999), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5003), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5003) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5005), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5005) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5007), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5007) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5009), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5012), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5012) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5014), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5014) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5016), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5016) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5050), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5053), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5053) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5055), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5056) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5058), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5059) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5060), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5062), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5062) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5064), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5064) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5066), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5066) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5068), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5068) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5071), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5071) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5072), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5073) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5074), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5075) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5076), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5076) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5089), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5091) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5094), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5094) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5096), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5096) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5098), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5098) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5099), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5100) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5101), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5102) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5103), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5104) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5105), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5105) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5114), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5114) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5116), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5116) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5118), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5118) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5120), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5120) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5122), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5123) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5124), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5124) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5126), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5126) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5128), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5128) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5130), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5130) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5132), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5132) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5133), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5134) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5135), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5136) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5137), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5138) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5139), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5139) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5141), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5141) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5143), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5143) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5145), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5145) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5147), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5147) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5148), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5149) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5150), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5151) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5152), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5152) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5154), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5154) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5156), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5156) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5158), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5158) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5160), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5160) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5161), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5162) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5163), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5164) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5194), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5196), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5196) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5198), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5198) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5200), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5200) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5202), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5202) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5204), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5204) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5206), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5206) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5208), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5208) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5210), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5210) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5212), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5213) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5214), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5215) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5216), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5217) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5218), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5218) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5220), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5220) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5222), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5222) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5224), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5224) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5225), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5226) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5227), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5228) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5229), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5229) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5231), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5231) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5233), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5233) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5235), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5235) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5236), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5237) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4861), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4862) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4864), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4865) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4866), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4867) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4868), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4870), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4872), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4872) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4880), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4881) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4882), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(4883) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$gNkLtrKXYepeKVu8NN2Dz.KOIK1.wKesQMZdyUT9HvgWbXwApTSWi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5519), new DateTime(2026, 2, 28, 16, 15, 33, 140, DateTimeKind.Utc).AddTicks(5520) });
        }
    }
}
