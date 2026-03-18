namespace NexUs.Models.Entities
{
    public class AvailableTimeSlot : BaseEntity
    {
        public string Label { get; set; } = string.Empty;
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
