namespace NexUs.Models.DTO.Marketing
{
    public class BuildTargetsResultDto
    {
        public int TotalTargets { get; set; }
        public int SuppressedCount { get; set; }
        public int AlreadySentCount { get; set; }
        public int QueuedCount { get; set; }
    }
}
