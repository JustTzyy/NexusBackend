using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class SeedMarketingTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ── Email Templates ──────────────────────────────────────────────────
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT EmailTemplates ON;

MERGE INTO EmailTemplates AS target
USING (VALUES
    (1,  'Marketing Welcome',       'Welcome to {{CompanyName}}',                 'MarketingWelcomeTemplate.html',       '{{RecipientName}},{{CompanyName}},{{LoginUrl}},{{UnsubscribeUrl}},{{Year}}',                                                                                        'Automation',    1),
    (2,  'Marketing Conversion',    'Congratulations on Your First Booking!',      'MarketingConversionTemplate.html',    '{{RecipientName}},{{CompanyName}},{{LoginUrl}},{{UnsubscribeUrl}},{{Year}}',                                                                                        'Automation',    1),
    (3,  'Marketing Lead Nurture',  'Your Learning Journey Awaits',                'MarketingLeadNurtureTemplate.html',   '{{RecipientName}},{{CompanyName}},{{LoginUrl}},{{UnsubscribeUrl}},{{Year}}',                                                                                        'Automation',    1),
    (4,  'Marketing Campaign Base', '{{CampaignSubject}}',                         'MarketingCampaignTemplate.html',      '{{RecipientName}},{{CompanyName}},{{CampaignSubject}},{{LoginUrl}},{{UnsubscribeUrl}},{{Year}}',                                                                    'Campaign',      1),
    (5,  'OTP Verification',        'Verify Your Email',                           'OtpVerificationEmailTemplate.html',   '{{CompanyName}},{{UserEmail}},{{OtpCode}},{{Year}}',                                                                                                              'Transactional', 1),
    (6,  'Password Reset',          'Reset Your Password',                         'PasswordResetEmailTemplate.html',     '{{UserName}},{{CompanyName}},{{ResetLink}},{{Year}}',                                                                                                             'Transactional', 1),
    (7,  'Schedule Assigned',       'Session Assignment',                          'ScheduleAssignedEmailTemplate.html',  '{{CompanyName}},{{TeacherName}},{{SubjectName}},{{StudentName}},{{RoomName}},{{DayName}},{{TimeSlot}},{{Year}}',                                                    'Transactional', 1),
    (8,  'Schedule Confirmed',      'Session Confirmed',                           'ScheduleConfirmedEmailTemplate.html', '{{CompanyName}},{{RecipientName}},{{SubjectName}},{{TeacherName}},{{StudentName}},{{DayName}},{{TimeSlot}},{{StartDate}},{{Year}}',                                'Transactional', 1),
    (9,  'Session Reminder',        'Upcoming Session Reminder',                   'SessionReminderEmailTemplate.html',   '{{RecipientName}},{{SessionDate}},{{SubjectName}},{{TeacherName}},{{StudentName}},{{DayName}},{{TimeSlot}},{{RoomName}},{{BuildingName}},{{CompanyName}},{{Year}}', 'Transactional', 1),
    (10, 'Admin Session Cancelled', 'Session Cancelled',                           'AdminCancelEmailTemplate.html',       '{{CompanyName}},{{RecipientName}},{{SubjectName}},{{StudentName}},{{TeacherName}},{{BuildingName}},{{CancelledAt}},{{CancellationReason}},{{Year}}',               'Transactional', 1),
    (11, 'Welcome Email',           'Welcome to {{CompanyName}}',                  'WelcomeEmailTemplate.html',           '{{CompanyName}},{{UserName}},{{Email}},{{DefaultPassword}},{{Roles}},{{LoginUrl}},{{Year}}',                                                                      'Welcome',       1),
    (12, 'Welcome New User',        'Welcome to {{CompanyName}}',                  'WelcomeNewUserEmailTemplate.html',    '{{CompanyName}},{{UserName}},{{SetupUrl}},{{Year}}',                                                                                                              'Welcome',       1)
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

            // ── Automation Rules ─────────────────────────────────────────────────
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT AutomationRules ON;

MERGE INTO AutomationRules AS target
USING (VALUES
    (1, 'Welcome New Lead',              'LeadCreated',       1),
    (2, 'Congratulate New Customer',     'LeadConverted',     1),
    (3, 'Lead Nurture on Status Change', 'LeadStatusChanged', 1)
) AS source (Id, Name, TriggerType, IsActive)
ON target.Id = source.Id
WHEN MATCHED THEN
    UPDATE SET Name = source.Name, TriggerType = source.TriggerType,
               IsActive = source.IsActive, UpdatedAt = GETUTCDATE()
WHEN NOT MATCHED THEN
    INSERT (Id, Name, TriggerType, IsActive, CreatedAt, UpdatedAt)
    VALUES (source.Id, source.Name, source.TriggerType, source.IsActive, GETUTCDATE(), GETUTCDATE());

SET IDENTITY_INSERT AutomationRules OFF;
");

            // ── Automation Actions (link rules to templates) ─────────────────────
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT AutomationActions ON;

MERGE INTO AutomationActions AS target
USING (VALUES
    (1, 1, 'SendEmail', 1, 0,  1, 1),
    (2, 2, 'SendEmail', 2, 0,  1, 1),
    (3, 3, 'SendEmail', 3, 60, 1, 1)
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
            migrationBuilder.Sql("DELETE FROM AutomationActions WHERE Id IN (1, 2, 3);");
            migrationBuilder.Sql("DELETE FROM AutomationRules   WHERE Id IN (1, 2, 3);");
            migrationBuilder.Sql("DELETE FROM EmailTemplates     WHERE Id IN (1,2,3,4,5,6,7,8,9,10,11,12);");
        }
    }
}
