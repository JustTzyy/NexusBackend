namespace NexUs.Models.DTO.Notifications
{
    public class CreateNotificationDto
    {
        public int? RecipientUserId { get; set; }
        public string? RecipientRole { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = "General";
        public string Priority { get; set; } = "Normal";
        public int? ReferenceId { get; set; }
        public string? ReferenceType { get; set; }
    }
}
