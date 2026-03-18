namespace NexUs.Models.DTO.AvailableDays
{
    public class AvailableDayListDto
    {
        public int Id { get; set; }
        public string DayName { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
