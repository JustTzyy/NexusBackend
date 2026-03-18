namespace NexUs.Models.DTO.AvailableDays
{
    public class UpdateAvailableDayDto
    {
        public string? DayName { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
