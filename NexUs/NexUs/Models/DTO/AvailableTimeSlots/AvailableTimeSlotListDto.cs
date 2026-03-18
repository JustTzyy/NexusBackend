namespace NexUs.Models.DTO.AvailableTimeSlots
{
    public class AvailableTimeSlotListDto
    {
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
