using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddModulePermissionsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var now = new DateTime(2026, 3, 4, 17, 52, 28, 0, DateTimeKind.Utc);

            // ── Insert new Permissions (IDs 80-121) ──────────────────────────────
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    // Scheduling (80-86)
                    {  80, now, null, null, "View admin scheduling and session list",            "Scheduling",         "ViewScheduling",                    now, null },
                    {  81, now, null, null, "Create new scheduling entries and assign teachers", "Scheduling",         "CreateScheduling",                  now, null },
                    {  82, now, null, null, "Update session assignments and schedules",           "Scheduling",         "UpdateScheduling",                  now, null },
                    {  83, now, null, null, "Cancel or delete scheduled sessions",               "Scheduling",         "DeleteScheduling",                  now, null },
                    {  84, now, null, null, "Archive scheduling entries",                        "Scheduling",         "ArchiveScheduling",                 now, null },
                    {  85, now, null, null, "Restore archived scheduling entries",               "Scheduling",         "RestoreScheduling",                 now, null },
                    {  86, now, null, null, "Permanently delete scheduling entries",             "Scheduling",         "PermanentDeleteScheduling",         now, null },

                    // SchedulingTracking (87)
                    {  87, now, null, null, "View session logs and status history tracking",     "SchedulingTracking", "ViewSchedulingTracking",            now, null },

                    // LeadManagement (88-96)
                    {  88, now, null, null, "View lead list and details",                        "LeadManagement",     "ViewLeads",                         now, null },
                    {  89, now, null, null, "Create new leads",                                  "LeadManagement",     "CreateLeads",                       now, null },
                    {  90, now, null, null, "Update lead details and pipeline status",           "LeadManagement",     "UpdateLeads",                       now, null },
                    {  91, now, null, null, "Delete leads",                                      "LeadManagement",     "DeleteLeads",                       now, null },
                    {  92, now, null, null, "Archive (soft delete) leads",                       "LeadManagement",     "ArchiveLeads",                      now, null },
                    {  93, now, null, null, "Restore archived leads",                            "LeadManagement",     "RestoreLeads",                      now, null },
                    {  94, now, null, null, "Permanently delete leads",                          "LeadManagement",     "PermanentDeleteLeads",              now, null },
                    {  95, now, null, null, "View customer list and details",                    "LeadManagement",     "ViewCustomers",                     now, null },
                    {  96, now, null, null, "Manually convert a lead to a customer",             "LeadManagement",     "ConvertLead",                       now, null },

                    // Campaigns (97-116)
                    {  97, now, null, null, "View campaign list and details",                    "Campaigns",          "ViewCampaigns",                     now, null },
                    {  98, now, null, null, "Create new campaigns",                              "Campaigns",          "CreateCampaigns",                   now, null },
                    {  99, now, null, null, "Update existing campaigns",                         "Campaigns",          "UpdateCampaigns",                   now, null },
                    { 100, now, null, null, "Delete campaigns",                                  "Campaigns",          "DeleteCampaigns",                   now, null },
                    { 101, now, null, null, "Archive (soft delete) campaigns",                   "Campaigns",          "ArchiveCampaigns",                  now, null },
                    { 102, now, null, null, "Restore archived campaigns",                        "Campaigns",          "RestoreCampaigns",                  now, null },
                    { 103, now, null, null, "Permanently delete campaigns",                      "Campaigns",          "PermanentDeleteCampaigns",          now, null },
                    { 104, now, null, null, "Send or schedule email campaigns",                  "Campaigns",          "SendCampaigns",                     now, null },
                    { 105, now, null, null, "View email template list and details",              "Campaigns",          "ViewEmailTemplates",                now, null },
                    { 106, now, null, null, "Create new email templates",                        "Campaigns",          "CreateEmailTemplates",              now, null },
                    { 107, now, null, null, "Update existing email templates",                   "Campaigns",          "UpdateEmailTemplates",              now, null },
                    { 108, now, null, null, "Delete email templates",                            "Campaigns",          "DeleteEmailTemplates",              now, null },
                    { 109, now, null, null, "View audience segment list and details",            "Campaigns",          "ViewSegments",                      now, null },
                    { 110, now, null, null, "Create new audience segments",                      "Campaigns",          "CreateSegments",                    now, null },
                    { 111, now, null, null, "Update existing audience segments",                 "Campaigns",          "UpdateSegments",                    now, null },
                    { 112, now, null, null, "Delete audience segments",                          "Campaigns",          "DeleteSegments",                    now, null },
                    { 113, now, null, null, "View automation rule list and details",             "Campaigns",          "ViewAutomationRules",               now, null },
                    { 114, now, null, null, "Create new automation rules",                       "Campaigns",          "CreateAutomationRules",             now, null },
                    { 115, now, null, null, "Update existing automation rules",                  "Campaigns",          "UpdateAutomationRules",             now, null },
                    { 116, now, null, null, "Delete automation rules",                           "Campaigns",          "DeleteAutomationRules",             now, null },

                    // Reports (117-121)
                    { 117, now, null, null, "View marketing analytics dashboard",                "Reports",            "ViewMarketingAnalytics",            now, null },
                    { 118, now, null, null, "View email message delivery logs",                  "Reports",            "ViewEmailLogs",                     now, null },
                    { 119, now, null, null, "View email suppression list",                       "Reports",            "ViewSuppressions",                  now, null },
                    { 120, now, null, null, "Add or remove email suppressions",                  "Reports",            "ManageSuppressions",                now, null },
                    { 121, now, null, null, "View tutoring session logs and history",            "Reports",            "ViewSessionLogs",                   now, null },
                });

            // ── Assign all new permissions to Super Admin (RoleId=1), IDs 204-245 ──
            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 204,  80, 1 }, { 205,  81, 1 }, { 206,  82, 1 }, { 207,  83, 1 }, { 208,  84, 1 }, { 209,  85, 1 }, { 210,  86, 1 },
                    { 211,  87, 1 },
                    { 212,  88, 1 }, { 213,  89, 1 }, { 214,  90, 1 }, { 215,  91, 1 }, { 216,  92, 1 }, { 217,  93, 1 }, { 218,  94, 1 }, { 219,  95, 1 }, { 220,  96, 1 },
                    { 221,  97, 1 }, { 222,  98, 1 }, { 223,  99, 1 }, { 224, 100, 1 }, { 225, 101, 1 }, { 226, 102, 1 }, { 227, 103, 1 }, { 228, 104, 1 },
                    { 229, 105, 1 }, { 230, 106, 1 }, { 231, 107, 1 }, { 232, 108, 1 },
                    { 233, 109, 1 }, { 234, 110, 1 }, { 235, 111, 1 }, { 236, 112, 1 },
                    { 237, 113, 1 }, { 238, 114, 1 }, { 239, 115, 1 }, { 240, 116, 1 },
                    { 241, 117, 1 }, { 242, 118, 1 }, { 243, 119, 1 }, { 244, 120, 1 }, { 245, 121, 1 },
                });

            // ── Assign all new permissions to Admin (RoleId=2), IDs 246-287 ──
            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 246,  80, 2 }, { 247,  81, 2 }, { 248,  82, 2 }, { 249,  83, 2 }, { 250,  84, 2 }, { 251,  85, 2 }, { 252,  86, 2 },
                    { 253,  87, 2 },
                    { 254,  88, 2 }, { 255,  89, 2 }, { 256,  90, 2 }, { 257,  91, 2 }, { 258,  92, 2 }, { 259,  93, 2 }, { 260,  94, 2 }, { 261,  95, 2 }, { 262,  96, 2 },
                    { 263,  97, 2 }, { 264,  98, 2 }, { 265,  99, 2 }, { 266, 100, 2 }, { 267, 101, 2 }, { 268, 102, 2 }, { 269, 103, 2 }, { 270, 104, 2 },
                    { 271, 105, 2 }, { 272, 106, 2 }, { 273, 107, 2 }, { 274, 108, 2 },
                    { 275, 109, 2 }, { 276, 110, 2 }, { 277, 111, 2 }, { 278, 112, 2 },
                    { 279, 113, 2 }, { 280, 114, 2 }, { 281, 115, 2 }, { 282, 116, 2 },
                    { 283, 117, 2 }, { 284, 118, 2 }, { 285, 119, 2 }, { 286, 120, 2 }, { 287, 121, 2 },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove Role_Permissions for Admin (IDs 246-287)
            for (int id = 246; id <= 287; id++)
                migrationBuilder.DeleteData(table: "Role_Permissions", keyColumn: "Id", keyValue: id);

            // Remove Role_Permissions for Super Admin (IDs 204-245)
            for (int id = 204; id <= 245; id++)
                migrationBuilder.DeleteData(table: "Role_Permissions", keyColumn: "Id", keyValue: id);

            // Remove Permissions (IDs 80-121)
            for (int id = 80; id <= 121; id++)
                migrationBuilder.DeleteData(table: "Permissions", keyColumn: "Id", keyValue: id);
        }
    }
}
