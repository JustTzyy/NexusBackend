using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminCreatedTutoringRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutoringRequests_Users_StudentId",
                table: "TutoringRequests");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "TutoringRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdminCreated",
                table: "TutoringRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddForeignKey(
                name: "FK_TutoringRequests_Users_StudentId",
                table: "TutoringRequests",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutoringRequests_Users_StudentId",
                table: "TutoringRequests");

            migrationBuilder.DropColumn(
                name: "IsAdminCreated",
                table: "TutoringRequests");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "TutoringRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4028), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4028) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4032), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4032) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4034), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4035) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4037), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4037) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4039), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4039) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4042), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4042) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4044), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4044) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4046), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4047) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4049), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4049) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4052), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4052) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4054), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4054) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4056), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4057) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4059), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4059) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4061), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4061) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4063), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4064) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4065), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4066) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4068), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4068) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4071), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4071) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4073), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4073) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4140), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4142), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4143) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4144), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4147), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4147) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4149), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4149) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4151), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4151) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4153), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4154) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4155), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4156) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4157), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4158) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4159), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4162), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4162) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4164), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4164) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4166), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4166) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4168), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4168) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4173), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4174) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4177), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4177) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4179), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4179) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4181), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4181) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4183), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4183) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4184), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4185) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4186), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4187) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4188), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4189) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4190), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4190) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4192), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4192) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4194), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4194) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4196), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4196) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4197), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4198) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4199), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4200) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4201), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4202) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4203), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4203) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4205), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4205) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4209), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4211), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4211) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4213), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4213) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4214), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4215) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4216), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4217) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4218), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4220), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4221) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4222), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4223) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4224), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4225) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4226), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4226) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4228), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4228) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4230), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4232), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4232) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4234), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4236), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4236) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4301), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4301) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4304), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4304) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4306), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4307) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4308), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4309) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4310), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4312), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4312) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4314), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4314) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4316), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4316) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4318), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4318) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4322), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4322) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4324), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4324) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4326), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4326) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4328), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4328) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3847), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3847) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3849), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3851), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3852) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3853), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3854) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3855), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3855) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3857), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3857) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3866), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3866) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3868), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(3868) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$e5eveTjDJbCWvrtXfnGm6.0NX8H1Ir37F79UBBZUW4bTtp974drCi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4705), new DateTime(2026, 2, 15, 13, 0, 47, 279, DateTimeKind.Utc).AddTicks(4706) });

            migrationBuilder.AddForeignKey(
                name: "FK_TutoringRequests_Users_StudentId",
                table: "TutoringRequests",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
