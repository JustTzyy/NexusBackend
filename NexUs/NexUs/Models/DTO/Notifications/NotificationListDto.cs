namespace NexUs.Models.DTO.Notifications
{
    public class NotificationListDto
    {
        public int Id { get; set; }
        public int? RecipientUserId { get; set; }
        public string? RecipientRole { get; set; }
        public string? RecipientName { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime? ReadAt { get; set; }
        public int? ReferenceId { get; set; }
        public string? ReferenceType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
