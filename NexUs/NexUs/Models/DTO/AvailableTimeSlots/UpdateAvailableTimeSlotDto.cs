namespace NexUs.Models.DTO.AvailableTimeSlots
{
    public class UpdateAvailableTimeSlotDto
    {
        public string? Label { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public bool? IsActive { get; set; }
    }
}
