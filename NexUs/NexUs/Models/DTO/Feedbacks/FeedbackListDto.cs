namespace NexUs.Models.DTO.Feedbacks
{
    public class FeedbackListDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string TeacherName { get; set; } = string.Empty;
        public string? SubjectName { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime SessionDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
