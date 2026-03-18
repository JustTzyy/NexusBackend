using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.StudentAssignments;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class StudentAssignmentService : IStudentAssignmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuditService _auditService;

        public StudentAssignmentService(
            ApplicationDbContext context,
            IAuditService auditService)
        {
            _context = context;
            _auditService = auditService;
        }

        public async Task<PagedResultDto<StudentAssignmentListDto>> GetAllAsync(PaginationDto pagination)
        {
            var query = _context.StudentAssignments
                .Include(s => s.Student)
                .Include(s => s.PreferredBuilding)
                .Where(s => s.DeletedAt == null)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(s =>
                    (s.Student.FirstName + " " + s.Student.LastName).ToLower().Contains(searchLower) ||
                    (s.PreferredBuilding != null && s.PreferredBuilding.Name.ToLower().Contains(searchLower)));
            }

            var totalCount = await query.CountAsync();

            query = (pagination.SortBy?.ToLower(), pagination.SortDescending) switch
            {
                ("studentname", true) => query.OrderByDescending(s => s.Student.FirstName + " " + s.Student.LastName),
                ("studentname", false) => query.OrderBy(s => s.Student.FirstName + " " + s.Student.LastName),
                ("createdat", true) => query.OrderByDescending(s => s.CreatedAt),
                ("createdat", false) => query.OrderBy(s => s.CreatedAt),
                _ => query.OrderByDescending(s => s.CreatedAt)
            };

            var assignments = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var items = assignments.Select(MapToListDto).ToList();

            return new PagedResultDto<StudentAssignmentListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<PagedResultDto<StudentAssignmentListDto>> GetArchivedAsync(PaginationDto pagination)
        {
            var query = _context.StudentAssignments
                .IgnoreQueryFilters()
                .Include(s => s.Student)
                .Include(s => s.PreferredBuilding)
                .Where(s => s.DeletedAt != null)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(s =>
                    (s.Student.FirstName + " " + s.Student.LastName).ToLower().Contains(searchLower) ||
                    (s.PreferredBuilding != null && s.PreferredBuilding.Name.ToLower().Contains(searchLower)));
            }

            var totalCount = await query.CountAsync();

            var assignments = await query
                .OrderByDescending(s => s.DeletedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PagedResultDto<StudentAssignmentListDto>
            {
                Items = assignments.Select(MapToListDto).ToList(),
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<StudentAssignmentResponseDto?> GetByIdAsync(int id)
        {
            var assignment = await _context.StudentAssignments
                .IgnoreQueryFilters()
                .Include(s => s.Student)
                .Include(s => s.PreferredBuilding)
                .Include(s => s.CreatedByUser)
                .Include(s => s.UpdatedByUser)
                .FirstOrDefaultAsync(s => s.Id == id);

            return assignment == null ? null : MapToResponseDto(assignment);
        }

        public async Task<StudentAssignmentResponseDto?> GetByStudentIdAsync(int studentId)
        {
            var assignment = await _context.StudentAssignments
                .Include(s => s.Student)
                .Include(s => s.PreferredBuilding)
                .Include(s => s.CreatedByUser)
                .Include(s => s.UpdatedByUser)
                .FirstOrDefaultAsync(s => s.StudentId == studentId && s.DeletedAt == null);

            return assignment == null ? null : MapToResponseDto(assignment);
        }

        public async Task<StudentAssignmentResponseDto> UpsertByStudentIdAsync(int studentId, UpdateStudentAssignmentDto dto, int? currentUserId)
        {
            var existing = await _context.StudentAssignments
                .FirstOrDefaultAsync(s => s.StudentId == studentId && s.DeletedAt == null);

            if (existing == null)
            {
                var newAssignment = new StudentAssignment
                {
                    StudentId = studentId,
                    PreferredBuildingId = dto.ClearPreferredBuilding ? null : dto.PreferredBuildingId,
                    Notes = dto.ClearNotes ? null : dto.Notes,
                    CreatedBy = currentUserId,
                    UpdatedBy = currentUserId
                };

                _context.StudentAssignments.Add(newAssignment);
                await _context.SaveChangesAsync();

                await _auditService.LogAsync("StudentAssignments", "Create",
                    $"Created student assignment for StudentId: {studentId}", currentUserId);

                return (await GetByIdAsync(newAssignment.Id))!;
            }
            else
            {
                var changes = new List<string>();

                if (dto.ClearPreferredBuilding)
                {
                    if (existing.PreferredBuildingId != null)
                        changes.Add($"PreferredBuildingId: {existing.PreferredBuildingId} → null");
                    existing.PreferredBuildingId = null;
                }
                else if (dto.PreferredBuildingId.HasValue && dto.PreferredBuildingId != existing.PreferredBuildingId)
                {
                    changes.Add($"PreferredBuildingId: {existing.PreferredBuildingId?.ToString() ?? "null"} → {dto.PreferredBuildingId}");
                    existing.PreferredBuildingId = dto.PreferredBuildingId;
                }

                if (dto.ClearNotes)
                {
                    if (existing.Notes != null)
                        changes.Add("Notes cleared");
                    existing.Notes = null;
                }
                else if (dto.Notes != null && dto.Notes != existing.Notes)
                {
                    changes.Add("Notes updated");
                    existing.Notes = dto.Notes;
                }

                existing.UpdatedBy = currentUserId;
                await _context.SaveChangesAsync();

                var updateDetails = changes.Any()
                    ? $"Updated student assignment for StudentId: {studentId} -> {string.Join(", ", changes)}"
                    : $"Updated student assignment for StudentId: {studentId} (no changes)";
                await _auditService.LogAsync("StudentAssignments", "Update", updateDetails, currentUserId);

                return (await GetByIdAsync(existing.Id))!;
            }
        }

        public async Task<StudentAssignmentResponseDto?> UpdateAsync(int id, UpdateStudentAssignmentDto dto, int? currentUserId)
        {
            var assignment = await _context.StudentAssignments
                .FirstOrDefaultAsync(s => s.Id == id && s.DeletedAt == null);

            if (assignment == null) return null;

            var changes = new List<string>();

            if (dto.ClearPreferredBuilding)
            {
                if (assignment.PreferredBuildingId != null)
                    changes.Add($"PreferredBuildingId: {assignment.PreferredBuildingId} → null");
                assignment.PreferredBuildingId = null;
            }
            else if (dto.PreferredBuildingId.HasValue && dto.PreferredBuildingId != assignment.PreferredBuildingId)
            {
                changes.Add($"PreferredBuildingId: {assignment.PreferredBuildingId?.ToString() ?? "null"} → {dto.PreferredBuildingId}");
                assignment.PreferredBuildingId = dto.PreferredBuildingId;
            }

            if (dto.ClearNotes)
            {
                if (assignment.Notes != null)
                    changes.Add("Notes cleared");
                assignment.Notes = null;
            }
            else if (dto.Notes != null && dto.Notes != assignment.Notes)
            {
                changes.Add("Notes updated");
                assignment.Notes = dto.Notes;
            }

            assignment.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();

            var updateDetails = changes.Any()
                ? $"Updated student assignment id {id}: {string.Join(", ", changes)}"
                : $"Updated student assignment id {id} (no changes)";
            await _auditService.LogAsync("StudentAssignments", "Update", updateDetails, currentUserId);

            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id, int? currentUserId)
        {
            var assignment = await _context.StudentAssignments
                .Include(s => s.Student)
                .FirstOrDefaultAsync(s => s.Id == id && s.DeletedAt == null);

            if (assignment == null) return false;

            assignment.DeletedAt = DateTime.UtcNow;
            assignment.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            await _auditService.LogAsync("StudentAssignments", "Delete",
                $"Soft deleted student assignment for: {assignment.Student.FirstName} {assignment.Student.LastName}", currentUserId);

            return true;
        }

        public async Task<bool> RestoreAsync(int id, int? currentUserId)
        {
            var assignment = await _context.StudentAssignments
                .IgnoreQueryFilters()
                .Include(s => s.Student)
                .FirstOrDefaultAsync(s => s.Id == id && s.DeletedAt != null);

            if (assignment == null) return false;

            assignment.DeletedAt = null;
            assignment.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            await _auditService.LogAsync("StudentAssignments", "Restore",
                $"Restored student assignment for: {assignment.Student.FirstName} {assignment.Student.LastName}", currentUserId);

            return true;
        }

        public async Task<bool> PermanentDeleteAsync(int id, int? currentUserId)
        {
            var assignment = await _context.StudentAssignments
                .IgnoreQueryFilters()
                .Include(s => s.Student)
                .FirstOrDefaultAsync(s => s.Id == id && s.DeletedAt != null);

            if (assignment == null) return false;

            var studentName = $"{assignment.Student.FirstName} {assignment.Student.LastName}";

            _context.StudentAssignments.Remove(assignment);
            await _context.SaveChangesAsync();

            await _auditService.LogAsync("StudentAssignments", "PermanentDelete",
                $"Permanently deleted student assignment for: {studentName}", currentUserId);

            return true;
        }

        private static StudentAssignmentListDto MapToListDto(StudentAssignment s) => new()
        {
            Id = s.Id,
            StudentId = s.StudentId,
            StudentName = $"{s.Student.FirstName} {s.Student.LastName}".Trim(),
            PreferredBuildingId = s.PreferredBuildingId,
            PreferredBuildingName = s.PreferredBuilding?.Name,
            Notes = s.Notes,
            CreatedAt = s.CreatedAt,
            UpdatedAt = s.UpdatedAt,
            DeletedAt = s.DeletedAt
        };

        private static StudentAssignmentResponseDto MapToResponseDto(StudentAssignment s) => new()
        {
            Id = s.Id,
            StudentId = s.StudentId,
            StudentName = $"{s.Student.FirstName} {s.Student.LastName}".Trim(),
            PreferredBuildingId = s.PreferredBuildingId,
            PreferredBuildingName = s.PreferredBuilding?.Name,
            Notes = s.Notes,
            CreatedAt = s.CreatedAt,
            UpdatedAt = s.UpdatedAt,
            DeletedAt = s.DeletedAt,
            CreatedBy = s.CreatedBy,
            UpdatedBy = s.UpdatedBy,
            CreatedByName = s.CreatedByUser != null
                ? $"{s.CreatedByUser.FirstName} {s.CreatedByUser.LastName}".Trim()
                : null,
            UpdatedByName = s.UpdatedByUser != null
                ? $"{s.UpdatedByUser.FirstName} {s.UpdatedByUser.LastName}".Trim()
                : null
        };
    }
}
