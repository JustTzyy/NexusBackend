namespace NexUs.Models.DTO.Feedbacks
{
    public class FeedbackResponseDto
    {
        public int Id { get; set; }
        public int TutoringRequestId { get; set; }
        public int SessionLogId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int TeacherId { get; set; }
        public string TeacherName { get; set; } = string.Empty;
        public string? SubjectName { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime SessionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
