namespace NexUs.Models.DTO.Marketing
{
    public class EmailTemplateResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string? HtmlContent { get; set; }
        public string? Category { get; set; }
        public string? Variables { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedByName { get; set; }
        public string? UpdatedByName { get; set; }
    }
}
