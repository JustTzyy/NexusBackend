using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePermissionModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // LeadManagement → Leads (IDs 88-94)
            foreach (var id in new[] { 88, 89, 90, 91, 92, 93, 94 })
                migrationBuilder.UpdateData("Permissions", "Id", id, "Module", "Leads");

            // LeadManagement → Customers (IDs 95-96)
            foreach (var id in new[] { 95, 96 })
                migrationBuilder.UpdateData("Permissions", "Id", id, "Module", "Customers");

            // Campaigns → EmailTemplates (IDs 105-108)
            foreach (var id in new[] { 105, 106, 107, 108 })
                migrationBuilder.UpdateData("Permissions", "Id", id, "Module", "EmailTemplates");

            // Campaigns → Segments (IDs 109-112)
            foreach (var id in new[] { 109, 110, 111, 112 })
                migrationBuilder.UpdateData("Permissions", "Id", id, "Module", "Segments");

            // Campaigns → AutomationRules (IDs 113-116)
            foreach (var id in new[] { 113, 114, 115, 116 })
                migrationBuilder.UpdateData("Permissions", "Id", id, "Module", "AutomationRules");

            // Reports → MarketingAnalytics (ID 117)
            migrationBuilder.UpdateData("Permissions", "Id", 117, "Module", "MarketingAnalytics");

            // Reports → EmailLogs (ID 118)
            migrationBuilder.UpdateData("Permissions", "Id", 118, "Module", "EmailLogs");

            // Reports → Suppressions (IDs 119-120)
            foreach (var id in new[] { 119, 120 })
                migrationBuilder.UpdateData("Permissions", "Id", id, "Module", "Suppressions");

            // Reports → SessionLogs (ID 121)
            migrationBuilder.UpdateData("Permissions", "Id", 121, "Module", "SessionLogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            foreach (var id in new[] { 88, 89, 90, 91, 92, 93, 94, 95, 96 })
                migrationBuilder.UpdateData("Permissions", "Id", id, "Module", "LeadManagement");

            foreach (var id in new[] { 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116 })
                migrationBuilder.UpdateData("Permissions", "Id", id, "Module", "Campaigns");

            foreach (var id in new[] { 117, 118, 119, 120, 121 })
                migrationBuilder.UpdateData("Permissions", "Id", id, "Module", "Reports");
        }
    }
}
