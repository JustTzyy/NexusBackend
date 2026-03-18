using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipientUserId = table.Column<int>(type: "int", nullable: true),
                    RecipientRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReferenceId = table.Column<int>(type: "int", nullable: true),
                    ReferenceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3031), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3032) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3034), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3035) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3036), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3037) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3038), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3039) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3040), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3041) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3043), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3044) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3045), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3046) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3047), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3048) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3049), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3052), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3052) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3054), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3054) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3056), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3056) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3058), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3058) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3059), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3061), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3062) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3063), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3063) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3065), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3065) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3068), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3068) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3070), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3071), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3072) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3073), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3074) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3075), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3075) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3077), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3077) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3079), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3079) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3081), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3081) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3082), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3083) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3084), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3085) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3086), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3086) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3088), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3088) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3092), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3092) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3093), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3094) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3096), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3096) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3099), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3099) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3101) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3102), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3102) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3104), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3104) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3106), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3106) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3107), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3108) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3142), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3142) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3144), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3144) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3145), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3146) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3147), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3149), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3151), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3151) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3153), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3153) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3155), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3155) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3157), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3157) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3159), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3159) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3161) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3162), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3163) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3164), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3165) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3166), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3166) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3168), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3168) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3172), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3172) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3173), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3174) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3175), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3175) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3177), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3177) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3179), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3179) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3181), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3181) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3182), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3183) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3184), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3185) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3187), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3187) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3191) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3192), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3193) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3194), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3194) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3196), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3196) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3198), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3198) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3199), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3201), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3202) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3203), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3203) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3205), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3205) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3207), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3207) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3208), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3209) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3211) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3212), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3212) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3214), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3214) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3216), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3217) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3218), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3218) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3222), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3222) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3224), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3224) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3225), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3226) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3227), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3228) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3255), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3255) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3257), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3257) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3259), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3259) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3260), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3261) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3262), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3263) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3264), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3265) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3266), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3268), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3268) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3270), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3273), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3273) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3275), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3275) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3276), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3277) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3278), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3279) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3280), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3282), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3282) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3284), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3284) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3285), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3286) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3287), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3288) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3289), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3289) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3291), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3291) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3293), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3293) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3294), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3295) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3296), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3297) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3298), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3298) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3300), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3300) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3302), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3303) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3304), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3304) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3306), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3306) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3308), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3308) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3309), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3310) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3311), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3312) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3313), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3313) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3315), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3315) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3316), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3317) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3318), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3319) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3320), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3320) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3322), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3322) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3323), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3324) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3325), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3326) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3327), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3327) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3329), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3329) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3331), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3332) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3333), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3334) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3363), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3364) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3365), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3366) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3367), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3368) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3369), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3371), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3371) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3373), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3373) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3375), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3375) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3377), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3377) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3379), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3379) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3380), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3381) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3382), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3383) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3384), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3384) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3386), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3386) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3388), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3388) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3391), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3391) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3393), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3393) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3394), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3395) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3396), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3396) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 148, new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3398), null, null, "View notification list and details", "Notifications", "ViewNotifications", new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3398), null },
                    { 149, new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3400), null, null, "Mark notifications as read", "Notifications", "UpdateNotifications", new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3400), null },
                    { 150, new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3401), null, null, "Delete notifications", "Notifications", "DeleteNotifications", new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3402), null }
                });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 148, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 149, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 150, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 151,
                column: "PermissionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 152,
                column: "PermissionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 153,
                column: "PermissionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 154,
                column: "PermissionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 155,
                column: "PermissionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 156,
                column: "PermissionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 157,
                column: "PermissionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 158,
                column: "PermissionId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 159,
                column: "PermissionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 160,
                column: "PermissionId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 161,
                column: "PermissionId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 162,
                column: "PermissionId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 163,
                column: "PermissionId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 164,
                column: "PermissionId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 165,
                column: "PermissionId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 166,
                column: "PermissionId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 167,
                column: "PermissionId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 168,
                column: "PermissionId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 169,
                column: "PermissionId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 170,
                column: "PermissionId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 171,
                column: "PermissionId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 172,
                column: "PermissionId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 173,
                column: "PermissionId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 174,
                column: "PermissionId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 175,
                column: "PermissionId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 176,
                column: "PermissionId",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 177,
                column: "PermissionId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 178,
                column: "PermissionId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 179,
                column: "PermissionId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 180,
                column: "PermissionId",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 181,
                column: "PermissionId",
                value: 31);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 182,
                column: "PermissionId",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 183,
                column: "PermissionId",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 184,
                column: "PermissionId",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 185,
                column: "PermissionId",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 186,
                column: "PermissionId",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 187,
                column: "PermissionId",
                value: 37);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 188,
                column: "PermissionId",
                value: 38);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 189,
                column: "PermissionId",
                value: 39);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 190,
                column: "PermissionId",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 191,
                column: "PermissionId",
                value: 41);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 192,
                column: "PermissionId",
                value: 42);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 193,
                column: "PermissionId",
                value: 43);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 194,
                column: "PermissionId",
                value: 44);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 195,
                column: "PermissionId",
                value: 45);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 196,
                column: "PermissionId",
                value: 46);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 197,
                column: "PermissionId",
                value: 47);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 198,
                column: "PermissionId",
                value: 48);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 199,
                column: "PermissionId",
                value: 49);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 200,
                column: "PermissionId",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 201,
                column: "PermissionId",
                value: 51);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 202,
                column: "PermissionId",
                value: 52);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 203,
                column: "PermissionId",
                value: 53);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 204,
                column: "PermissionId",
                value: 54);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 205,
                column: "PermissionId",
                value: 55);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 206,
                column: "PermissionId",
                value: 56);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 207,
                column: "PermissionId",
                value: 57);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 208,
                column: "PermissionId",
                value: 58);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 209,
                column: "PermissionId",
                value: 59);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 210,
                column: "PermissionId",
                value: 60);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 211,
                column: "PermissionId",
                value: 61);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 212,
                column: "PermissionId",
                value: 62);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 213,
                column: "PermissionId",
                value: 63);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 214,
                column: "PermissionId",
                value: 64);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 215,
                column: "PermissionId",
                value: 65);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 216,
                column: "PermissionId",
                value: 66);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 217,
                column: "PermissionId",
                value: 67);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 218,
                column: "PermissionId",
                value: 68);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 219,
                column: "PermissionId",
                value: 69);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 220,
                column: "PermissionId",
                value: 70);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 221,
                column: "PermissionId",
                value: 71);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 222,
                column: "PermissionId",
                value: 72);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 223,
                column: "PermissionId",
                value: 73);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 224,
                column: "PermissionId",
                value: 74);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 225,
                column: "PermissionId",
                value: 75);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 226,
                column: "PermissionId",
                value: 76);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 227,
                column: "PermissionId",
                value: 77);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 228,
                column: "PermissionId",
                value: 78);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 229,
                column: "PermissionId",
                value: 79);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 230,
                column: "PermissionId",
                value: 80);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 231,
                column: "PermissionId",
                value: 81);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 232,
                column: "PermissionId",
                value: 82);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 233,
                column: "PermissionId",
                value: 83);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 234,
                column: "PermissionId",
                value: 84);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 235,
                column: "PermissionId",
                value: 85);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 236,
                column: "PermissionId",
                value: 86);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 237,
                column: "PermissionId",
                value: 87);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 238,
                column: "PermissionId",
                value: 88);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 239,
                column: "PermissionId",
                value: 89);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 240,
                column: "PermissionId",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 241,
                column: "PermissionId",
                value: 91);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 242,
                column: "PermissionId",
                value: 92);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 243,
                column: "PermissionId",
                value: 93);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 244,
                column: "PermissionId",
                value: 94);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 245,
                column: "PermissionId",
                value: 95);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 246,
                column: "PermissionId",
                value: 96);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 247,
                column: "PermissionId",
                value: 97);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 248,
                column: "PermissionId",
                value: 98);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 249,
                column: "PermissionId",
                value: 99);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 250,
                column: "PermissionId",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 251,
                column: "PermissionId",
                value: 101);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 252,
                column: "PermissionId",
                value: 102);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 253,
                column: "PermissionId",
                value: 103);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 254,
                column: "PermissionId",
                value: 104);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 255,
                column: "PermissionId",
                value: 105);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 256,
                column: "PermissionId",
                value: 106);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 257,
                column: "PermissionId",
                value: 107);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 258,
                column: "PermissionId",
                value: 108);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 259,
                column: "PermissionId",
                value: 109);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 260,
                column: "PermissionId",
                value: 110);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 261,
                column: "PermissionId",
                value: 111);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 262,
                column: "PermissionId",
                value: 112);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 263,
                column: "PermissionId",
                value: 113);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 264,
                column: "PermissionId",
                value: 114);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 265,
                column: "PermissionId",
                value: 115);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 266,
                column: "PermissionId",
                value: 116);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 267,
                column: "PermissionId",
                value: 117);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 268,
                column: "PermissionId",
                value: 118);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 269,
                column: "PermissionId",
                value: 119);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 270,
                column: "PermissionId",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 271,
                column: "PermissionId",
                value: 121);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 272,
                column: "PermissionId",
                value: 122);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 273,
                column: "PermissionId",
                value: 123);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 274,
                column: "PermissionId",
                value: 124);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 275,
                column: "PermissionId",
                value: 125);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 276,
                column: "PermissionId",
                value: 126);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 277,
                column: "PermissionId",
                value: 127);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 278,
                column: "PermissionId",
                value: 128);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 279,
                column: "PermissionId",
                value: 129);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 280,
                column: "PermissionId",
                value: 130);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 281,
                column: "PermissionId",
                value: 131);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 282,
                column: "PermissionId",
                value: 132);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 283,
                column: "PermissionId",
                value: 133);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 284,
                column: "PermissionId",
                value: 134);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 285,
                column: "PermissionId",
                value: 135);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 286,
                column: "PermissionId",
                value: 136);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 287,
                column: "PermissionId",
                value: 137);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 288,
                column: "PermissionId",
                value: 138);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 289,
                column: "PermissionId",
                value: 139);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 290,
                column: "PermissionId",
                value: 140);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 291,
                column: "PermissionId",
                value: 141);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 292,
                column: "PermissionId",
                value: 142);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 293,
                column: "PermissionId",
                value: 143);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 294,
                column: "PermissionId",
                value: 144);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 145, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 146, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 147, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 148, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 149, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 150, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 301,
                column: "PermissionId",
                value: 88);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 302,
                column: "PermissionId",
                value: 89);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 303,
                column: "PermissionId",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 304,
                column: "PermissionId",
                value: 91);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 305,
                column: "PermissionId",
                value: 92);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 306,
                column: "PermissionId",
                value: 93);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 307,
                column: "PermissionId",
                value: 94);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 308,
                column: "PermissionId",
                value: 95);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 309,
                column: "PermissionId",
                value: 96);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 310,
                column: "PermissionId",
                value: 97);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 311,
                column: "PermissionId",
                value: 98);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 312,
                column: "PermissionId",
                value: 99);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 313,
                column: "PermissionId",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 314,
                column: "PermissionId",
                value: 101);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 315,
                column: "PermissionId",
                value: 102);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 316,
                column: "PermissionId",
                value: 103);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 317,
                column: "PermissionId",
                value: 104);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 318,
                column: "PermissionId",
                value: 105);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 319,
                column: "PermissionId",
                value: 106);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 320,
                column: "PermissionId",
                value: 107);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 321,
                column: "PermissionId",
                value: 108);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 322,
                column: "PermissionId",
                value: 109);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 323,
                column: "PermissionId",
                value: 110);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 324,
                column: "PermissionId",
                value: 111);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 325,
                column: "PermissionId",
                value: 112);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 326,
                column: "PermissionId",
                value: 113);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 327,
                column: "PermissionId",
                value: 114);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 328,
                column: "PermissionId",
                value: 115);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 329,
                column: "PermissionId",
                value: 116);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 330,
                column: "PermissionId",
                value: 117);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 331,
                column: "PermissionId",
                value: 118);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 332,
                column: "PermissionId",
                value: 119);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 333,
                column: "PermissionId",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 334,
                column: "PermissionId",
                value: 121);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 335,
                column: "PermissionId",
                value: 122);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 336,
                column: "PermissionId",
                value: 123);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 337,
                column: "PermissionId",
                value: 124);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 338,
                column: "PermissionId",
                value: 125);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 339,
                column: "PermissionId",
                value: 126);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 340,
                column: "PermissionId",
                value: 127);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 341,
                column: "PermissionId",
                value: 128);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 342,
                column: "PermissionId",
                value: 129);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 343,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 130, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 344,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 131, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 345,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 132, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 346,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 133, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 347,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 134, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 348,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 135, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 349,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 148, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 350,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 149, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 351,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 150, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 352,
                column: "PermissionId",
                value: 88);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 353,
                column: "PermissionId",
                value: 89);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 354,
                column: "PermissionId",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 355,
                column: "PermissionId",
                value: 95);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 356,
                column: "PermissionId",
                value: 96);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 357,
                column: "PermissionId",
                value: 97);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 358,
                column: "PermissionId",
                value: 99);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 359,
                column: "PermissionId",
                value: 103);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 360,
                column: "PermissionId",
                value: 104);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 361,
                column: "PermissionId",
                value: 105);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 362,
                column: "PermissionId",
                value: 110);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 363,
                column: "PermissionId",
                value: 111);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 364,
                column: "PermissionId",
                value: 112);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 365,
                column: "PermissionId",
                value: 113);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 366,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 118, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 367,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 119, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 368,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 120, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 369,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 125, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 370,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 126, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 371,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 127, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 372,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 132, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 373,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 133, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 374,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 134, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 375,
                column: "PermissionId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 376,
                column: "PermissionId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 377,
                column: "PermissionId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 378,
                column: "PermissionId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 379,
                column: "PermissionId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 380,
                column: "PermissionId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 381,
                column: "PermissionId",
                value: 31);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 382,
                column: "PermissionId",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 383,
                column: "PermissionId",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 384,
                column: "PermissionId",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 385,
                column: "PermissionId",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 386,
                column: "PermissionId",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 387,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 38, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 388,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 45, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 389,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 52, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 390,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 59, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 391,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 66, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 392,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 73, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 393,
                column: "RoleId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 394,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 87, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 395,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 136, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 396,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 148, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 397,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 149, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 398,
                column: "PermissionId",
                value: 66);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 399,
                column: "PermissionId",
                value: 68);

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 400, 73, 6 },
                    { 401, 136, 6 },
                    { 402, 140, 6 },
                    { 403, 141, 6 },
                    { 404, 80, 6 },
                    { 405, 52, 6 },
                    { 406, 59, 6 },
                    { 407, 15, 6 },
                    { 408, 31, 6 },
                    { 409, 38, 6 },
                    { 410, 45, 6 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2799), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2799) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2801), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2802) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2803), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2804) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2846), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2847) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2848), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2849) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2860), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2861) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2862), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(2863) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$UfBfMSFVz6iMisvL1B3T3O33RxnfBtqasQ61EH9r9TQfLPBmtywYK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 411, 148, 6 },
                    { 412, 149, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CreatedByUserId",
                table: "Notifications",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RecipientId",
                table: "Notifications",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UpdatedByUserId",
                table: "Notifications",
                column: "UpdatedByUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 150);

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
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1651), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1651) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1662), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1663) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1664), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1665) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1667), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1667) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1668), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1669) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1671), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1671) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1673), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1673) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1675), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1675) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1676), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1677) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1679), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1679) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1681), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1681) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1683), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1683) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1684), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1686), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1687) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1688), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1688) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1690), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1690) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1692), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1693) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1695), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1695) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1697), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1697) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1698), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1699) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1700), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1701) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1702), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1702) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1704), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1704) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1706), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1706) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1708), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1708) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1709), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1710) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1711), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1712) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1713), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1713) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1715), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1715) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1717), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1717) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1719), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1719) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1720), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1721) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1723), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1723) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1726), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1726) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1727), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1728) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1729), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1729) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1731), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1731) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1733), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1733) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1734), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1735) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1736), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1737) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1738), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1738) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1740), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1778), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1779) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1780), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1781) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1782), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1782) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1784), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1784) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1786), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1786) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1788), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1788) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1789), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1790) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1791), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1792) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1793), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1793) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1795), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1795) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1797), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1797) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1798), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1799) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1800), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1800) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1802), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1802) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1804), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1804) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1805), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1806) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1807), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1807) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1809), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1809) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1811), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1811) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1812), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1813) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1814), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1815) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1816), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1816) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1819), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1819) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1821), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1822) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1823), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1823) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1825), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1825) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1827), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1827) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1828), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1829) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1830), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1830) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1832), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1832) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1833), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1834) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1835), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1835) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1837), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1837) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1839), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1839) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1840), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1841) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1842), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1842) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1844), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1844) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1845), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1847) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1848), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1848) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1850), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1850) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1852), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1852) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1853), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1854) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1855), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1855) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1857), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1857) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1859), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1859) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1860), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1861) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1862), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1862) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1898), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1898) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1899), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1900) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1901), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1902) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1903), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1903) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1905), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1905) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1907), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1907) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1909), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1909) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1911), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1911) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1912), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1913) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1914), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1915) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1916), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1916) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1918), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1918) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1920), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1920) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1921), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1922) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1923), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1923) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1925), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1925) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1927), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1927) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1928), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1929) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1930), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1930) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1932), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1932) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1934), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1934) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1936), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1936) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1937), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1938) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1939), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1939) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1941), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1941) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1943), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1943) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1944), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1945) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1946), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1946) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1948), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1948) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1949), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1950) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1951), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1951) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1953), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1953) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1955), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1955) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1956), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1957) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1958), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1958) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1960), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1960) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1961), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1962) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1963), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1963) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1966), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1966) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1968), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1968) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2007), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2008) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2009), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2010) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2011), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2011) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2013), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2013) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2015), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2015) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2017), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2017) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2019), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2019) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2020), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2021) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2022), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2022) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2024), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2024) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2026), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2026) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2027), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2028) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2029), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2029) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2031), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2031) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2033), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2034) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2035), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2036) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2037), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2037) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2039), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(2039) });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 3, 2 });

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

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 159,
                column: "PermissionId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 160,
                column: "PermissionId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 161,
                column: "PermissionId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 162,
                column: "PermissionId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 163,
                column: "PermissionId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 164,
                column: "PermissionId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 165,
                column: "PermissionId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 166,
                column: "PermissionId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 167,
                column: "PermissionId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 168,
                column: "PermissionId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 169,
                column: "PermissionId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 170,
                column: "PermissionId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 171,
                column: "PermissionId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 172,
                column: "PermissionId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 173,
                column: "PermissionId",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 174,
                column: "PermissionId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 175,
                column: "PermissionId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 176,
                column: "PermissionId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 177,
                column: "PermissionId",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 178,
                column: "PermissionId",
                value: 31);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 179,
                column: "PermissionId",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 180,
                column: "PermissionId",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 181,
                column: "PermissionId",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 182,
                column: "PermissionId",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 183,
                column: "PermissionId",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 184,
                column: "PermissionId",
                value: 37);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 185,
                column: "PermissionId",
                value: 38);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 186,
                column: "PermissionId",
                value: 39);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 187,
                column: "PermissionId",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 188,
                column: "PermissionId",
                value: 41);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 189,
                column: "PermissionId",
                value: 42);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 190,
                column: "PermissionId",
                value: 43);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 191,
                column: "PermissionId",
                value: 44);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 192,
                column: "PermissionId",
                value: 45);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 193,
                column: "PermissionId",
                value: 46);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 194,
                column: "PermissionId",
                value: 47);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 195,
                column: "PermissionId",
                value: 48);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 196,
                column: "PermissionId",
                value: 49);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 197,
                column: "PermissionId",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 198,
                column: "PermissionId",
                value: 51);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 199,
                column: "PermissionId",
                value: 52);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 200,
                column: "PermissionId",
                value: 53);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 201,
                column: "PermissionId",
                value: 54);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 202,
                column: "PermissionId",
                value: 55);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 203,
                column: "PermissionId",
                value: 56);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 204,
                column: "PermissionId",
                value: 57);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 205,
                column: "PermissionId",
                value: 58);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 206,
                column: "PermissionId",
                value: 59);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 207,
                column: "PermissionId",
                value: 60);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 208,
                column: "PermissionId",
                value: 61);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 209,
                column: "PermissionId",
                value: 62);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 210,
                column: "PermissionId",
                value: 63);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 211,
                column: "PermissionId",
                value: 64);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 212,
                column: "PermissionId",
                value: 65);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 213,
                column: "PermissionId",
                value: 66);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 214,
                column: "PermissionId",
                value: 67);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 215,
                column: "PermissionId",
                value: 68);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 216,
                column: "PermissionId",
                value: 69);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 217,
                column: "PermissionId",
                value: 70);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 218,
                column: "PermissionId",
                value: 71);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 219,
                column: "PermissionId",
                value: 72);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 220,
                column: "PermissionId",
                value: 73);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 221,
                column: "PermissionId",
                value: 74);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 222,
                column: "PermissionId",
                value: 75);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 223,
                column: "PermissionId",
                value: 76);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 224,
                column: "PermissionId",
                value: 77);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 225,
                column: "PermissionId",
                value: 78);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 226,
                column: "PermissionId",
                value: 79);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 227,
                column: "PermissionId",
                value: 80);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 228,
                column: "PermissionId",
                value: 81);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 229,
                column: "PermissionId",
                value: 82);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 230,
                column: "PermissionId",
                value: 83);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 231,
                column: "PermissionId",
                value: 84);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 232,
                column: "PermissionId",
                value: 85);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 233,
                column: "PermissionId",
                value: 86);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 234,
                column: "PermissionId",
                value: 87);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 235,
                column: "PermissionId",
                value: 88);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 236,
                column: "PermissionId",
                value: 89);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 237,
                column: "PermissionId",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 238,
                column: "PermissionId",
                value: 91);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 239,
                column: "PermissionId",
                value: 92);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 240,
                column: "PermissionId",
                value: 93);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 241,
                column: "PermissionId",
                value: 94);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 242,
                column: "PermissionId",
                value: 95);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 243,
                column: "PermissionId",
                value: 96);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 244,
                column: "PermissionId",
                value: 97);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 245,
                column: "PermissionId",
                value: 98);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 246,
                column: "PermissionId",
                value: 99);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 247,
                column: "PermissionId",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 248,
                column: "PermissionId",
                value: 101);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 249,
                column: "PermissionId",
                value: 102);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 250,
                column: "PermissionId",
                value: 103);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 251,
                column: "PermissionId",
                value: 104);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 252,
                column: "PermissionId",
                value: 105);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 253,
                column: "PermissionId",
                value: 106);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 254,
                column: "PermissionId",
                value: 107);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 255,
                column: "PermissionId",
                value: 108);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 256,
                column: "PermissionId",
                value: 109);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 257,
                column: "PermissionId",
                value: 110);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 258,
                column: "PermissionId",
                value: 111);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 259,
                column: "PermissionId",
                value: 112);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 260,
                column: "PermissionId",
                value: 113);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 261,
                column: "PermissionId",
                value: 114);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 262,
                column: "PermissionId",
                value: 115);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 263,
                column: "PermissionId",
                value: 116);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 264,
                column: "PermissionId",
                value: 117);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 265,
                column: "PermissionId",
                value: 118);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 266,
                column: "PermissionId",
                value: 119);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 267,
                column: "PermissionId",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 268,
                column: "PermissionId",
                value: 121);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 269,
                column: "PermissionId",
                value: 122);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 270,
                column: "PermissionId",
                value: 123);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 271,
                column: "PermissionId",
                value: 124);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 272,
                column: "PermissionId",
                value: 125);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 273,
                column: "PermissionId",
                value: 126);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 274,
                column: "PermissionId",
                value: 127);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 275,
                column: "PermissionId",
                value: 128);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 276,
                column: "PermissionId",
                value: 129);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 277,
                column: "PermissionId",
                value: 130);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 278,
                column: "PermissionId",
                value: 131);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 279,
                column: "PermissionId",
                value: 132);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 280,
                column: "PermissionId",
                value: 133);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 281,
                column: "PermissionId",
                value: 134);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 282,
                column: "PermissionId",
                value: 135);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 283,
                column: "PermissionId",
                value: 136);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 284,
                column: "PermissionId",
                value: 137);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 285,
                column: "PermissionId",
                value: 138);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 286,
                column: "PermissionId",
                value: 139);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 287,
                column: "PermissionId",
                value: 140);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 288,
                column: "PermissionId",
                value: 141);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 289,
                column: "PermissionId",
                value: 142);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 290,
                column: "PermissionId",
                value: 143);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 291,
                column: "PermissionId",
                value: 144);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 292,
                column: "PermissionId",
                value: 145);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 293,
                column: "PermissionId",
                value: 146);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 294,
                column: "PermissionId",
                value: 147);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 88, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 89, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 90, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 91, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 92, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 93, 3 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 301,
                column: "PermissionId",
                value: 94);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 302,
                column: "PermissionId",
                value: 95);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 303,
                column: "PermissionId",
                value: 96);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 304,
                column: "PermissionId",
                value: 97);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 305,
                column: "PermissionId",
                value: 98);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 306,
                column: "PermissionId",
                value: 99);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 307,
                column: "PermissionId",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 308,
                column: "PermissionId",
                value: 101);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 309,
                column: "PermissionId",
                value: 102);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 310,
                column: "PermissionId",
                value: 103);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 311,
                column: "PermissionId",
                value: 104);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 312,
                column: "PermissionId",
                value: 105);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 313,
                column: "PermissionId",
                value: 106);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 314,
                column: "PermissionId",
                value: 107);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 315,
                column: "PermissionId",
                value: 108);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 316,
                column: "PermissionId",
                value: 109);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 317,
                column: "PermissionId",
                value: 110);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 318,
                column: "PermissionId",
                value: 111);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 319,
                column: "PermissionId",
                value: 112);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 320,
                column: "PermissionId",
                value: 113);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 321,
                column: "PermissionId",
                value: 114);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 322,
                column: "PermissionId",
                value: 115);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 323,
                column: "PermissionId",
                value: 116);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 324,
                column: "PermissionId",
                value: 117);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 325,
                column: "PermissionId",
                value: 118);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 326,
                column: "PermissionId",
                value: 119);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 327,
                column: "PermissionId",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 328,
                column: "PermissionId",
                value: 121);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 329,
                column: "PermissionId",
                value: 122);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 330,
                column: "PermissionId",
                value: 123);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 331,
                column: "PermissionId",
                value: 124);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 332,
                column: "PermissionId",
                value: 125);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 333,
                column: "PermissionId",
                value: 126);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 334,
                column: "PermissionId",
                value: 127);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 335,
                column: "PermissionId",
                value: 128);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 336,
                column: "PermissionId",
                value: 129);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 337,
                column: "PermissionId",
                value: 130);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 338,
                column: "PermissionId",
                value: 131);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 339,
                column: "PermissionId",
                value: 132);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 340,
                column: "PermissionId",
                value: 133);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 341,
                column: "PermissionId",
                value: 134);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 342,
                column: "PermissionId",
                value: 135);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 343,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 88, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 344,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 89, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 345,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 90, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 346,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 95, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 347,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 96, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 348,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 97, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 349,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 99, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 350,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 103, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 351,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 104, 4 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 352,
                column: "PermissionId",
                value: 105);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 353,
                column: "PermissionId",
                value: 110);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 354,
                column: "PermissionId",
                value: 111);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 355,
                column: "PermissionId",
                value: 112);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 356,
                column: "PermissionId",
                value: 113);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 357,
                column: "PermissionId",
                value: 118);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 358,
                column: "PermissionId",
                value: 119);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 359,
                column: "PermissionId",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 360,
                column: "PermissionId",
                value: 125);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 361,
                column: "PermissionId",
                value: 126);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 362,
                column: "PermissionId",
                value: 127);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 363,
                column: "PermissionId",
                value: 132);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 364,
                column: "PermissionId",
                value: 133);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 365,
                column: "PermissionId",
                value: 134);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 366,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 15, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 367,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 16, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 368,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 17, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 369,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 18, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 370,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 28, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 371,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 29, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 372,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 31, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 373,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 32, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 374,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 33, 5 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 375,
                column: "PermissionId",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 376,
                column: "PermissionId",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 377,
                column: "PermissionId",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 378,
                column: "PermissionId",
                value: 38);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 379,
                column: "PermissionId",
                value: 45);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 380,
                column: "PermissionId",
                value: 52);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 381,
                column: "PermissionId",
                value: 59);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 382,
                column: "PermissionId",
                value: 66);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 383,
                column: "PermissionId",
                value: 73);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 384,
                column: "PermissionId",
                value: 80);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 385,
                column: "PermissionId",
                value: 87);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 386,
                column: "PermissionId",
                value: 136);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 387,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 66, 6 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 388,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 68, 6 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 389,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 73, 6 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 390,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 136, 6 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 391,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 140, 6 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 392,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 141, 6 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 393,
                column: "RoleId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 394,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 52, 6 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 395,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 59, 6 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 396,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 15, 6 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 397,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 31, 6 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 398,
                column: "PermissionId",
                value: 38);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 399,
                column: "PermissionId",
                value: 45);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1487), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1487) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1489), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1490) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1491), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1492) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1493), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1493) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1495), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1495) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1533), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1533) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1540), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1540) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1542), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(1542) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$6rDsi4r2NpvPhhHvaIOfXubMSmYTgE2/XetiOcgjujl6v78NYrGMm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(4158), new DateTime(2026, 3, 7, 5, 24, 48, 504, DateTimeKind.Utc).AddTicks(4158) });
        }
    }
}
