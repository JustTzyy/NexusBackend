namespace NexUs.Models.DTO.TeacherAvailabilities
{
    /// <summary>One day+timeslot cell the teacher is available for.</summary>
    public class TeacherAvailabilitySlotDto
    {
        public int DayId { get; set; }
        public int TimeSlotId { get; set; }
    }

    /// <summary>PUT request body — replaces teacher's entire availability.</summary>
    public class UpdateTeacherAvailabilityDto
    {
        public List<TeacherAvailabilitySlotDto> Slots { get; set; } = new();
    }

    /// <summary>GET response with derived lookup sets for the front-end.</summary>
    public class TeacherAvailabilityResultDto
    {
        public int TeacherId { get; set; }
        /// <summary>Distinct day IDs the teacher is available on.</summary>
        public List<int> AvailableDayIds { get; set; } = new();
        /// <summary>All (dayId, timeSlotId) pairs the teacher has enabled.</summary>
        public List<TeacherAvailabilitySlotDto> Slots { get; set; } = new();
    }
}
