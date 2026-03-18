namespace NexUs.Models.DTO.TeacherAssignments
{
    public class CreateTeacherAssignmentDto
    {
        public int TeacherId { get; set; }
        public int BuildingId { get; set; }
        public int DepartmentId { get; set; }
    }
}
