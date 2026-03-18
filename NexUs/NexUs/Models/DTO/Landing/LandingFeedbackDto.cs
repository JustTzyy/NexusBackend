namespace NexUs.Models.DTO.Landing;

public class LandingFeedbackDto
{
    public string CustomerName { get; set; } = string.Empty;
    public string? SubjectName { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }
}
