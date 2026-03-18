namespace NexUs.Models.DTO.StudentAssignments
{
    public class UpdateStudentAssignmentDto
    {
        public int? PreferredBuildingId { get; set; }
        public string? Notes { get; set; }
        public bool ClearPreferredBuilding { get; set; } = false;
        public bool ClearNotes { get; set; } = false;
    }
}
