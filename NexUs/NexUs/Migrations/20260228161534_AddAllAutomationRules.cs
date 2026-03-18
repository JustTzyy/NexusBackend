using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddAllAutomationRules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ── Automation Rules (all 12 templates covered) ───────────────────────
            // Rules 1-3 already seeded in SeedMarketingTemplates; MERGE ensures
            // they are not duplicated. Rules 4-12 are new (transactional templates).
            // Transactional rules (4-12) are seeded with IsActive=0 because those
            // emails are sent directly by EmailService.cs — they appear in the
            // Automation Rules UI for visibility but don't fire automatically.
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT AutomationRules ON;

MERGE INTO AutomationRules AS target
USING (VALUES
    (1,  'Welcome New Lead',                  'LeadCreated',              NULL, 1),
    (2,  'Congratulate New Customer',          'LeadConverted',            NULL, 1),
    (3,  'Lead Nurture on Status Change',      'LeadStatusChanged',        NULL, 1),
    (4,  'Campaign Email',                     'CampaignSent',             NULL, 0),
    (5,  'OTP Verification',                   'OtpRequested',             NULL, 0),
    (6,  'Password Reset',                     'PasswordResetRequested',   NULL, 0),
    (7,  'Session Assigned',                   'SessionAssigned',          NULL, 0),
    (8,  'Session Confirmed',                  'SessionConfirmed',         NULL, 0),
    (9,  'Session Reminder',                   'SessionReminder',          NULL, 0),
    (10, 'Session Cancelled',                  'SessionCancelled',         NULL, 0),
    (11, 'Welcome Email',                      'UserCreated',              NULL, 0),
    (12, 'Welcome New User',                   'UserRegistered',           NULL, 0)
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

            // ── Automation Actions (one action per rule, each linked to its template)
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT AutomationActions ON;

MERGE INTO AutomationActions AS target
USING (VALUES
    (1,  1,  'SendEmail', 1,  0, 1, 1),
    (2,  2,  'SendEmail', 2,  0, 1, 1),
    (3,  3,  'SendEmail', 3,  0, 1, 1),
    (4,  4,  'SendEmail', 4,  0, 1, 0),
    (5,  5,  'SendEmail', 5,  0, 1, 0),
    (6,  6,  'SendEmail', 6,  0, 1, 0),
    (7,  7,  'SendEmail', 7,  0, 1, 0),
    (8,  8,  'SendEmail', 8,  0, 1, 0),
    (9,  9,  'SendEmail', 9,  0, 1, 0),
    (10, 10, 'SendEmail', 10, 0, 1, 0),
    (11, 11, 'SendEmail', 11, 0, 1, 0),
    (12, 12, 'SendEmail', 12, 0, 1, 0)
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
            migrationBuilder.Sql("DELETE FROM AutomationActions WHERE Id IN (4,5,6,7,8,9,10,11,12);");
            migrationBuilder.Sql("DELETE FROM AutomationRules   WHERE Id IN (4,5,6,7,8,9,10,11,12);");
        }
    }
}
