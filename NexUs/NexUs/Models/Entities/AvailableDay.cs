namespace NexUs.Models.Entities
{
    public class AvailableDay : BaseEntity
    {
        public string DayName { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
