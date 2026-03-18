using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileCompletedAutomation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // EmailTemplate ID 13 — Profile Completed notification
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT EmailTemplates ON;

MERGE INTO EmailTemplates AS target
USING (VALUES
    (13, 'Profile Completed', 'Your Profile is Complete — Start Exploring!',
         'ProfileCompletedTemplate.html',
         '{{FirstName}},{{CompanyName}},{{LoginUrl}},{{UnsubscribeUrl}},{{Year}}',
         'Automation', 1)
) AS source (Id, Name, Subject, FileName, Variables, Category, IsActive)
ON target.Id = source.Id
WHEN MATCHED THEN
    UPDATE SET Name = source.Name, Subject = source.Subject, FileName = source.FileName,
               Variables = source.Variables, Category = source.Category,
               IsActive = source.IsActive, UpdatedAt = GETUTCDATE()
WHEN NOT MATCHED THEN
    INSERT (Id, Name, Subject, FileName, Variables, Category, IsActive, CreatedAt, UpdatedAt)
    VALUES (source.Id, source.Name, source.Subject, source.FileName, source.Variables,
            source.Category, source.IsActive, GETUTCDATE(), GETUTCDATE());

SET IDENTITY_INSERT EmailTemplates OFF;
");

            // AutomationRule ID 13 — ProfileCompleted trigger
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT AutomationRules ON;

MERGE INTO AutomationRules AS target
USING (VALUES
    (13, 'Profile Setup Completed', 'ProfileCompleted', NULL, 1)
) AS source (Id, Name, TriggerType, ConditionsJson, IsActive)
ON target.Id = source.Id
WHEN MATCHED THEN
    UPDATE SET Name = source.Name, TriggerType = source.TriggerType,
               ConditionsJson = source.ConditionsJson,
               IsActive = source.IsActive, UpdatedAt = GETUTCDATE()
WHEN NOT MATCHED THEN
    INSERT (Id, Name, TriggerType, ConditionsJson, IsActive, CreatedAt, UpdatedAt)
    VALUES (source.Id, source.Name, source.TriggerType, source.ConditionsJson,
            source.IsActive, GETUTCDATE(), GETUTCDATE());

SET IDENTITY_INSERT AutomationRules OFF;
");

            // AutomationAction ID 13 — link rule 13 to template 13
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT AutomationActions ON;

MERGE INTO AutomationActions AS target
USING (VALUES
    (13, 13, 'SendEmail', 13, 0, 1, 1)
) AS source (Id, AutomationRuleId, ActionType, EmailTemplateId, DelayMinutes, SortOrder, IsActive)
ON target.Id = source.Id
WHEN MATCHED THEN
    UPDATE SET AutomationRuleId = source.AutomationRuleId, ActionType = source.ActionType,
               EmailTemplateId = source.EmailTemplateId, DelayMinutes = source.DelayMinutes,
               SortOrder = source.SortOrder, IsActive = source.IsActive, UpdatedAt = GETUTCDATE()
WHEN NOT MATCHED THEN
    INSERT (Id, AutomationRuleId, ActionType, EmailTemplateId, DelayMinutes, SortOrder, IsActive, CreatedAt, UpdatedAt)
    VALUES (source.Id, source.AutomationRuleId, source.ActionType, source.EmailTemplateId,
            source.DelayMinutes, source.SortOrder, source.IsActive, GETUTCDATE(), GETUTCDATE());

SET IDENTITY_INSERT AutomationActions OFF;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AutomationActions WHERE Id = 13;");
            migrationBuilder.Sql("DELETE FROM AutomationRules   WHERE Id = 13;");
            migrationBuilder.Sql("DELETE FROM EmailTemplates     WHERE Id = 13;");
        }
    }
}
