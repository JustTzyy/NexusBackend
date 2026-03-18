using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddPreferredBuildingToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreferredBuildingId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3227), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3227) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3237), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3237) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3261), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3261) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3263), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3263) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3265), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3265) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3268), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3268) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3270), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3272), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3272) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3274), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3274) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3276), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3277) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3278), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3279) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3280), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3282), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3282) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3284), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3284) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3286), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3286) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3287), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3288) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3289), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3290) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3293), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3293) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3295), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3295) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3296), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3297) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3298), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3299) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3313), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3318) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3322), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3323) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3324), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3325) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3326), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3326) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3328), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3328) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3330), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3332), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3332) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3334), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3334) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3348), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3348) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3350), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3350) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3352), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3352) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3354), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3354) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3357), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3357) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3359), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3360) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3362), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3362) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3364), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3364) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3365), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3366) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3367), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3368) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3369), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3371), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3371) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3373), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3373) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3375), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3375) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3377), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3377) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3378), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3379) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3380), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3381) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3382), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3382) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3428), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3428) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3432), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3432) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3434), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3434) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3436), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3436) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3438), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3438) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3440), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3440) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3442), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3442) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3444), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3444) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3446), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3446) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3448), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3448) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3449), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3450) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3451), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3452) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3453), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3453) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3455), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3455) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3459), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3459) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3461), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3461) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3463), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3463) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3465), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3466) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3467), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3468) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3469), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3469) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3471), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3471) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3474), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3474) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3475), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3476) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3477), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3478) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3479), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3480) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3481), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3481) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3483), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3483) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3485), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3485) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3487), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3487) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3489), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3489) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3491), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3491) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3094), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3095) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3097), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3098) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3101), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3102) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3103), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3104) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3105), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3106) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3115), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3115) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3116), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3117) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$YCoQmH2lwOmKddlpNXo/Ue/Y3w/Ou3W1O181iJsi4CgWjEpnGiO3a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PreferredBuildingId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3838), null, new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3838) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PreferredBuildingId",
                table: "Users",
                column: "PreferredBuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Buildings_PreferredBuildingId",
                table: "Users",
                column: "PreferredBuildingId",
                principalTable: "Buildings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Buildings_PreferredBuildingId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PreferredBuildingId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PreferredBuildingId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1263), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1263) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1268), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1268) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1272), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1273) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1274), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1274) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1277), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1277) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1279), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1279) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1281), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1281) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1283), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1283) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1285), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1286) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1287), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1287) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1289), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1289) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1316), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1317) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1318), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1319) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1320), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1321) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1322), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1323) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1324), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1325) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1327), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1328) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1329), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1329) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1331), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1331) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1333), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1333) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1335), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1335) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1337), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1337) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1339), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1339) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1341), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1341) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1343), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1343) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1344), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1345) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1346), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1347) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1348), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1349) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1350), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1352), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1352) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1354), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1354) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1356), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1356) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1358), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1359) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1360), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1361) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1362), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1363) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1364), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1364) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1366), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1366) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1368), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1368) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1372), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1372) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1373), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1374) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1375), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1376) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1377), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1378) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1379), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1379) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1381), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1381) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1383), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1383) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1384), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1385) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1386), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1387) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1388), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1388) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1392), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1392) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1394), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1394) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1396), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1396) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1397), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1398) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1399), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1400) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1401), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1401) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1403), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1403) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1405), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1470), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1472), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1472) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1474), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1474) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1476), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1476) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1478), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1478) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1480), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1480) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1482), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1483) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1484), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1485) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1486), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1487) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1488), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1489) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1490), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1491) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1492), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1493) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1494), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1494) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1496), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1496) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1498), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1498) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1500), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1500) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1502), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1502) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1504), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1504) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1505), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1506) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1507), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1508) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1092), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1093) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1095), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1095) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1097), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1097) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1099), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1099) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1101), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1101) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1103), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1103) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1116), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1116) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1118), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1118) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$tXwM/6oZ.cDkr1GlMZwLR.z7wKsY2P05yvVyZb0nmxRPaOGqAUnUa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1811), new DateTime(2026, 2, 21, 14, 39, 51, 531, DateTimeKind.Utc).AddTicks(1811) });
        }
    }
}
