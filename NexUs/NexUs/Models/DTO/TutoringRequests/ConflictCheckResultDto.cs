namespace NexUs.Models.DTO.TutoringRequests
{
    public class ConflictCheckResultDto
    {
        /// <summary>Day+TimeSlot combos where the teacher is already booked</summary>
        public List<BusySlotDto> TeacherBusy { get; set; } = new();
        /// <summary>Room+Day+TimeSlot combos where the room is already booked</summary>
        public List<BusyRoomSlotDto> RoomBusy { get; set; } = new();
        /// <summary>
        /// Distinct day IDs the teacher has marked as available.
        /// Empty = teacher has no availability set → show all days (fallback).
        /// </summary>
        public List<int> TeacherAvailableDayIds { get; set; } = new();
        /// <summary>
        /// All (dayId, timeSlotId) pairs the teacher has enabled.
        /// Empty = no restriction.
        /// </summary>
        public List<TeacherAvailableSlotDto> TeacherAvailableSlots { get; set; } = new();
    }

    public class TeacherAvailableSlotDto
    {
        public int DayId { get; set; }
        public int TimeSlotId { get; set; }
    }

    public class BusySlotDto
    {
        public int DayId { get; set; }
        public int TimeSlotId { get; set; }
    }

    public class BusyRoomSlotDto
    {
        public int RoomId { get; set; }
        public int DayId { get; set; }
        public int TimeSlotId { get; set; }
    }
}
