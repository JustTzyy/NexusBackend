using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Subjects;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuditService _auditService;

        public SubjectService(
            ApplicationDbContext context,
            IAuditService auditService)
        {
            _context = context;
            _auditService = auditService;
        }

        public async Task<PagedResultDto<SubjectListDto>> GetAllSubjectsAsync(PaginationDto pagination)
        {
            var query = _context.Subjects
                .Include(s => s.Department)
                .Where(s => s.DeletedAt == null)
                .AsQueryable();

            // Search by name or department name
            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(s =>
                    s.Name.ToLower().Contains(searchLower) ||
                    s.Department.Name.ToLower().Contains(searchLower));
            }

            var totalCount = await query.CountAsync();

            // Sorting
            query = (pagination.SortBy?.ToLower(), pagination.SortDescending) switch
            {
                ("name", true) => query.OrderByDescending(s => s.Name),
                ("name", false) => query.OrderBy(s => s.Name),
                ("departmentname", true) => query.OrderByDescending(s => s.Department.Name),
                ("departmentname", false) => query.OrderBy(s => s.Department.Name),
                ("createdat", true) => query.OrderByDescending(s => s.CreatedAt),
                ("createdat", false) => query.OrderBy(s => s.CreatedAt),
                ("updatedat", true) => query.OrderByDescending(s => s.UpdatedAt),
                ("updatedat", false) => query.OrderBy(s => s.UpdatedAt),
                _ => query.OrderByDescending(s => s.CreatedAt)
            };

            var subjects = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var items = subjects.Select(s => new SubjectListDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                IsActive = s.IsActive,
                DepartmentId = s.DepartmentId,
                DepartmentName = s.Department.Name,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            }).ToList();

            return new PagedResultDto<SubjectListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<SubjectResponseDto?> GetSubjectByIdAsync(int id)
        {
            var subject = await _context.Subjects
                .IgnoreQueryFilters()
                .Include(s => s.Department)
                .Include(s => s.CreatedByUser)
                .Include(s => s.UpdatedByUser)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subject == null) return null;

            return new SubjectResponseDto
            {
                Id = subject.Id,
                Name = subject.Name,
                Description = subject.Description,
                IsActive = subject.IsActive,
                DepartmentId = subject.DepartmentId,
                DepartmentName = subject.Department.Name,
                CreatedAt = subject.CreatedAt,
                UpdatedAt = subject.UpdatedAt,
                DeletedAt = subject.DeletedAt,
                CreatedBy = subject.CreatedBy,
                UpdatedBy = subject.UpdatedBy,
                CreatedByName = subject.CreatedByUser != null
                    ? $"{subject.CreatedByUser.FirstName} {subject.CreatedByUser.LastName}".Trim()
                    : null,
                UpdatedByName = subject.UpdatedByUser != null
                    ? $"{subject.UpdatedByUser.FirstName} {subject.UpdatedByUser.LastName}".Trim()
                    : null
            };
        }

        public async Task<PagedResultDto<SubjectListDto>> GetArchivedSubjectsAsync(PaginationDto pagination)
        {
            var query = _context.Subjects
                .IgnoreQueryFilters()
                .Include(s => s.Department)
                .Where(s => s.DeletedAt != null)
                .AsQueryable();

            // Search by name or department name
            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(s =>
                    s.Name.ToLower().Contains(searchLower) ||
                    s.Department.Name.ToLower().Contains(searchLower));
            }

            var totalCount = await query.CountAsync();

            var subjects = await query
                .OrderByDescending(s => s.DeletedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var items = subjects.Select(s => new SubjectListDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                IsActive = s.IsActive,
                DepartmentId = s.DepartmentId,
                DepartmentName = s.Department.Name,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            }).ToList();

            return new PagedResultDto<SubjectListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<SubjectResponseDto> CreateSubjectAsync(CreateSubjectDto dto, int? currentUserId)
        {
            // Validate department exists
            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.Id == dto.DepartmentId && d.DeletedAt == null);

            if (department == null)
            {
                throw new InvalidOperationException("The specified department does not exist.");
            }

            // Check for duplicate name within the same department
            var existingSubject = await _context.Subjects
                .FirstOrDefaultAsync(s =>
                    s.Name.ToLower() == dto.Name.ToLower() &&
                    s.DepartmentId == dto.DepartmentId &&
                    s.DeletedAt == null);

            if (existingSubject != null)
            {
                throw new InvalidOperationException($"A subject with the name '{dto.Name}' already exists in {department.Name}.");
            }

            var subject = new Subject
            {
                Name = dto.Name,
                Description = dto.Description,
                IsActive = dto.IsActive,
                DepartmentId = dto.DepartmentId,
                CreatedBy = currentUserId,
                UpdatedBy = currentUserId
            };

            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            var createDetails = $"Created subject: {subject.Name} -> Department: {department.Name}, IsActive: {subject.IsActive}";
            await _auditService.LogAsync("Subjects", "Create", createDetails, currentUserId);

            return (await GetSubjectByIdAsync(subject.Id))!;
        }

        public async Task<SubjectResponseDto?> UpdateSubjectAsync(int id, UpdateSubjectDto dto, int? currentUserId)
        {
            var subject = await _context.Subjects
                .Include(s => s.Department)
                .FirstOrDefaultAsync(s => s.Id == id && s.DeletedAt == null);

            if (subject == null) return null;

            var changes = new List<string>();
            var originalName = subject.Name;

            // Check for duplicate name if name is being changed
            if (!string.IsNullOrEmpty(dto.Name) && dto.Name.ToLower() != subject.Name.ToLower())
            {
                var targetDepartmentId = dto.DepartmentId ?? subject.DepartmentId;
                var existingSubject = await _context.Subjects
                    .FirstOrDefaultAsync(s =>
                        s.Name.ToLower() == dto.Name.ToLower() &&
                        s.DepartmentId == targetDepartmentId &&
                        s.Id != id &&
                        s.DeletedAt == null);

                if (existingSubject != null)
                {
                    throw new InvalidOperationException($"A subject with the name '{dto.Name}' already exists in that department.");
                }

                changes.Add($"Name: {subject.Name} → {dto.Name}");
                subject.Name = dto.Name;
            }

            if (dto.Description != null && dto.Description != subject.Description)
            {
                changes.Add($"Description updated");
                subject.Description = dto.Description;
            }

            if (dto.IsActive.HasValue && dto.IsActive.Value != subject.IsActive)
            {
                changes.Add($"IsActive: {subject.IsActive} → {dto.IsActive.Value}");
                subject.IsActive = dto.IsActive.Value;
            }

            if (dto.DepartmentId.HasValue && dto.DepartmentId.Value != subject.DepartmentId)
            {
                // Validate new department exists
                var newDepartment = await _context.Departments
                    .FirstOrDefaultAsync(d => d.Id == dto.DepartmentId.Value && d.DeletedAt == null);

                if (newDepartment == null)
                {
                    throw new InvalidOperationException("The specified department does not exist.");
                }

                changes.Add($"DepartmentId: {subject.DepartmentId} → {dto.DepartmentId.Value}");
                subject.DepartmentId = dto.DepartmentId.Value;
            }

            subject.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();

            var updateDetails = changes.Any()
                ? $"Updated subject: {originalName} -> {string.Join(", ", changes)}"
                : $"Updated subject: {originalName} (no changes detected)";
            await _auditService.LogAsync("Subjects", "Update", updateDetails, currentUserId);

            return await GetSubjectByIdAsync(subject.Id);
        }

        public async Task<bool> DeleteSubjectAsync(int id, int? currentUserId)
        {
            var subject = await _context.Subjects
                .FirstOrDefaultAsync(s => s.Id == id && s.DeletedAt == null);

            if (subject == null) return false;

            subject.IsActive = false;
            subject.DeletedAt = DateTime.UtcNow;
            subject.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var deleteDetails = $"Soft deleted subject: {subject.Name}";
            await _auditService.LogAsync("Subjects", "Delete", deleteDetails, currentUserId);

            return true;
        }

        public async Task<bool> RestoreSubjectAsync(int id, int? currentUserId)
        {
            var subject = await _context.Subjects.IgnoreQueryFilters()
                .FirstOrDefaultAsync(s => s.Id == id && s.DeletedAt != null);

            if (subject == null) return false;

            subject.IsActive = true;
            subject.DeletedAt = null;
            subject.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var restoreDetails = $"Restored subject: {subject.Name}";
            await _auditService.LogAsync("Subjects", "Restore", restoreDetails, currentUserId);

            return true;
        }

        public async Task<bool> PermanentDeleteSubjectAsync(int id, int? currentUserId)
        {
            var subject = await _context.Subjects.IgnoreQueryFilters()
                .FirstOrDefaultAsync(s => s.Id == id && s.DeletedAt != null);

            if (subject == null) return false;

            var subjectName = subject.Name;

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            var permanentDeleteDetails = $"Permanently deleted subject: {subjectName}";
            await _auditService.LogAsync("Subjects", "PermanentDelete", permanentDeleteDetails, currentUserId);

            return true;
        }
    }
}
