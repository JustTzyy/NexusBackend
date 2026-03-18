namespace NexUs.Models.DTO.Rooms
{
    public class UpdateRoomDto
    {
        public string? Name { get; set; }
        public int? Capacity { get; set; }
        public bool? IsActive { get; set; }
        public int? BuildingId { get; set; }
    }
}
