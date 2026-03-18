using NexUs.Models.Entities;
using NexUs.Utilities;

namespace NexUs.Data.Seeders
{
    public static class AvailableDaySeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (context.AvailableDays.Any()) return;

            var now = DateTimeHelper.PhilippineNow;

            var days = new List<AvailableDay>
            {
                new() { DayName = "Monday", SortOrder = 1, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { DayName = "Tuesday", SortOrder = 2, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { DayName = "Wednesday", SortOrder = 3, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { DayName = "Thursday", SortOrder = 4, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { DayName = "Friday", SortOrder = 5, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { DayName = "Saturday", SortOrder = 6, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { DayName = "Sunday", SortOrder = 7, IsActive = true, CreatedAt = now, UpdatedAt = now },
            };

            context.AvailableDays.AddRange(days);
            await context.SaveChangesAsync();
        }
    }
}
