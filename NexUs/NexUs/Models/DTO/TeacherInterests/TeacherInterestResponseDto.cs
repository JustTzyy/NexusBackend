namespace NexUs.Models.DTO.TeacherInterests
{
    public class TeacherInterestResponseDto
    {
        public int Id { get; set; }
        public int TutoringRequestId { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
