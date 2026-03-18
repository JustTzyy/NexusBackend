using NexUs.Models.Entities;
using NexUs.Utilities;

namespace NexUs.Data.Seeders
{
    public static class SubjectSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (context.Subjects.Any()) return;

            var now = DateTimeHelper.PhilippineNow;

            // Get departments to reference by name
            var departments = context.Departments.ToList();
            if (!departments.Any()) return;

            Department Dept(string code) => departments.First(d => d.Code == code);

            var subjects = new List<Subject>
            {
                new() { Name = "Introduction to Programming", Description = "Fundamentals of programming using C#", DepartmentId = Dept("CS").Id, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Data Structures and Algorithms", Description = "Study of data organization and algorithm design", DepartmentId = Dept("CS").Id, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Web Development", Description = "Building modern web applications", DepartmentId = Dept("IT").Id, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Database Management Systems", Description = "Design and management of relational databases", DepartmentId = Dept("IT").Id, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Calculus I", Description = "Limits, derivatives, and integrals", DepartmentId = Dept("MATH").Id, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Linear Algebra", Description = "Vectors, matrices, and linear transformations", DepartmentId = Dept("MATH").Id, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "General Physics I", Description = "Mechanics, waves, and thermodynamics", DepartmentId = Dept("PHYS").Id, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "General Chemistry", Description = "Atomic structure, bonding, and reactions", DepartmentId = Dept("CHEM").Id, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "General Biology", Description = "Cell biology, genetics, and ecology", DepartmentId = Dept("BIO").Id, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Technical Writing", Description = "Writing for professional and technical contexts", DepartmentId = Dept("ENG").Id, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Financial Accounting", Description = "Principles of financial accounting and reporting", DepartmentId = Dept("ACCT").Id, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Principles of Management", Description = "Fundamentals of planning, organizing, and leading", DepartmentId = Dept("BA").Id, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Statics of Rigid Bodies", Description = "Analysis of forces on stationary structures", DepartmentId = Dept("CE").Id, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Circuit Analysis", Description = "Fundamentals of electrical circuit theory", DepartmentId = Dept("EE").Id, IsActive = true, CreatedAt = now, UpdatedAt = now },
                new() { Name = "Thermodynamics", Description = "Study of energy, heat, and work", DepartmentId = Dept("ME").Id, IsActive = true, CreatedAt = now, UpdatedAt = now },
            };

            context.Subjects.AddRange(subjects);
            await context.SaveChangesAsync();
        }
    }
}
