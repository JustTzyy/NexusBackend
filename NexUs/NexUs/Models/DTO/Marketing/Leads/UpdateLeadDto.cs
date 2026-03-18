namespace NexUs.Models.DTO.Marketing
{
    public class UpdateLeadDto
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string Source { get; set; } = "Manual";
        public string Status { get; set; } = "New";
        public string? Notes { get; set; }
    }
}
