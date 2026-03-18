namespace NexUs.Models.Entities
{
    /// <summary>
    /// Records one day+timeslot combination that a teacher has marked as available.
    /// </summary>
    public class TeacherAvailability : BaseEntity
    {
        public int TeacherId { get; set; }
        public int AvailableDayId { get; set; }
        public int AvailableTimeSlotId { get; set; }

        // Navigation Properties
        public User Teacher { get; set; } = null!;
        public AvailableDay AvailableDay { get; set; } = null!;
        public AvailableTimeSlot AvailableTimeSlot { get; set; } = null!;
    }
}
