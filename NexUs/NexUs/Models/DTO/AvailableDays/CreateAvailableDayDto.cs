namespace NexUs.Models.DTO.AvailableDays
{
    public class CreateAvailableDayDto
    {
        public string DayName { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
