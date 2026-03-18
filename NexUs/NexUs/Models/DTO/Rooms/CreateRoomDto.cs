namespace NexUs.Models.DTO.Rooms
{
    public class CreateRoomDto
    {
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool IsActive { get; set; } = true;
        public int BuildingId { get; set; }
    }
}
