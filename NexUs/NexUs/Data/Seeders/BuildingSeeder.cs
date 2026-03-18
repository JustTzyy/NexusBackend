using NexUs.Models.Entities;
using NexUs.Utilities;

namespace NexUs.Data.Seeders
{
    public static class BuildingSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (context.Buildings.Any()) return;

            var now = DateTimeHelper.PhilippineNow;

            var buildings = new List<Building>
            {
                new() { Name = "Main Academic Building", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Science Complex", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Engineering Hall", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Business Center", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Liberal Arts Building", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Technology Hub", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Health Sciences Building", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Student Center", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Research Annex", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Graduate Studies Building", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Innovation Center", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Learning Resource Center", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Education Building", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Administration Building", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Multimedia Arts Building", IsActive = true, CreatedAt = now, UpdatedAt = now },
            };

            context.Buildings.AddRange(buildings);
            await context.SaveChangesAsync();
        }
    }
}
