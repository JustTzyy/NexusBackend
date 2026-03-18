namespace NexUs.Models.DTO.Users
{
    // ── List item (paginated index) ──────────────────────────────────────────
    public class ClientLogListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Roles { get; set; } = string.Empty;       // e.g. "Lead, Customer"
        public string? BuildingName { get; set; }               // most-recent request building
        public DateTime CreatedAt { get; set; }
    }

    // ── Tutoring request entry inside detail view ────────────────────────────
    public class ClientTransactionDto
    {
        public int Id { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string BuildingName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public bool IsAdminCreated { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? AssignedTeacherName { get; set; }
        public string? RoomName { get; set; }
        public string? DayName { get; set; }
        public string? TimeSlotLabel { get; set; }
    }

    // ── Full detail response ─────────────────────────────────────────────────
    public class ClientDetailDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Roles { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public List<ClientTransactionDto> Transactions { get; set; } = new();
        public List<ClientTransactionDto> OngoingSessions { get; set; } = new();
    }
}
