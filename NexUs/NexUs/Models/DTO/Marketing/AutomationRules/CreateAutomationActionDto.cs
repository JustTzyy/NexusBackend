namespace NexUs.Models.DTO.Marketing
{
    public class CreateAutomationActionDto
    {
        public string ActionType { get; set; } = "SendEmail";
        public int? EmailTemplateId { get; set; }
        public int DelayMinutes { get; set; } = 0;
        public int SortOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;
    }
}
