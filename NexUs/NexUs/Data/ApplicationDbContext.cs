using Microsoft.EntityFrameworkCore;
using NexUs.Models.Entities;
using NexUs.Utilities;
using BCrypt.Net;

namespace NexUs.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<AuthActivityLog> AuthActivityLogs { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public DbSet<EmailVerificationOtp> EmailVerificationOtps { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<AvailableDay> AvailableDays { get; set; }
        public DbSet<AvailableTimeSlot> AvailableTimeSlots { get; set; }
        public DbSet<TeacherAssignment> TeacherAssignments { get; set; }
        public DbSet<StudentAssignment> StudentAssignments { get; set; }
        public DbSet<TutoringRequest> TutoringRequests { get; set; }
        public DbSet<TeacherInterest> TeacherInterests { get; set; }
        public DbSet<TutoringRequestStatusHistory> TutoringRequestStatusHistories { get; set; }
        public DbSet<TeacherAvailability> TeacherAvailabilities { get; set; }
        public DbSet<SessionLog> SessionLogs { get; set; }

        // Marketing Automation
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignTarget> CampaignTargets { get; set; }
        public DbSet<AutomationRule> AutomationRules { get; set; }
        public DbSet<AutomationAction> AutomationActions { get; set; }
        public DbSet<EmailMessage> EmailMessages { get; set; }
        public DbSet<EmailEvent> EmailEvents { get; set; }
        public DbSet<Suppression> Suppressions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all configurations from assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Seed data
            SeedData(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity &&
                           (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTimeHelper.PhilippineNow;
                }

                entity.UpdatedAt = DateTimeHelper.PhilippineNow;
            }
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Super Admin",
                    Description = "Super Administrator with unrestricted access to all system features",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Role
                {
                    Id = 2,
                    Name = "Admin",
                    Description = "Administrator with full access to manage users, roles, and permissions",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Role
                {
                    Id = 3,
                    Name = "Marketing Manager",
                    Description = "Manages marketing operations and campaigns",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Role
                {
                    Id = 4,
                    Name = "Marketing Staff",
                    Description = "Marketing team member",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Role
                {
                    Id = 5,
                    Name = "Building Manager",
                    Description = "Manages building operations and maintenance",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Role
                {
                    Id = 6,
                    Name = "Teacher",
                    Description = "Educational staff member",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Role
                {
                    Id = 7,
                    Name = "Lead",
                    Description = "Team or project lead",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Role
                {
                    Id = 8,
                    Name = "Customer",
                    Description = "External user or customer",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            // Seed Permissions
            var permissionId = 1;
            var permissions = new List<Permission>();

            // Users module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewUsers", Module = "Users", Description = "View user list and details", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateUsers", Module = "Users", Description = "Create new users", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateUsers", Module = "Users", Description = "Update existing users", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteUsers", Module = "Users", Description = "Delete users", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Roles module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewRoles", Module = "Roles", Description = "View role list and details", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateRoles", Module = "Roles", Description = "Create new roles", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateRoles", Module = "Roles", Description = "Update existing roles", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteRoles", Module = "Roles", Description = "Delete roles", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Permissions module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewPermissions", Module = "Permissions", Description = "View permission list and details", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreatePermissions", Module = "Permissions", Description = "Create new permissions", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdatePermissions", Module = "Permissions", Description = "Update existing permissions", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeletePermissions", Module = "Permissions", Description = "Delete permissions", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // AuditLog module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewAuditLogs", Module = "AuditLog", Description = "View audit log list and details", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // OperationLog module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewOperationLogs", Module = "OperationLog", Description = "View operation log list and details", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Buildings module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewBuildings", Module = "Buildings", Description = "View building list and details", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateBuildings", Module = "Buildings", Description = "Create new buildings", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateBuildings", Module = "Buildings", Description = "Update existing buildings", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteBuildings", Module = "Buildings", Description = "Delete buildings", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Archive, Restore, PermanentDelete permissions for Users
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveUsers", Module = "Users", Description = "Archive (soft delete) users", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreUsers", Module = "Users", Description = "Restore archived users", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteUsers", Module = "Users", Description = "Permanently delete users", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Archive, Restore, PermanentDelete permissions for Roles
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveRoles", Module = "Roles", Description = "Archive (soft delete) roles", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreRoles", Module = "Roles", Description = "Restore archived roles", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteRoles", Module = "Roles", Description = "Permanently delete roles", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Archive, Restore, PermanentDelete permissions for Permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchivePermissions", Module = "Permissions", Description = "Archive (soft delete) permissions", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestorePermissions", Module = "Permissions", Description = "Restore archived permissions", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeletePermissions", Module = "Permissions", Description = "Permanently delete permissions", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Archive, Restore, PermanentDelete permissions for Buildings
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveBuildings", Module = "Buildings", Description = "Archive (soft delete) buildings", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreBuildings", Module = "Buildings", Description = "Restore archived buildings", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteBuildings", Module = "Buildings", Description = "Permanently delete buildings", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Rooms module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewRooms", Module = "Rooms", Description = "View room list and details", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateRooms", Module = "Rooms", Description = "Create new rooms", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateRooms", Module = "Rooms", Description = "Update existing rooms", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteRooms", Module = "Rooms", Description = "Delete rooms", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Archive, Restore, PermanentDelete permissions for Rooms
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveRooms", Module = "Rooms", Description = "Archive (soft delete) rooms", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreRooms", Module = "Rooms", Description = "Restore archived rooms", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteRooms", Module = "Rooms", Description = "Permanently delete rooms", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Departments module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewDepartments", Module = "Departments", Description = "View department list and details", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateDepartments", Module = "Departments", Description = "Create new departments", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateDepartments", Module = "Departments", Description = "Update existing departments", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteDepartments", Module = "Departments", Description = "Delete departments", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveDepartments", Module = "Departments", Description = "Archive (soft delete) departments", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreDepartments", Module = "Departments", Description = "Restore archived departments", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteDepartments", Module = "Departments", Description = "Permanently delete departments", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Subjects module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewSubjects", Module = "Subjects", Description = "View subject list and details", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateSubjects", Module = "Subjects", Description = "Create new subjects", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateSubjects", Module = "Subjects", Description = "Update existing subjects", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteSubjects", Module = "Subjects", Description = "Delete subjects", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveSubjects", Module = "Subjects", Description = "Archive (soft delete) subjects", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreSubjects", Module = "Subjects", Description = "Restore archived subjects", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteSubjects", Module = "Subjects", Description = "Permanently delete subjects", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // AvailableDays module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewAvailableDays", Module = "AvailableDays", Description = "View available day list and details", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateAvailableDays", Module = "AvailableDays", Description = "Create new available days", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateAvailableDays", Module = "AvailableDays", Description = "Update existing available days", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteAvailableDays", Module = "AvailableDays", Description = "Delete available days", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveAvailableDays", Module = "AvailableDays", Description = "Archive (soft delete) available days", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreAvailableDays", Module = "AvailableDays", Description = "Restore archived available days", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteAvailableDays", Module = "AvailableDays", Description = "Permanently delete available days", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // AvailableTimeSlots module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewAvailableTimeSlots", Module = "AvailableTimeSlots", Description = "View time slot list and details", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateAvailableTimeSlots", Module = "AvailableTimeSlots", Description = "Create new time slots", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateAvailableTimeSlots", Module = "AvailableTimeSlots", Description = "Update existing time slots", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteAvailableTimeSlots", Module = "AvailableTimeSlots", Description = "Delete time slots", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveAvailableTimeSlots", Module = "AvailableTimeSlots", Description = "Archive (soft delete) time slots", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreAvailableTimeSlots", Module = "AvailableTimeSlots", Description = "Restore archived time slots", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteAvailableTimeSlots", Module = "AvailableTimeSlots", Description = "Permanently delete time slots", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // TeacherAssignments module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewTeacherAssignments", Module = "TeacherAssignments", Description = "View teacher assignment list and details", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateTeacherAssignments", Module = "TeacherAssignments", Description = "Create new teacher assignments", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateTeacherAssignments", Module = "TeacherAssignments", Description = "Update existing teacher assignments", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteTeacherAssignments", Module = "TeacherAssignments", Description = "Delete teacher assignments", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveTeacherAssignments", Module = "TeacherAssignments", Description = "Archive (soft delete) teacher assignments", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreTeacherAssignments", Module = "TeacherAssignments", Description = "Restore archived teacher assignments", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteTeacherAssignments", Module = "TeacherAssignments", Description = "Permanently delete teacher assignments", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // TutoringRequests module permissions (Schedule Configuration — student-initiated flow)
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewTutoringRequests", Module = "TutoringRequests", Description = "View tutoring request list and details", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateTutoringRequests", Module = "TutoringRequests", Description = "Create new tutoring requests", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateTutoringRequests", Module = "TutoringRequests", Description = "Update existing tutoring requests", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteTutoringRequests", Module = "TutoringRequests", Description = "Delete tutoring requests", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveTutoringRequests", Module = "TutoringRequests", Description = "Archive (soft delete) tutoring requests", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreTutoringRequests", Module = "TutoringRequests", Description = "Restore archived tutoring requests", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteTutoringRequests", Module = "TutoringRequests", Description = "Permanently delete tutoring requests", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Scheduling module permissions (Admin Scheduling — admin-initiated flow)
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewScheduling",           Module = "Scheduling", Description = "View admin scheduling and session list",           CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateScheduling",         Module = "Scheduling", Description = "Create new scheduling entries and assign teachers", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateScheduling",         Module = "Scheduling", Description = "Update session assignments and schedules",           CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteScheduling",         Module = "Scheduling", Description = "Cancel or delete scheduled sessions",               CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveScheduling",        Module = "Scheduling", Description = "Archive scheduling entries",                        CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreScheduling",        Module = "Scheduling", Description = "Restore archived scheduling entries",                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteScheduling",Module = "Scheduling", Description = "Permanently delete scheduling entries",              CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // SchedulingTracking module permissions (Admin Request Tracking — /admin-scheduling/tracking)
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewSchedulingTracking", Module = "SchedulingTracking", Description = "View session logs and status history tracking", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Leads module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewLeads",               Module = "Leads", Description = "View lead list and details",            CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateLeads",             Module = "Leads", Description = "Create new leads",                      CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateLeads",             Module = "Leads", Description = "Update lead details and pipeline status",CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteLeads",             Module = "Leads", Description = "Delete leads",                          CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveLeads",            Module = "Leads", Description = "Archive (soft delete) leads",           CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreLeads",            Module = "Leads", Description = "Restore archived leads",                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteLeads",    Module = "Leads", Description = "Permanently delete leads",              CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Customers module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewCustomers",                Module = "Customers", Description = "View customer list and details",        CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateCustomers",              Module = "Customers", Description = "Create new customers",                   CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateCustomers",              Module = "Customers", Description = "Update existing customers",               CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteCustomers",              Module = "Customers", Description = "Delete customers",                       CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "ConvertLead",                  Module = "Customers", Description = "Manually convert a lead to a customer", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveCustomers",             Module = "Customers", Description = "Archive (soft delete) customers",        CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreCustomers",             Module = "Customers", Description = "Restore archived customers",              CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteCustomers",     Module = "Customers", Description = "Permanently delete customers",            CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Campaigns module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewCampaigns",           Module = "Campaigns",      Description = "View campaign list and details",              CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateCampaigns",         Module = "Campaigns",      Description = "Create new campaigns",                        CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateCampaigns",         Module = "Campaigns",      Description = "Update existing campaigns",                   CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteCampaigns",         Module = "Campaigns",      Description = "Delete campaigns",                            CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveCampaigns",        Module = "Campaigns",      Description = "Archive (soft delete) campaigns",              CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreCampaigns",        Module = "Campaigns",      Description = "Restore archived campaigns",                  CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteCampaigns",Module = "Campaigns",      Description = "Permanently delete campaigns",                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "SendCampaigns",           Module = "Campaigns",      Description = "Send or schedule email campaigns",             CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // EmailTemplates module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewEmailTemplates",      Module = "EmailTemplates", Description = "View email template list and details",        CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateEmailTemplates",    Module = "EmailTemplates", Description = "Create new email templates",                  CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateEmailTemplates",    Module = "EmailTemplates", Description = "Update existing email templates",             CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteEmailTemplates",         Module = "EmailTemplates", Description = "Delete email templates",                      CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveEmailTemplates",        Module = "EmailTemplates", Description = "Archive (soft delete) email templates",       CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreEmailTemplates",        Module = "EmailTemplates", Description = "Restore archived email templates",             CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteEmailTemplates",Module = "EmailTemplates", Description = "Permanently delete email templates",           CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Segments module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewSegments",                 Module = "Segments",       Description = "View audience segment list and details",      CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateSegments",               Module = "Segments",       Description = "Create new audience segments",                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateSegments",               Module = "Segments",       Description = "Update existing audience segments",           CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteSegments",               Module = "Segments",       Description = "Delete audience segments",                    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveSegments",              Module = "Segments",       Description = "Archive (soft delete) audience segments",     CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreSegments",              Module = "Segments",       Description = "Restore archived audience segments",          CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteSegments",      Module = "Segments",       Description = "Permanently delete audience segments",        CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // AutomationRules module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewAutomationRules",          Module = "AutomationRules",Description = "View automation rule list and details",       CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateAutomationRules",        Module = "AutomationRules",Description = "Create new automation rules",                 CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateAutomationRules",        Module = "AutomationRules",Description = "Update existing automation rules",            CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteAutomationRules",        Module = "AutomationRules",Description = "Delete automation rules",                     CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "ArchiveAutomationRules",       Module = "AutomationRules",Description = "Archive (soft delete) automation rules",      CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreAutomationRules",       Module = "AutomationRules",Description = "Restore archived automation rules",           CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteAutomationRules",Module = "AutomationRules",Description = "Permanently delete automation rules",        CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // MarketingAnalytics module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewMarketingAnalytics",  Module = "MarketingAnalytics", Description = "View marketing analytics dashboard",   CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // EmailLogs module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewEmailLogs",           Module = "EmailLogs",          Description = "View email message delivery logs",     CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Suppressions module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewSuppressions",        Module = "Suppressions",       Description = "View email suppression list",          CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "ManageSuppressions",      Module = "Suppressions",       Description = "Add or remove email suppressions",     CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // SessionLogs module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewSessionLogs",         Module = "SessionLogs",        Description = "View tutoring session logs and history",CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // StudentRequestLog module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewStudentRequestLog",   Module = "StudentRequestLog",  Description = "View student tutoring request logs",    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // AdminRequestLog module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewAdminRequestLog",     Module = "AdminRequestLog",    Description = "View admin scheduling request logs",    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // ClientLog module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewClientLog",           Module = "ClientLog",          Description = "View client activity logs",             CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // SessionLogs CUD permissions (View already exists above)
            permissions.Add(new Permission { Id = permissionId++, Name = "CreateSessionLogs",       Module = "SessionLogs",        Description = "Create tutoring session logs",           CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateSessionLogs",       Module = "SessionLogs",        Description = "Update tutoring session logs",           CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteSessionLogs",       Module = "SessionLogs",        Description = "Delete tutoring session logs",           CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // StudentAssignments module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewStudentAssignments",            Module = "StudentAssignments", Description = "View student assignment list and details",    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateStudentAssignments",          Module = "StudentAssignments", Description = "Update student assignments",                  CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteStudentAssignments",          Module = "StudentAssignments", Description = "Delete student assignments",                  CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "RestoreStudentAssignments",         Module = "StudentAssignments", Description = "Restore archived student assignments",        CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "PermanentDeleteStudentAssignments", Module = "StudentAssignments", Description = "Permanently delete student assignments",      CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            // Notifications module permissions
            permissions.Add(new Permission { Id = permissionId++, Name = "ViewNotifications",   Module = "Notifications", Description = "View notification list and details",   CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "UpdateNotifications", Module = "Notifications", Description = "Mark notifications as read",          CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
            permissions.Add(new Permission { Id = permissionId++, Name = "DeleteNotifications", Module = "Notifications", Description = "Delete notifications",                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

            var totalPermissions = permissionId - 1;

            modelBuilder.Entity<Permission>().HasData(permissions);

            // Seed Role-Permission relationships
            var rolePermissionId = 1;
            var rolePermissions = new List<RolePermission>();

            // Super Admin gets ALL permissions
            for (int i = 1; i <= totalPermissions; i++)
            {
                rolePermissions.Add(new RolePermission { Id = rolePermissionId++, RoleId = 1, PermissionId = i });
            }

            // Admin gets ALL permissions
            for (int i = 1; i <= totalPermissions; i++)
            {
                rolePermissions.Add(new RolePermission { Id = rolePermissionId++, RoleId = 2, PermissionId = i });
            }

            // Marketing Manager (RoleId 3) – full Marketing module access
            var marketingManagerPerms = new[]
            {
                "ViewLeads", "CreateLeads", "UpdateLeads", "DeleteLeads", "ArchiveLeads", "RestoreLeads", "PermanentDeleteLeads",
                "ViewCustomers", "CreateCustomers", "UpdateCustomers", "DeleteCustomers", "ConvertLead", "ArchiveCustomers", "RestoreCustomers", "PermanentDeleteCustomers",
                "ViewCampaigns", "CreateCampaigns", "UpdateCampaigns", "DeleteCampaigns", "ArchiveCampaigns", "RestoreCampaigns", "PermanentDeleteCampaigns", "SendCampaigns",
                "ViewEmailTemplates", "CreateEmailTemplates", "UpdateEmailTemplates", "DeleteEmailTemplates", "ArchiveEmailTemplates", "RestoreEmailTemplates", "PermanentDeleteEmailTemplates",
                "ViewSegments", "CreateSegments", "UpdateSegments", "DeleteSegments", "ArchiveSegments", "RestoreSegments", "PermanentDeleteSegments",
                "ViewAutomationRules", "CreateAutomationRules", "UpdateAutomationRules", "DeleteAutomationRules", "ArchiveAutomationRules", "RestoreAutomationRules", "PermanentDeleteAutomationRules",
                "ViewMarketingAnalytics", "ViewEmailLogs", "ViewSuppressions", "ManageSuppressions",
                "ViewNotifications", "UpdateNotifications", "DeleteNotifications",
            };
            foreach (var permName in marketingManagerPerms)
            {
                var perm = permissions.First(p => p.Name == permName);
                rolePermissions.Add(new RolePermission { Id = rolePermissionId++, RoleId = 3, PermissionId = perm.Id });
            }

            // Marketing Staff (RoleId 4) – view + create marketing data, no delete/archive
            var marketingStaffPerms = new[]
            {
                "ViewLeads", "CreateLeads", "UpdateLeads",
                "ViewCustomers", "CreateCustomers", "UpdateCustomers", "ConvertLead",
                "ViewCampaigns", "CreateCampaigns", "UpdateCampaigns", "SendCampaigns",
                "ViewEmailTemplates", "CreateEmailTemplates", "UpdateEmailTemplates",
                "ViewSegments", "CreateSegments", "UpdateSegments",
                "ViewAutomationRules", "CreateAutomationRules", "UpdateAutomationRules",
                "ViewMarketingAnalytics", "ViewEmailLogs", "ViewSuppressions",
            };
            foreach (var permName in marketingStaffPerms)
            {
                var perm = permissions.First(p => p.Name == permName);
                rolePermissions.Add(new RolePermission { Id = rolePermissionId++, RoleId = 4, PermissionId = perm.Id });
            }

            // Building Manager (RoleId 5) – buildings, rooms, departments, subjects, scheduling
            var buildingManagerPerms = new[]
            {
                "ViewBuildings", "CreateBuildings", "UpdateBuildings", "DeleteBuildings", "ArchiveBuildings", "RestoreBuildings",
                "ViewRooms", "CreateRooms", "UpdateRooms", "DeleteRooms", "ArchiveRooms", "RestoreRooms",
                "ViewDepartments", "ViewSubjects",
                "ViewAvailableDays", "ViewAvailableTimeSlots",
                "ViewTeacherAssignments",
                "ViewTutoringRequests",
                "ViewScheduling",
                "ViewSchedulingTracking",
                "ViewSessionLogs",
                "ViewNotifications", "UpdateNotifications",
            };
            foreach (var permName in buildingManagerPerms)
            {
                var perm = permissions.First(p => p.Name == permName);
                rolePermissions.Add(new RolePermission { Id = rolePermissionId++, RoleId = 5, PermissionId = perm.Id });
            }

            // Teacher (RoleId 6) – view assignments, manage own availability, view/create session logs
            var teacherPerms = new[]
            {
                "ViewTeacherAssignments", "UpdateTeacherAssignments",
                "ViewTutoringRequests",
                "ViewSessionLogs", "CreateSessionLogs", "UpdateSessionLogs",
                "ViewScheduling",
                "ViewAvailableDays", "ViewAvailableTimeSlots",
                "ViewBuildings", "ViewRooms", "ViewDepartments", "ViewSubjects",
                "ViewNotifications", "UpdateNotifications",
            };
            foreach (var permName in teacherPerms)
            {
                var perm = permissions.First(p => p.Name == permName);
                rolePermissions.Add(new RolePermission { Id = rolePermissionId++, RoleId = 6, PermissionId = perm.Id });
            }

            // Customer (RoleId 7) – no permissions needed, uses /lookup and student-scoped endpoints

            // Lead (RoleId 8) – no permissions needed, uses /lookup and student-scoped endpoints

            modelBuilder.Entity<RolePermission>().HasData(rolePermissions);

            // Seed Super Admin User
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "Justin",
                LastName = "Digal",
                Email = "digaljustin099@gmail.com",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });

            // Seed Super Admin User Credential (Password: JustinPogi27)
            modelBuilder.Entity<UserCredential>().HasData(new UserCredential
            {
                Id = 1,
                UserId = 1,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("JustinPogi27", 12),
                IsPasswordChanged = true
            });

            // Assign Super Admin role to user
            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                Id = 1,
                UserId = 1,
                RoleId = 1
            });
        }
    }
}
