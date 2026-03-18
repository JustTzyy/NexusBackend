using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddMarketingAutomation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutomationRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TriggerType = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ConditionsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomationRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutomationRules_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutomationRules_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Variables = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailTemplates_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmailTemplates_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ConvertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leads_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leads_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leads_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RulesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Segments_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segments_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suppressions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppressions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppressions_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suppressions_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutomationActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutomationRuleId = table.Column<int>(type: "int", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailTemplateId = table.Column<int>(type: "int", nullable: true),
                    DelayMinutes = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomationActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutomationActions_AutomationRules_AutomationRuleId",
                        column: x => x.AutomationRuleId,
                        principalTable: "AutomationRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutomationActions_EmailTemplates_EmailTemplateId",
                        column: x => x.EmailTemplateId,
                        principalTable: "EmailTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AutomationActions_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutomationActions_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LeadId = table.Column<int>(type: "int", nullable: true),
                    FirstTutoringRequestId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Customers_TutoringRequests_FirstTutoringRequestId",
                        column: x => x.FirstTutoringRequestId,
                        principalTable: "TutoringRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Customers_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    EmailTemplateId = table.Column<int>(type: "int", nullable: true),
                    SegmentId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalTargets = table.Column<int>(type: "int", nullable: false),
                    SentCount = table.Column<int>(type: "int", nullable: false),
                    FailedCount = table.Column<int>(type: "int", nullable: false),
                    SuppressedCount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_EmailTemplates_EmailTemplateId",
                        column: x => x.EmailTemplateId,
                        principalTable: "EmailTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Campaigns_Segments_SegmentId",
                        column: x => x.SegmentId,
                        principalTable: "Segments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Campaigns_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaigns_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignTargets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignTargets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignTargets_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignTargets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "EmailMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: true),
                    AutomationRuleId = table.Column<int>(type: "int", nullable: true),
                    EmailTemplateId = table.Column<int>(type: "int", nullable: true),
                    RecipientUserId = table.Column<int>(type: "int", nullable: true),
                    RecipientEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RecipientName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    QueuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FailedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RetryCount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailMessages_AutomationRules_AutomationRuleId",
                        column: x => x.AutomationRuleId,
                        principalTable: "AutomationRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_EmailMessages_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_EmailMessages_EmailTemplates_EmailTemplateId",
                        column: x => x.EmailTemplateId,
                        principalTable: "EmailTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_EmailMessages_Users_RecipientUserId",
                        column: x => x.RecipientUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "EmailEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailMessageId = table.Column<int>(type: "int", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OccurredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailEvents_EmailMessages_EmailMessageId",
                        column: x => x.EmailMessageId,
                        principalTable: "EmailMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6201), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6201) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6211), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6212) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6214), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6214) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6215), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6216) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6217), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6218) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6242), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6243) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6244), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6245) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6246), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6247) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6248), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6249) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6251), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6251) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6253), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6253) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6255), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6255) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6257), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6257) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6258), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6259) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6260), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6262), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6262) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6264), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6264) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6266), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6267) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6268), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6268) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6270) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6272), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6272) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6273), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6274) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6275), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6276) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6277), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6277) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6279), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6279) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6281), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6281) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6283), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6283) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6285), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6285) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6287), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6287) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6288), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6289) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6290), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6292), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6292) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6294), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6294) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6296), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6296) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6298), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6298) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6299), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6301), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6301) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6303), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6303) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6305), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6305) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6307), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6307) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6308), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6309) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6312), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6312) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6313), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6314) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6315), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6315) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6317), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6317) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6319), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6319) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6320), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6321) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6322), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6322) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6324), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6324) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6325), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6326) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6327), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6327) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6350), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6351) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6352), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6353) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6354), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6355) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6356), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6357) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6358), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6358) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6360), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6360) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6363), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6363) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6365), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6365) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6366), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6367) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6368), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6369) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6370), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6370) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6372), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6372) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6373), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6374) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6376), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6376) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6378), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6378) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6380), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6380) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6381), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6382) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6383), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6383) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6385), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6385) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6387), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6387) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6388), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6389) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6390), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6390) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6392), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6392) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6394), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6394) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6395), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6396) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6397), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6397) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6399), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6399) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6046), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6046) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6048), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6049) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6051), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6051) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6052), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6053) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6054), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6054) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6056), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6056) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6065), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6066) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6067), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6067) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$ZgPnrAVE9vF1BaOd2En8oeDrCfSyb9FgHlWT2Au4vXyVfjOKn6DB2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6668), new DateTime(2026, 2, 28, 4, 10, 58, 146, DateTimeKind.Utc).AddTicks(6668) });

            migrationBuilder.CreateIndex(
                name: "IX_AutomationActions_AutomationRuleId",
                table: "AutomationActions",
                column: "AutomationRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_AutomationActions_CreatedBy",
                table: "AutomationActions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AutomationActions_EmailTemplateId",
                table: "AutomationActions",
                column: "EmailTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_AutomationActions_UpdatedBy",
                table: "AutomationActions",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AutomationRules_CreatedBy",
                table: "AutomationRules",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AutomationRules_IsActive",
                table: "AutomationRules",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_AutomationRules_TriggerType",
                table: "AutomationRules",
                column: "TriggerType");

            migrationBuilder.CreateIndex(
                name: "IX_AutomationRules_UpdatedBy",
                table: "AutomationRules",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_CreatedBy",
                table: "Campaigns",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_EmailTemplateId",
                table: "Campaigns",
                column: "EmailTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_ScheduledAt",
                table: "Campaigns",
                column: "ScheduledAt");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_SegmentId",
                table: "Campaigns",
                column: "SegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_Status",
                table: "Campaigns",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_UpdatedBy",
                table: "Campaigns",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTargets_CampaignId",
                table: "CampaignTargets",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTargets_CampaignId_Email",
                table: "CampaignTargets",
                columns: new[] { "CampaignId", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTargets_Status",
                table: "CampaignTargets",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTargets_UserId",
                table: "CampaignTargets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreatedBy",
                table: "Customers",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FirstTutoringRequestId",
                table: "Customers",
                column: "FirstTutoringRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LeadId",
                table: "Customers",
                column: "LeadId",
                unique: true,
                filter: "[LeadId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UpdatedBy",
                table: "Customers",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailEvents_EmailMessageId",
                table: "EmailEvents",
                column: "EmailMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailEvents_EventType",
                table: "EmailEvents",
                column: "EventType");

            migrationBuilder.CreateIndex(
                name: "IX_EmailMessages_AutomationRuleId",
                table: "EmailMessages",
                column: "AutomationRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailMessages_CampaignId",
                table: "EmailMessages",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailMessages_EmailTemplateId",
                table: "EmailMessages",
                column: "EmailTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailMessages_QueuedAt",
                table: "EmailMessages",
                column: "QueuedAt");

            migrationBuilder.CreateIndex(
                name: "IX_EmailMessages_RecipientEmail",
                table: "EmailMessages",
                column: "RecipientEmail");

            migrationBuilder.CreateIndex(
                name: "IX_EmailMessages_RecipientUserId",
                table: "EmailMessages",
                column: "RecipientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailMessages_Status",
                table: "EmailMessages",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_CreatedBy",
                table: "EmailTemplates",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_FileName",
                table: "EmailTemplates",
                column: "FileName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_Name",
                table: "EmailTemplates",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_UpdatedBy",
                table: "EmailTemplates",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_CreatedBy",
                table: "Leads",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_Email",
                table: "Leads",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leads_Status",
                table: "Leads",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_UpdatedBy",
                table: "Leads",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_UserId",
                table: "Leads",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_CreatedBy",
                table: "Segments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_Name",
                table: "Segments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Segments_UpdatedBy",
                table: "Segments",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Suppressions_CreatedBy",
                table: "Suppressions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Suppressions_Email",
                table: "Suppressions",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppressions_UpdatedBy",
                table: "Suppressions",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutomationActions");

            migrationBuilder.DropTable(
                name: "CampaignTargets");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "EmailEvents");

            migrationBuilder.DropTable(
                name: "Suppressions");

            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "EmailMessages");

            migrationBuilder.DropTable(
                name: "AutomationRules");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "Segments");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1401), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1402) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1411), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1412) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1415), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1415) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1417), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1417) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1419), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1419) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1421), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1422) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1423), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1424) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1426), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1426) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1428), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1428) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1431), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1431) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1433), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1433) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1434), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1435) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1436), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1437) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1439), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1439) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1440), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1441) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1442), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1442) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1444), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1444) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1447), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1448) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1451), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1451) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1453), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1453) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1456), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1456) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1458), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1458) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1460), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1461) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1462), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1462) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1465), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1465) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1467), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1467) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1469), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1469) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1471), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1472) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1473), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1474) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1475), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1476) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1478), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1478) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1481), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1481) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1482), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1483) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1485), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1486) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1489), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1489) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1491), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1491) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1493), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1494) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1495), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1496) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1497), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1498) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1499), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1499) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1501), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1501) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1503), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1503) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1505), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1505) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1506), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1507) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1556), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1557) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1558), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1559) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1560), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1561) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1562), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1563) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1564), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1564) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1566), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1566) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1568), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1568) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1570), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1570) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1572), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1572) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1573), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1574) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1575), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1575) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1577), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1577) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1579), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1579) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1581), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1581) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1583), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1584) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1585), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1586) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1587), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1587) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1589), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1589) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1591), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1591) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1592), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1593) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1594), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1595) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1597), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1597) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1599), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1599) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1600), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1601) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1602), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1603) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1604), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1604) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1606), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1606) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1608), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1608) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1609), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1612), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1613) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1614), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1614) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1616), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1616) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1618), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1618) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1622), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1623) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1624), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1624) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1184), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1185) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1188), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1188) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1191), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1191) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1194), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1195) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1196), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1197) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1199), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1199) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1206), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1207) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1209), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1209) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$5qzSP7CaRIOYIYhohiZcFetp9bxTt.Tane8N8Ooa1WIxh9ys/Z7Ei");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1973), new DateTime(2026, 2, 26, 4, 7, 49, 265, DateTimeKind.Utc).AddTicks(1973) });
        }
    }
}
