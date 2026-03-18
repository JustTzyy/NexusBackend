using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Departments;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuditService _auditService;

        public DepartmentService(
            ApplicationDbContext context,
            IAuditService auditService)
        {
            _context = context;
            _auditService = auditService;
        }

        public async Task<PagedResultDto<DepartmentListDto>> GetAllDepartmentsAsync(PaginationDto pagination)
        {
            var query = _context.Departments
                .Where(d => d.DeletedAt == null)
                .AsQueryable();

            // Search by name or code
            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(d =>
                    d.Name.ToLower().Contains(searchLower) ||
                    d.Code.ToLower().Contains(searchLower));
            }

            var totalCount = await query.CountAsync();

            // Sorting
            query = (pagination.SortBy?.ToLower(), pagination.SortDescending) switch
            {
                ("name", true) => query.OrderByDescending(d => d.Name),
                ("name", false) => query.OrderBy(d => d.Name),
                ("code", true) => query.OrderByDescending(d => d.Code),
                ("code", false) => query.OrderBy(d => d.Code),
                ("createdat", true) => query.OrderByDescending(d => d.CreatedAt),
                ("createdat", false) => query.OrderBy(d => d.CreatedAt),
                ("updatedat", true) => query.OrderByDescending(d => d.UpdatedAt),
                ("updatedat", false) => query.OrderBy(d => d.UpdatedAt),
                _ => query.OrderByDescending(d => d.CreatedAt)
            };

            var departments = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var items = departments.Select(d => new DepartmentListDto
            {
                Id = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                IsActive = d.IsActive,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt
            }).ToList();

            return new PagedResultDto<DepartmentListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<DepartmentResponseDto?> GetDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments
                .IgnoreQueryFilters()
                .Include(d => d.CreatedByUser)
                .Include(d => d.UpdatedByUser)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (department == null) return null;

            return new DepartmentResponseDto
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                IsActive = department.IsActive,
                CreatedAt = department.CreatedAt,
                UpdatedAt = department.UpdatedAt,
                DeletedAt = department.DeletedAt,
                CreatedBy = department.CreatedBy,
                UpdatedBy = department.UpdatedBy,
                CreatedByName = department.CreatedByUser != null
                    ? $"{department.CreatedByUser.FirstName} {department.CreatedByUser.LastName}".Trim()
                    : null,
                UpdatedByName = department.UpdatedByUser != null
                    ? $"{department.UpdatedByUser.FirstName} {department.UpdatedByUser.LastName}".Trim()
                    : null
            };
        }

        public async Task<PagedResultDto<DepartmentListDto>> GetArchivedDepartmentsAsync(PaginationDto pagination)
        {
            var query = _context.Departments
                .IgnoreQueryFilters()
                .Where(d => d.DeletedAt != null)
                .AsQueryable();

            // Search by name or code
            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(d =>
                    d.Name.ToLower().Contains(searchLower) ||
                    d.Code.ToLower().Contains(searchLower));
            }

            var totalCount = await query.CountAsync();

            var departments = await query
                .OrderByDescending(d => d.DeletedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var items = departments.Select(d => new DepartmentListDto
            {
                Id = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                IsActive = d.IsActive,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt
            }).ToList();

            return new PagedResultDto<DepartmentListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<DepartmentResponseDto> CreateDepartmentAsync(CreateDepartmentDto dto, int? currentUserId)
        {
            // Check for duplicate name
            var existingByName = await _context.Departments
                .FirstOrDefaultAsync(d =>
                    d.Name.ToLower() == dto.Name.ToLower() &&
                    d.DeletedAt == null);

            if (existingByName != null)
            {
                throw new InvalidOperationException($"A department with the name '{dto.Name}' already exists.");
            }

            // Check for duplicate code
            var existingByCode = await _context.Departments
                .FirstOrDefaultAsync(d =>
                    d.Code.ToLower() == dto.Code.ToLower() &&
                    d.DeletedAt == null);

            if (existingByCode != null)
            {
                throw new InvalidOperationException($"A department with the code '{dto.Code}' already exists.");
            }

            var department = new Department
            {
                Name = dto.Name,
                Code = dto.Code.ToUpper(),
                Description = dto.Description,
                IsActive = dto.IsActive,
                CreatedBy = currentUserId,
                UpdatedBy = currentUserId
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            var createDetails = $"Created department: {department.Name} ({department.Code}), IsActive: {department.IsActive}";
            await _auditService.LogAsync("Departments", "Create", createDetails, currentUserId);

            return (await GetDepartmentByIdAsync(department.Id))!;
        }

        public async Task<DepartmentResponseDto?> UpdateDepartmentAsync(int id, UpdateDepartmentDto dto, int? currentUserId)
        {
            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.Id == id && d.DeletedAt == null);

            if (department == null) return null;

            var changes = new List<string>();
            var originalName = department.Name;

            // Check for duplicate name if name is being changed
            if (!string.IsNullOrEmpty(dto.Name) && dto.Name.ToLower() != department.Name.ToLower())
            {
                var existingByName = await _context.Departments
                    .FirstOrDefaultAsync(d =>
                        d.Name.ToLower() == dto.Name.ToLower() &&
                        d.Id != id &&
                        d.DeletedAt == null);

                if (existingByName != null)
                {
                    throw new InvalidOperationException($"A department with the name '{dto.Name}' already exists.");
                }

                changes.Add($"Name: {department.Name} → {dto.Name}");
                department.Name = dto.Name;
            }

            // Check for duplicate code if code is being changed
            if (!string.IsNullOrEmpty(dto.Code) && dto.Code.ToLower() != department.Code.ToLower())
            {
                var existingByCode = await _context.Departments
                    .FirstOrDefaultAsync(d =>
                        d.Code.ToLower() == dto.Code.ToLower() &&
                        d.Id != id &&
                        d.DeletedAt == null);

                if (existingByCode != null)
                {
                    throw new InvalidOperationException($"A department with the code '{dto.Code}' already exists.");
                }

                changes.Add($"Code: {department.Code} → {dto.Code.ToUpper()}");
                department.Code = dto.Code.ToUpper();
            }

            if (dto.Description != null && dto.Description != department.Description)
            {
                changes.Add($"Description updated");
                department.Description = dto.Description;
            }

            if (dto.IsActive.HasValue && dto.IsActive.Value != department.IsActive)
            {
                changes.Add($"IsActive: {department.IsActive} → {dto.IsActive.Value}");
                department.IsActive = dto.IsActive.Value;
            }

            department.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();

            var updateDetails = changes.Any()
                ? $"Updated department: {originalName} -> {string.Join(", ", changes)}"
                : $"Updated department: {originalName} (no changes detected)";
            await _auditService.LogAsync("Departments", "Update", updateDetails, currentUserId);

            return await GetDepartmentByIdAsync(department.Id);
        }

        public async Task<bool> DeleteDepartmentAsync(int id, int? currentUserId)
        {
            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.Id == id && d.DeletedAt == null);

            if (department == null) return false;

            department.IsActive = false;
            department.DeletedAt = DateTime.UtcNow;
            department.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var deleteDetails = $"Soft deleted department: {department.Name} ({department.Code})";
            await _auditService.LogAsync("Departments", "Delete", deleteDetails, currentUserId);

            return true;
        }

        public async Task<bool> RestoreDepartmentAsync(int id, int? currentUserId)
        {
            var department = await _context.Departments.IgnoreQueryFilters()
                .FirstOrDefaultAsync(d => d.Id == id && d.DeletedAt != null);

            if (department == null) return false;

            department.IsActive = true;
            department.DeletedAt = null;
            department.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var restoreDetails = $"Restored department: {department.Name} ({department.Code})";
            await _auditService.LogAsync("Departments", "Restore", restoreDetails, currentUserId);

            return true;
        }

        public async Task<bool> PermanentDeleteDepartmentAsync(int id, int? currentUserId)
        {
            var department = await _context.Departments.IgnoreQueryFilters()
                .FirstOrDefaultAsync(d => d.Id == id && d.DeletedAt != null);

            if (department == null) return false;

            var departmentName = department.Name;
            var departmentCode = department.Code;

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            var permanentDeleteDetails = $"Permanently deleted department: {departmentName} ({departmentCode})";
            await _auditService.LogAsync("Departments", "PermanentDelete", permanentDeleteDetails, currentUserId);

            return true;
        }
    }
}
