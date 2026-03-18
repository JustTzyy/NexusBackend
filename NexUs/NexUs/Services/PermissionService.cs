using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Permissions;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAuditService _auditService;

        public PermissionService(ApplicationDbContext context, IMapper mapper, IAuditService auditService)
        {
            _context = context;
            _mapper = mapper;
            _auditService = auditService;
        }

        public async Task<PagedResultDto<PermissionListDto>> GetAllPermissionsAsync(PaginationDto pagination)
        {
            var query = _context.Permissions.AsQueryable();

            // Apply module filter
            if (!string.IsNullOrWhiteSpace(pagination.Module))
            {
                query = query.Where(p => p.Module.ToLower() == pagination.Module.ToLower());
            }

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(pagination.SearchTerm))
            {
                var searchTerm = pagination.SearchTerm.ToLower();
                query = query.Where(p =>
                    p.Name.ToLower().Contains(searchTerm) ||
                    p.Module.ToLower().Contains(searchTerm) ||
                    (p.Description != null && p.Description.ToLower().Contains(searchTerm)));
            }

            // Apply sorting
            if (!string.IsNullOrWhiteSpace(pagination.SortBy))
            {
                query = pagination.SortBy.ToLower() switch
                {
                    "name" => pagination.SortDescending ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name),
                    "module" => pagination.SortDescending ? query.OrderByDescending(p => p.Module) : query.OrderBy(p => p.Module),
                    "createdat" => pagination.SortDescending ? query.OrderByDescending(p => p.CreatedAt) : query.OrderBy(p => p.CreatedAt),
                    _ => query.OrderBy(p => p.Id)
                };
            }
            else
            {
                query = query.OrderBy(p => p.Module).ThenBy(p => p.Name);
            }

            var totalCount = await query.CountAsync();

            var permissions = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var permissionDtos = _mapper.Map<List<PermissionListDto>>(permissions);

            return new PagedResultDto<PermissionListDto>
            {
                Items = permissionDtos,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<PermissionResponseDto?> GetPermissionByIdAsync(int id)
        {
            var permission = await _context.Permissions
                .IgnoreQueryFilters()
                .Include(p => p.CreatedByUser)
                .Include(p => p.UpdatedByUser)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (permission == null) return null;

            var dto = _mapper.Map<PermissionResponseDto>(permission);
            dto.CreatedByName = permission.CreatedByUser != null
                ? $"{permission.CreatedByUser.FirstName} {permission.CreatedByUser.LastName}".Trim()
                : null;
            dto.UpdatedByName = permission.UpdatedByUser != null
                ? $"{permission.UpdatedByUser.FirstName} {permission.UpdatedByUser.LastName}".Trim()
                : null;

            return dto;
        }

        public async Task<List<PermissionListDto>> GetPermissionsByModuleAsync(string module)
        {
            var permissions = await _context.Permissions
                .Where(p => p.Module == module)
                .OrderBy(p => p.Name)
                .ToListAsync();

            return _mapper.Map<List<PermissionListDto>>(permissions);
        }

        public async Task<PagedResultDto<PermissionListDto>> GetArchivedPermissionsAsync(PaginationDto pagination)
        {
            var query = _context.Permissions.IgnoreQueryFilters()
                .Where(p => p.DeletedAt != null);

            // Apply module filter
            if (!string.IsNullOrWhiteSpace(pagination.Module))
            {
                query = query.Where(p => p.Module.ToLower() == pagination.Module.ToLower());
            }

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(pagination.SearchTerm))
            {
                var searchTerm = pagination.SearchTerm.ToLower();
                query = query.Where(p =>
                    p.Name.ToLower().Contains(searchTerm) ||
                    p.Module.ToLower().Contains(searchTerm));
            }

            // Apply sorting
            if (!string.IsNullOrWhiteSpace(pagination.SortBy))
            {
                query = pagination.SortBy.ToLower() switch
                {
                    "name" => pagination.SortDescending ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name),
                    "module" => pagination.SortDescending ? query.OrderByDescending(p => p.Module) : query.OrderBy(p => p.Module),
                    "deletedat" => pagination.SortDescending ? query.OrderByDescending(p => p.DeletedAt) : query.OrderBy(p => p.DeletedAt),
                    _ => query.OrderByDescending(p => p.DeletedAt)
                };
            }
            else
            {
                query = query.OrderByDescending(p => p.DeletedAt);
            }

            var totalCount = await query.CountAsync();

            var permissions = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var permissionDtos = _mapper.Map<List<PermissionListDto>>(permissions);

            return new PagedResultDto<PermissionListDto>
            {
                Items = permissionDtos,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<PermissionResponseDto> CreatePermissionAsync(CreatePermissionDto dto, int? currentUserId)
        {
            // Check for duplicate permission (Name + Module combination)
            var exists = await _context.Permissions
                .AnyAsync(p => p.Name == dto.Name && p.Module == dto.Module);

            if (exists)
            {
                throw new InvalidOperationException($"Permission '{dto.Name}' already exists in module '{dto.Module}'");
            }

            var permission = _mapper.Map<Permission>(dto);
            permission.CreatedBy = currentUserId;
            permission.UpdatedBy = currentUserId;

            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();

            var createDetails = $"Created permission: {permission.Name} -> Module: {permission.Module}, Description: {permission.Description ?? "null"}";
            await _auditService.LogAsync("Permissions", "Create", createDetails, currentUserId);

            return _mapper.Map<PermissionResponseDto>(permission);
        }

        public async Task<PermissionResponseDto?> UpdatePermissionAsync(int id, UpdatePermissionDto dto, int? currentUserId)
        {
            var permission = await _context.Permissions.FindAsync(id);
            if (permission == null) return null;

            // Track changes
            var changes = new List<string>();
            var originalName = permission.Name;
            
            if (dto.Name != null && dto.Name != permission.Name)
                changes.Add($"Name: {permission.Name} → {dto.Name}");
            if (dto.Module != null && dto.Module != permission.Module)
                changes.Add($"Module: {permission.Module} → {dto.Module}");
            if (dto.Description != null && dto.Description != permission.Description)
                changes.Add($"Description: {permission.Description ?? "null"} → {dto.Description}");

            // Check for duplicate if name or module is being changed
            if ((dto.Name != null && dto.Name != permission.Name) ||
                (dto.Module != null && dto.Module != permission.Module))
            {
                var newName = dto.Name ?? permission.Name;
                var newModule = dto.Module ?? permission.Module;

                var exists = await _context.Permissions
                    .AnyAsync(p => p.Id != id && p.Name == newName && p.Module == newModule);

                if (exists)
                {
                    throw new InvalidOperationException($"Permission '{newName}' already exists in module '{newModule}'");
                }
            }

            _mapper.Map(dto, permission);
            permission.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            // Build detailed audit log
            var updateDetails = changes.Any()
                ? $"Updated permission: {originalName} -> {string.Join(", ", changes)}"
                : $"Updated permission: {originalName} (no changes detected)";
            await _auditService.LogAsync("Permissions", "Update", updateDetails, currentUserId);

            return _mapper.Map<PermissionResponseDto>(permission);
        }

        public async Task<bool> DeletePermissionAsync(int id, int? currentUserId)
        {
            var permission = await _context.Permissions.FindAsync(id);
            if (permission == null) return false;

            permission.DeletedAt = DateTime.UtcNow;
            permission.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var deleteDetails = $"Soft deleted permission: {permission.Name} -> Module: {permission.Module}";
            await _auditService.LogAsync("Permissions", "Delete", deleteDetails, currentUserId);

            return true;
        }

        public async Task<bool> RestorePermissionAsync(int id, int? currentUserId)
        {
            var permission = await _context.Permissions.IgnoreQueryFilters()
                .FirstOrDefaultAsync(p => p.Id == id && p.DeletedAt != null);

            if (permission == null) return false;

            permission.DeletedAt = null;
            permission.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var restoreDetails = $"Restored permission: {permission.Name} -> Module: {permission.Module}";
            await _auditService.LogAsync("Permissions", "Restore", restoreDetails, currentUserId);

            return true;
        }

        public async Task<List<string>> GetUserPermissionsAsync(int userId)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                        .ThenInclude(r => r.RolePermissions)
                            .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(u => u.Id == userId && u.DeletedAt == null);

            return user?.UserRoles
                .SelectMany(ur => ur.Role.RolePermissions)
                .Where(rp => rp.Permission.DeletedAt == null)
                .Select(rp => rp.Permission.Name)
                .Distinct()
                .ToList() ?? [];
        }

        public async Task<bool> PermanentDeletePermissionAsync(int id, int? currentUserId)
        {
            var permission = await _context.Permissions.IgnoreQueryFilters()
                .FirstOrDefaultAsync(p => p.Id == id && p.DeletedAt != null);

            if (permission == null) return false;

            var permissionName = permission.Name;

            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();

            var permDeleteDetails = $"Permanently deleted permission: {permissionName} -> Module: {permission.Module}";
            await _auditService.LogAsync("Permissions", "PermanentDelete", permDeleteDetails, currentUserId);

            return true;
        }
    }
}
