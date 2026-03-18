namespace NexUs.Models.DTO.Marketing
{
    public class CustomerResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? UserFullName { get; set; }
        public string? UserEmail { get; set; }
        public int? LeadId { get; set; }
        public int? FirstTutoringRequestId { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
