using NexUs.Models.Entities;
using NexUs.Utilities;

namespace NexUs.Data.Seeders
{
    public static class DepartmentSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (context.Departments.Any()) return;

            var now = DateTimeHelper.PhilippineNow;

            var departments = new List<Department>
            {
                new() { Name = "Computer Science", Code = "CS", Description = "Study of computation, algorithms, and programming", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Information Technology", Code = "IT", Description = "Application of technology to solve business problems", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Mathematics", Code = "MATH", Description = "Study of numbers, quantities, and shapes", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Physics", Code = "PHYS", Description = "Study of matter, energy, and fundamental forces", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Chemistry", Code = "CHEM", Description = "Study of substances and their interactions", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Biology", Code = "BIO", Description = "Study of living organisms and life processes", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "English", Code = "ENG", Description = "Study of English language and literature", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Accountancy", Code = "ACCT", Description = "Study of financial reporting and auditing", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Business Administration", Code = "BA", Description = "Study of business management and operations", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Civil Engineering", Code = "CE", Description = "Design and construction of infrastructure", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Electrical Engineering", Code = "EE", Description = "Study of electrical systems and electronics", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Mechanical Engineering", Code = "ME", Description = "Design and manufacturing of mechanical systems", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Psychology", Code = "PSY", Description = "Study of mind and behavior", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Education", Code = "EDUC", Description = "Study of teaching methods and pedagogy", IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Nursing", Code = "NUR", Description = "Study of patient care and health sciences", IsActive = true, CreatedAt = now, UpdatedAt = now },
            };

            context.Departments.AddRange(departments);
            await context.SaveChangesAsync();
        }
    }
}
