namespace NexUs.Models.DTO.Subjects
{
    public class CreateSubjectDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public int DepartmentId { get; set; }
    }
}
