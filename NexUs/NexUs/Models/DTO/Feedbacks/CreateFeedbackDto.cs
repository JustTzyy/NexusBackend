namespace NexUs.Models.DTO.Feedbacks
{
    public class CreateFeedbackDto
    {
        public int TutoringRequestId { get; set; }
        public int SessionLogId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
