using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailTemplateBody : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "EmailTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5421), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5422) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5435), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5435) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5437), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5439), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5441), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5442) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5444), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5444) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5455), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5455) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5458), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5458) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5460), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5463), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5463) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5465), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5465) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5467), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5467) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5469), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5469) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5471), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5471) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5473), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5473) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5475), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5475) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5476), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5477) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5479), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5479) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5481), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5481) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5484), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5484) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5486), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5486) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5520), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5525) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5528), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5528) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5530), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5532), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5532) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5534), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5534) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5536), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5536) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5538), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5538) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5540), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5554), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5554) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5556), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5556) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5557), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5558) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5559), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5562), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5562) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5564), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5564) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5566), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5566) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5568), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5569) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5570), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5572), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5572) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5574), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5574) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5576), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5576) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5578), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5578) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5579), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5581), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5582) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5583), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5583) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5585), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5585) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5587), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5587) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5588), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5589) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5590), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5591) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5592), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5592) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5594), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5594) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5596), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5596) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5598), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5598) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5601), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5602) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5603), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5603) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5605), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5605) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5607), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5607) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5608), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5609) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5610), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5611) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5612), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5612) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5614), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5614) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5616), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5616) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5618), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5618) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5619), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5620) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5621), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5622) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5669), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5669) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5671), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5671) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5673), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5673) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5675), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5675) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5677), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5677) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5679), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5679) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5681), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5681) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5683), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5683) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5684), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5685) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5686), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5687) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5688), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5689) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5690), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5691) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5692), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5692) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5694), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5694) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5257), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5258) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5261), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5261) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5263), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5263) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5265), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5265) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5267), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5267) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5269), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5269) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5279), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5279) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5280), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(5281) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$eEasBBunEumU4W3KrrHn7uT0NEcViutUag4JYkvjcDpQoybP6Kh0u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(6262), new DateTime(2026, 3, 1, 4, 56, 21, 329, DateTimeKind.Utc).AddTicks(6262) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "EmailTemplates");

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
        }
    }
}
