namespace NexUs.Data.Seeders
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAllAsync(ApplicationDbContext context)
        {
            // Seed in dependency order (each seeder skips if table already has data)
            await DepartmentSeeder.SeedAsync(context);
            await SubjectSeeder.SeedAsync(context);
            await BuildingSeeder.SeedAsync(context);
            await RoomSeeder.SeedAsync(context);
            await AvailableDaySeeder.SeedAsync(context);
            await AvailableTimeSlotSeeder.SeedAsync(context);
        }
    }
}
