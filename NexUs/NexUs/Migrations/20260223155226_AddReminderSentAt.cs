using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddReminderSentAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReminderSentAt",
                table: "TutoringRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8261), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8261) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8265), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8266) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8268), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8268) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8270), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8270) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8272), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8272) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8275), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8275) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8277), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8277) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8279), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8279) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8281), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8281) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8284), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8284) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8286), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8286) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8288), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8288) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8290), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8290) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8292), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8292) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8294), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8294) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8296), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8296) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8298), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8298) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8300), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8301) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8302), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8303) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8304), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8305) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8306), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8307) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8308), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8309) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8310), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8311) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8312), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8313) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8314), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8316), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8316) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8318), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8318) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8320), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8320) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8322), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8322) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8324), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8324) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8326), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8326) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8328), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8328) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8330), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8330) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8348), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8349) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8351), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8351) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8353), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8355), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8355) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8357), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8357) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8359), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8359) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8361), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8363), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8363) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8365), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8367), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8367) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8369), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8369) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8371), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8371) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8373), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8375), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8375) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8377), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8377) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8380), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8380) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8381), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8382) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8383), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8384) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8385), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8386) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8387), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8388) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8389), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8389) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8391), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8391) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8393), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8393) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8395), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8397), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8397) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8399), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8399) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8401), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8401) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8403), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8403) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8405), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8405) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8407), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8407) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8409), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8409) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8410), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8411) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8415), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8415) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8417), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8417) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8418), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8419) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8420), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8421) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8422), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8423) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8424), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8425) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8426), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8426) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8428), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8428) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8430), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8432), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8432) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8479), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8479) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8482), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8482) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8484), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8484) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8486), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8486) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8137), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8138) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8140), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8140) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8142), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8142) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8144), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8146), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8146) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8148), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8148) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8157), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8157) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8159), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8159) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$YOimh3V2vVYKnpTISl5yAOI45ZnE/Gxs5lpyLXoyMVTjkQX/oIoya");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8759), new DateTime(2026, 2, 23, 15, 52, 25, 706, DateTimeKind.Utc).AddTicks(8760) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReminderSentAt",
                table: "TutoringRequests");

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3838), new DateTime(2026, 2, 22, 11, 25, 1, 133, DateTimeKind.Utc).AddTicks(3838) });
        }
    }
}
