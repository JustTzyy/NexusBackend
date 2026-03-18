namespace NexUs.Models.DTO.TutoringRequests
{
    public class CreateTutoringRequestDto
    {
        public int BuildingId { get; set; }
        public int DepartmentId { get; set; }
        public int SubjectId { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Priority { get; set; } = "Normal";
    }
}
