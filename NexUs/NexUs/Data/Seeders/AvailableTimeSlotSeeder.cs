using NexUs.Models.Entities;
using NexUs.Utilities;

namespace NexUs.Data.Seeders
{
    public static class AvailableTimeSlotSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (context.AvailableTimeSlots.Any()) return;

            var now = DateTimeHelper.PhilippineNow;

            var slots = new List<AvailableTimeSlot>
            {
                new() { Label = "7:00 AM - 8:00 AM", StartTime = "07:00", EndTime = "08:00", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Label = "8:00 AM - 9:00 AM", StartTime = "08:00", EndTime = "09:00", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Label = "9:00 AM - 10:00 AM", StartTime = "09:00", EndTime = "10:00", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Label = "10:00 AM - 11:00 AM", StartTime = "10:00", EndTime = "11:00", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Label = "11:00 AM - 12:00 PM", StartTime = "11:00", EndTime = "12:00", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Label = "12:00 PM - 1:00 PM", StartTime = "12:00", EndTime = "13:00", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Label = "1:00 PM - 2:00 PM", StartTime = "13:00", EndTime = "14:00", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Label = "2:00 PM - 3:00 PM", StartTime = "14:00", EndTime = "15:00", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Label = "3:00 PM - 4:00 PM", StartTime = "15:00", EndTime = "16:00", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Label = "4:00 PM - 5:00 PM", StartTime = "16:00", EndTime = "17:00", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Label = "5:00 PM - 6:00 PM", StartTime = "17:00", EndTime = "18:00", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Label = "6:00 PM - 7:00 PM", StartTime = "18:00", EndTime = "19:00", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Label = "7:00 PM - 8:00 PM", StartTime = "19:00", EndTime = "20:00", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Label = "8:00 PM - 9:00 PM", StartTime = "20:00", EndTime = "21:00", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Label = "9:00 PM - 10:00 PM", StartTime = "21:00", EndTime = "22:00", IsActive = true, CreatedAt = now, UpdatedAt = now },
            };

            context.AvailableTimeSlots.AddRange(slots);
            await context.SaveChangesAsync();
        }
    }
}
