namespace NexUs.Models.DTO.AvailableTimeSlots
{
    public class CreateAvailableTimeSlotDto
    {
        public string Label { get; set; } = string.Empty;
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
