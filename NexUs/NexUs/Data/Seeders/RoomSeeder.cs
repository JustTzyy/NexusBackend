using NexUs.Models.Entities;
using NexUs.Utilities;

namespace NexUs.Data.Seeders
{
    public static class RoomSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (context.Rooms.Any()) return;

            var now = DateTimeHelper.PhilippineNow;

            var buildings = context.Buildings.ToList();
            if (!buildings.Any()) return;

            var rooms = new List<Room>();
            var roomNames = new[]
            {
                ("Room 101", 30), ("Room 102", 25), ("Room 103", 40),
                ("Room 201", 35), ("Room 202", 20), ("Room 203", 30),
                ("Room 301", 50), ("Room 302", 25), ("Room 303", 30),
                ("Lab 101", 40), ("Lab 102", 35), ("Lab 201", 30),
                ("Lecture Hall A", 100), ("Lecture Hall B", 80), ("Seminar Room 1", 20),
            };

            for (int i = 0; i < roomNames.Length; i++)
            {
                var building = buildings[i % buildings.Count];
                rooms.Add(new Room
                {
                    Name = roomNames[i].Item1,
                    Capacity = roomNames[i].Item2,
                    BuildingId = building.Id,
                    IsActive = true,
                    CreatedAt = now,
                    UpdatedAt = now
                });
            }

            context.Rooms.AddRange(rooms);
            await context.SaveChangesAsync();
        }
    }
}
