namespace NexUs.Models.DTO.TutoringRequests
{
    public class ScheduleSessionDto
    {
        public int AssignedTeacherId { get; set; }
        public int RoomId { get; set; }
        public int AvailableDayId { get; set; }
        public int AvailableTimeSlotId { get; set; }
    }
}
