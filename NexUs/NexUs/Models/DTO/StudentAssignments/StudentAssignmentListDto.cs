namespace NexUs.Models.DTO.StudentAssignments
{
    public class StudentAssignmentListDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int? PreferredBuildingId { get; set; }
        public string? PreferredBuildingName { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
