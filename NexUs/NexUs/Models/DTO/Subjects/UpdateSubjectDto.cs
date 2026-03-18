namespace NexUs.Models.DTO.Subjects
{
    public class UpdateSubjectDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public int? DepartmentId { get; set; }
    }
}
