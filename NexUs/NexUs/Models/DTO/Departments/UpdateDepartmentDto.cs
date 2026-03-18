namespace NexUs.Models.DTO.Departments
{
    public class UpdateDepartmentDto
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
