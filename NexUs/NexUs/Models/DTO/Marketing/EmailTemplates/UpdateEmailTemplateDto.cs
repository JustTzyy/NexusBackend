namespace NexUs.Models.DTO.Marketing
{
    public class UpdateEmailTemplateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string? HtmlContent { get; set; }
        public string? Variables { get; set; }
        public string? Category { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
