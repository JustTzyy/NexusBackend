using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailVerificationOtp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailVerificationOtps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailVerificationOtps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailVerificationOtps_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmailVerificationOtps_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5779), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5779) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5781), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5782) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5783), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5784) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5786), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5786) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5787), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5788) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5790), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5791) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5792), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5793) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5794), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5795) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5796), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5797) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5799), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5799) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5801), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5801) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5803), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5803) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5805), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5805) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5806), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5807) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5808), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5809) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5810), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5810) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5837), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5837) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5840), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5840) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5841), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5842) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5843), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5844) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5845), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5846) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5847), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5847) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5849), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5849) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5851), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5851) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5853), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5853) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5855), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5855) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5857), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5857) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5858), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5859) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5860), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5861) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5862), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5862) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5864), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5864) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5866), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5866) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5868), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5868) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5870), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5870) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5872), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5872) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5874), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5874) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5875), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5876) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5877), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5878) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5879), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5879) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5881), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5881) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5883), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5883) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5885), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5885) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5887), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5887) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5889), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5889) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5891), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5891) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5892), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5893) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5894), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5894) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5896), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5896) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5898), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5898) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5900), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5900) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5901), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5902) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5904), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5904) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5906), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5906) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5908), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5908) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5909), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5910) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5911), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5912) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5913), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5914) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5915), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5915) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5917), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5917) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5919), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5919) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5921), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5922) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5923), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5923) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5925), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5925) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5927), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5927) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5944), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5945) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5947), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5949), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5949) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5951), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5951) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5953), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5953) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5955), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5955) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5957), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5957) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5959), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5959) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5960), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5961) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5962), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5963) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5964), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5965) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5966), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5966) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5968), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5968) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5970), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5970) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5971), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5972) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5621), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5622) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5624), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5624) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5626), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5627) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5628), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5629) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5630), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5632), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5632) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5641), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5641) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5643), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(5643) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$G/IDYv7dYbjoM1TsPU/yY.FDT9XdB3PcpOSDtS.JYehb59X9n5E4.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(6256), new DateTime(2026, 2, 17, 7, 0, 32, 513, DateTimeKind.Utc).AddTicks(6257) });

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerificationOtps_CreatedByUserId",
                table: "EmailVerificationOtps",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerificationOtps_UpdatedByUserId",
                table: "EmailVerificationOtps",
                column: "UpdatedByUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailVerificationOtps");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7962), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7963) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7974), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7974) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7976), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7976) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7978), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7979) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7980), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7981) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7983), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7983) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7985), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7985) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7987), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7987) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7989), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7989) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8026), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8027) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8028), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8029) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8030), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8031) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8032), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8033) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8034), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8035) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8036), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8037) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8038), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8039) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8040), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8041) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8043), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8043) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8045), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8045) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8047), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8047) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8049), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8049) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8051), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8051) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8053), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8053) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8054), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8055) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8056), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8057) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8058), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8059) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8060), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8062), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8062) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8064), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8064) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8066), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8066) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8068), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8068) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8070), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8071), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8072) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8074), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8075) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8076), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8077) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8078), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8078) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8080), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8081) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8082), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8082) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8084), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8084) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8086), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8086) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8088), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8088) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8090), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8092), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8092) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8094), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8095), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8096) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8097), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8098) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8099), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8100) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8101), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8101) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8103), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8103) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8105), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8105) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8107), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8107) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8109), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8109) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8111), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8111) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8113), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8113) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8115), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8115) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8117), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8117) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8118), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8119) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8120), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8121) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8146), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8146) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8148), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8148) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8150), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8150) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8152), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8152) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8154), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8154) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8156), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8156) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8158), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8158) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8160), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8161) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8162), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8163) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8164), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8165) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8166), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8167) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8168), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8169) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8170), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8171) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8172), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8173) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8174), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8175) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8176), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8177) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8178), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8178) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8180), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8180) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8182), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8182) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8184), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8184) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8186), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8186) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7633), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7634) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7636), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7637) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7639), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7639) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7641), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7641) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7642), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7643) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7644), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7645) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7767), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7768) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7772), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(7772) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$Kjc39p.syLobkT5Cxug9y.XhnNqVU5plF7tkWt9PwvNcnXIzCTOQW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8537), new DateTime(2026, 2, 17, 3, 9, 46, 103, DateTimeKind.Utc).AddTicks(8538) });
        }
    }
}
