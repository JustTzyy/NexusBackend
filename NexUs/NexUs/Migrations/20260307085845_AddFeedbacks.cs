using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddFeedbacks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutoringRequestId = table.Column<int>(type: "int", nullable: false),
                    SessionLogId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_SessionLogs_SessionLogId",
                        column: x => x.SessionLogId,
                        principalTable: "SessionLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_TutoringRequests_TutoringRequestId",
                        column: x => x.TutoringRequestId,
                        principalTable: "TutoringRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UpdatedBy",
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
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9861), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9861) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9865), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9865) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9867), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9867) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9869), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9869) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9871), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9871) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9874), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9874) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9875), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9876) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9877), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9878) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9879), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9880) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9882), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9882) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9883), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9884) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9885), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9886) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9887), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9887) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9889), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9889) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9891), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9891) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9893), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9893) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9894), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9895) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9923), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9923) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9925), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9925) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9927), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9927) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9929), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9929) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9931), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9931) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9933), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9933) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9935), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9935) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9936), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9937) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9938), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9939) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9940), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9940) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9942), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9942) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9944), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9944) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9946), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9946) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9947), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9948) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9949), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9950) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9951), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9951) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9954), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9954) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9956), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9956) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9957), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9958) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9959), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9959) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9961), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9961) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9964), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9964) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9965), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9966) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9967), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9967) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9969), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9969) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9971), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9971) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9972), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9973) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9974), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9974) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9976), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9976) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9978), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9978) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9979), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9980) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9981), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9982) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9983), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9983) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9985), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9985) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9986), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9987) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9988), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9989) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9990), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9990) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9993), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9995), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9995) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9996), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9997) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9998), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9998) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(2), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(2) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(3), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(4) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(5), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(6) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(7), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(7) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(9), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(9) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(10), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(11) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(34), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(34) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(36), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(36) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(38), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(38) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(39), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(40) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(41), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(42) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(43), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(44) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(45), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(45) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(47), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(47) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(49), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(49) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(51), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(52), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(53) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(54), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(55) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(56), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(56) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(58), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(58) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(60), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(60) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(61), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(62) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(63), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(63) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(65), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(65) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(67), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(67) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(68), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(69) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(70), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(70) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(72), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(72) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(74), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(74) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(75), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(76) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(77), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(78) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(79), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(79) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(81), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(81) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(83), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(83) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(84), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(85) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(86), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(87) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(88), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(88) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(90), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(90) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(91), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(92) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(93), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(94) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(95), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(95) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(97), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(97) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(99), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(100) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(101), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(101) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(103), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(103) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(105), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(105) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(106), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(107) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(108), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(108) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(110), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(110) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(112), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(112) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(113), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(114) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(115), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(115) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(117), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(117) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(119), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(119) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(136), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(137) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(139), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(139) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(140), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(141) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(142), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(143) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(144), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(144) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(146), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(146) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(148), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(148) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(150), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(150) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(152), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(152) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(153), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(154) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(155), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(155) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(157), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(157) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(159), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(159) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(160), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(161) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(162), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(163) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(164), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(164) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(169), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(169) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(170), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(171) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(172), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(173) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(174), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(174) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(176), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(176) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(178), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(178) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(180), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(180) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(181), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(182) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(183), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(183) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(185), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(185) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(187), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(187) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(188), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(189) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(190), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(190) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(192), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(192) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(194), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(194) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(195), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(196) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(197), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(197) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(199), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(199) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(201), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(201) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(202), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(203) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(204), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(204) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9704), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9704) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9707), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9707) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9709), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9710) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9711), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9712) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9714), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9716), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9716) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9725), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9726) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9728), new DateTime(2026, 3, 7, 8, 58, 44, 360, DateTimeKind.Utc).AddTicks(9728) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$m6WTUqFhY5HkqNsPoWtX8uzg5Yh4xh7Gq7OwjMVC7yb2kKPywJ1tq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(2882), new DateTime(2026, 3, 7, 8, 58, 44, 361, DateTimeKind.Utc).AddTicks(2882) });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CreatedBy",
                table: "Feedbacks",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CustomerId",
                table: "Feedbacks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_SessionLogId",
                table: "Feedbacks",
                column: "SessionLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_TeacherId",
                table: "Feedbacks",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_TutoringRequestId",
                table: "Feedbacks",
                column: "TutoringRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UpdatedBy",
                table: "Feedbacks",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

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

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3398), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3398) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3400), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3400) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3401), new DateTime(2026, 3, 7, 7, 56, 17, 508, DateTimeKind.Utc).AddTicks(3402) });

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
        }
    }
}
