using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Notifications;
using NexUs.Models.DTO.TeacherAssignments;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class TeacherAssignmentService : ITeacherAssignmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuditService _auditService;
        private readonly INotificationService _notificationService;

        public TeacherAssignmentService(
            ApplicationDbContext context,
            IAuditService auditService,
            INotificationService notificationService)
        {
            _context = context;
            _auditService = auditService;
            _notificationService = notificationService;
        }

        public async Task<PagedResultDto<TeacherAssignmentListDto>> GetAllTeacherAssignmentsAsync(PaginationDto pagination)
        {
            var query = _context.TeacherAssignments
                .Include(t => t.Teacher)
                .Include(t => t.Building)
                .Include(t => t.Department)
                .Where(t => t.DeletedAt == null)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(t =>
                    (t.Teacher.FirstName + " " + t.Teacher.LastName).ToLower().Contains(searchLower) ||
                    t.Building.Name.ToLower().Contains(searchLower) ||
                    t.Department.Name.ToLower().Contains(searchLower));
            }

            var totalCount = await query.CountAsync();

            query = (pagination.SortBy?.ToLower(), pagination.SortDescending) switch
            {
                ("teachername", true) => query.OrderByDescending(t => t.Teacher.FirstName + " " + t.Teacher.LastName),
                ("teachername", false) => query.OrderBy(t => t.Teacher.FirstName + " " + t.Teacher.LastName),
                ("buildingname", true) => query.OrderByDescending(t => t.Building.Name),
                ("buildingname", false) => query.OrderBy(t => t.Building.Name),
                ("departmentname", true) => query.OrderByDescending(t => t.Department.Name),
                ("departmentname", false) => query.OrderBy(t => t.Department.Name),
                ("createdat", true) => query.OrderByDescending(t => t.CreatedAt),
                ("createdat", false) => query.OrderBy(t => t.CreatedAt),
                _ => query.OrderByDescending(t => t.CreatedAt)
            };

            var assignments = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var items = assignments.Select(t => new TeacherAssignmentListDto
            {
                Id = t.Id,
                TeacherId = t.TeacherId,
                TeacherName = t.Teacher.FirstName + " " + t.Teacher.LastName,
                BuildingId = t.BuildingId,
                BuildingName = t.Building.Name,
                DepartmentId = t.DepartmentId,
                DepartmentName = t.Department.Name,
                CreatedAt = t.CreatedAt,
                UpdatedAt = t.UpdatedAt
            }).ToList();

            return new PagedResultDto<TeacherAssignmentListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<TeacherAssignmentResponseDto?> GetTeacherAssignmentByIdAsync(int id)
        {
            var assignment = await _context.TeacherAssignments
                .IgnoreQueryFilters()
                .Include(t => t.Teacher)
                .Include(t => t.Building)
                .Include(t => t.Department)
                .Include(t => t.CreatedByUser)
                .Include(t => t.UpdatedByUser)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (assignment == null) return null;

            return new TeacherAssignmentResponseDto
            {
                Id = assignment.Id,
                TeacherId = assignment.TeacherId,
                TeacherName = assignment.Teacher.FirstName + " " + assignment.Teacher.LastName,
                BuildingId = assignment.BuildingId,
                BuildingName = assignment.Building.Name,
                DepartmentId = assignment.DepartmentId,
                DepartmentName = assignment.Department.Name,
                CreatedAt = assignment.CreatedAt,
                UpdatedAt = assignment.UpdatedAt,
                DeletedAt = assignment.DeletedAt,
                CreatedBy = assignment.CreatedBy,
                UpdatedBy = assignment.UpdatedBy,
                CreatedByName = assignment.CreatedByUser != null
                    ? $"{assignment.CreatedByUser.FirstName} {assignment.CreatedByUser.LastName}".Trim()
                    : null,
                UpdatedByName = assignment.UpdatedByUser != null
                    ? $"{assignment.UpdatedByUser.FirstName} {assignment.UpdatedByUser.LastName}".Trim()
                    : null
            };
        }

        public async Task<PagedResultDto<TeacherAssignmentListDto>> GetArchivedTeacherAssignmentsAsync(PaginationDto pagination)
        {
            var query = _context.TeacherAssignments
                .IgnoreQueryFilters()
                .Include(t => t.Teacher)
                .Include(t => t.Building)
                .Include(t => t.Department)
                .Where(t => t.DeletedAt != null)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(t =>
                    (t.Teacher.FirstName + " " + t.Teacher.LastName).ToLower().Contains(searchLower) ||
                    t.Building.Name.ToLower().Contains(searchLower) ||
                    t.Department.Name.ToLower().Contains(searchLower));
            }

            var totalCount = await query.CountAsync();

            var assignments = await query
                .OrderByDescending(t => t.DeletedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var items = assignments.Select(t => new TeacherAssignmentListDto
            {
                Id = t.Id,
                TeacherId = t.TeacherId,
                TeacherName = t.Teacher.FirstName + " " + t.Teacher.LastName,
                BuildingId = t.BuildingId,
                BuildingName = t.Building.Name,
                DepartmentId = t.DepartmentId,
                DepartmentName = t.Department.Name,
                CreatedAt = t.CreatedAt,
                UpdatedAt = t.UpdatedAt,
                DeletedAt = t.DeletedAt
            }).ToList();

            return new PagedResultDto<TeacherAssignmentListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<TeacherAssignmentResponseDto> CreateTeacherAssignmentAsync(CreateTeacherAssignmentDto dto, int? currentUserId)
        {
            // Validate teacher exists
            var teacher = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == dto.TeacherId && u.DeletedAt == null);

            if (teacher == null)
            {
                throw new InvalidOperationException("The specified teacher does not exist.");
            }

            // Validate building exists
            var building = await _context.Buildings
                .FirstOrDefaultAsync(b => b.Id == dto.BuildingId && b.DeletedAt == null);

            if (building == null)
            {
                throw new InvalidOperationException("The specified building does not exist.");
            }

            // Validate department exists
            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.Id == dto.DepartmentId && d.DeletedAt == null);

            if (department == null)
            {
                throw new InvalidOperationException("The specified department does not exist.");
            }

            // Check for duplicate assignment (same teacher + building + department)
            var existingAssignment = await _context.TeacherAssignments
                .FirstOrDefaultAsync(t =>
                    t.TeacherId == dto.TeacherId &&
                    t.BuildingId == dto.BuildingId &&
                    t.DepartmentId == dto.DepartmentId &&
                    t.DeletedAt == null);

            if (existingAssignment != null)
            {
                throw new InvalidOperationException($"An assignment for teacher '{teacher.FirstName} {teacher.LastName}' in building '{building.Name}' and department '{department.Name}' already exists.");
            }

            var assignment = new TeacherAssignment
            {
                TeacherId = dto.TeacherId,
                BuildingId = dto.BuildingId,
                DepartmentId = dto.DepartmentId,
                CreatedBy = currentUserId,
                UpdatedBy = currentUserId
            };

            _context.TeacherAssignments.Add(assignment);
            await _context.SaveChangesAsync();

            var createDetails = $"Created teacher assignment: {teacher.FirstName} {teacher.LastName} -> Building: {building.Name}, Department: {department.Name}";
            await _auditService.LogAsync("TeacherAssignments", "Create", createDetails, currentUserId);

            // Notify Super Admin: new teacher assignment
            try
            {
                await _notificationService.CreateAsync(new CreateNotificationDto
                {
                    RecipientRole = "Super Admin",
                    Title = "New Teacher Assignment",
                    Message = $"{teacher.FirstName} {teacher.LastName} has been assigned to {building.Name} - {department.Name}.",
                    Type = "Scheduling",
                    Priority = "Normal",
                    ReferenceId = assignment.Id,
                    ReferenceType = "TeacherAssignment"
                }, currentUserId);
            }
            catch { /* silent */ }

            return (await GetTeacherAssignmentByIdAsync(assignment.Id))!;
        }

        public async Task<TeacherAssignmentResponseDto?> UpdateTeacherAssignmentAsync(int id, UpdateTeacherAssignmentDto dto, int? currentUserId)
        {
            var assignment = await _context.TeacherAssignments
                .Include(t => t.Teacher)
                .Include(t => t.Building)
                .Include(t => t.Department)
                .FirstOrDefaultAsync(t => t.Id == id && t.DeletedAt == null);

            if (assignment == null) return null;

            var changes = new List<string>();
            var originalTeacherName = assignment.Teacher.FirstName + " " + assignment.Teacher.LastName;

            if (dto.TeacherId.HasValue && dto.TeacherId.Value != assignment.TeacherId)
            {
                var newTeacher = await _context.Users
                    .FirstOrDefaultAsync(u => u.Id == dto.TeacherId.Value && u.DeletedAt == null);

                if (newTeacher == null)
                {
                    throw new InvalidOperationException("The specified teacher does not exist.");
                }

                changes.Add($"TeacherId: {assignment.TeacherId} → {dto.TeacherId.Value}");
                assignment.TeacherId = dto.TeacherId.Value;
            }

            if (dto.BuildingId.HasValue && dto.BuildingId.Value != assignment.BuildingId)
            {
                var newBuilding = await _context.Buildings
                    .FirstOrDefaultAsync(b => b.Id == dto.BuildingId.Value && b.DeletedAt == null);

                if (newBuilding == null)
                {
                    throw new InvalidOperationException("The specified building does not exist.");
                }

                changes.Add($"BuildingId: {assignment.BuildingId} → {dto.BuildingId.Value}");
                assignment.BuildingId = dto.BuildingId.Value;
            }

            if (dto.DepartmentId.HasValue && dto.DepartmentId.Value != assignment.DepartmentId)
            {
                var newDepartment = await _context.Departments
                    .FirstOrDefaultAsync(d => d.Id == dto.DepartmentId.Value && d.DeletedAt == null);

                if (newDepartment == null)
                {
                    throw new InvalidOperationException("The specified department does not exist.");
                }

                changes.Add($"DepartmentId: {assignment.DepartmentId} → {dto.DepartmentId.Value}");
                assignment.DepartmentId = dto.DepartmentId.Value;
            }

            // Check for duplicate after changes
            var existingAssignment = await _context.TeacherAssignments
                .FirstOrDefaultAsync(t =>
                    t.TeacherId == assignment.TeacherId &&
                    t.BuildingId == assignment.BuildingId &&
                    t.DepartmentId == assignment.DepartmentId &&
                    t.Id != id &&
                    t.DeletedAt == null);

            if (existingAssignment != null)
            {
                throw new InvalidOperationException("An assignment with the same teacher, building, and department combination already exists.");
            }

            assignment.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();

            var updateDetails = changes.Any()
                ? $"Updated teacher assignment: {originalTeacherName} -> {string.Join(", ", changes)}"
                : $"Updated teacher assignment: {originalTeacherName} (no changes detected)";
            await _auditService.LogAsync("TeacherAssignments", "Update", updateDetails, currentUserId);

            return await GetTeacherAssignmentByIdAsync(assignment.Id);
        }

        public async Task<bool> DeleteTeacherAssignmentAsync(int id, int? currentUserId)
        {
            var assignment = await _context.TeacherAssignments
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(t => t.Id == id && t.DeletedAt == null);

            if (assignment == null) return false;

            assignment.DeletedAt = DateTime.UtcNow;
            assignment.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var deleteDetails = $"Soft deleted teacher assignment: {assignment.Teacher.FirstName} {assignment.Teacher.LastName}";
            await _auditService.LogAsync("TeacherAssignments", "Delete", deleteDetails, currentUserId);

            return true;
        }

        public async Task<bool> RestoreTeacherAssignmentAsync(int id, int? currentUserId)
        {
            var assignment = await _context.TeacherAssignments.IgnoreQueryFilters()
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(t => t.Id == id && t.DeletedAt != null);

            if (assignment == null) return false;

            assignment.DeletedAt = null;
            assignment.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var restoreDetails = $"Restored teacher assignment: {assignment.Teacher.FirstName} {assignment.Teacher.LastName}";
            await _auditService.LogAsync("TeacherAssignments", "Restore", restoreDetails, currentUserId);

            return true;
        }

        public async Task<bool> PermanentDeleteTeacherAssignmentAsync(int id, int? currentUserId)
        {
            var assignment = await _context.TeacherAssignments.IgnoreQueryFilters()
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(t => t.Id == id && t.DeletedAt != null);

            if (assignment == null) return false;

            var teacherName = assignment.Teacher.FirstName + " " + assignment.Teacher.LastName;

            _context.TeacherAssignments.Remove(assignment);
            await _context.SaveChangesAsync();

            var permanentDeleteDetails = $"Permanently deleted teacher assignment: {teacherName}";
            await _auditService.LogAsync("TeacherAssignments", "PermanentDelete", permanentDeleteDetails, currentUserId);

            return true;
        }
    }
}
