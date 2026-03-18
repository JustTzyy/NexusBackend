using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Permissions;
using NexUs.Models.DTO.Roles;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAuditService _auditService;
        private readonly IMemoryCache _cache;

        public RoleService(ApplicationDbContext context, IMapper mapper, IAuditService auditService, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _auditService = auditService;
            _cache = cache;
        }

        public async Task<PagedResultDto<RoleListDto>> GetAllRolesAsync(PaginationDto pagination)
        {
            var query = _context.Roles
                .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .AsQueryable();

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(pagination.SearchTerm))
            {
                var searchTerm = pagination.SearchTerm.ToLower();
                query = query.Where(r =>
                    r.Name.ToLower().Contains(searchTerm) ||
                    (r.Description != null && r.Description.ToLower().Contains(searchTerm)));
            }

            // Apply sorting
            if (!string.IsNullOrWhiteSpace(pagination.SortBy))
            {
                query = pagination.SortBy.ToLower() switch
                {
                    "name" => pagination.SortDescending ? query.OrderByDescending(r => r.Name) : query.OrderBy(r => r.Name),
                    "createdat" => pagination.SortDescending ? query.OrderByDescending(r => r.CreatedAt) : query.OrderBy(r => r.CreatedAt),
                    _ => query.OrderBy(r => r.Id)
                };
            }
            else
            {
                query = query.OrderBy(r => r.Name);
            }

            var totalCount = await query.CountAsync();

            var roles = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var roleDtos = _mapper.Map<List<RoleListDto>>(roles);

            return new PagedResultDto<RoleListDto>
            {
                Items = roleDtos,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<RoleResponseDto?> GetRoleByIdAsync(int id)
        {
            var role = await _context.Roles
                .IgnoreQueryFilters()
                .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .Include(r => r.CreatedByUser)
                .Include(r => r.UpdatedByUser)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (role == null) return null;

            var dto = _mapper.Map<RoleResponseDto>(role);
            dto.CreatedByName = role.CreatedByUser != null
                ? $"{role.CreatedByUser.FirstName} {role.CreatedByUser.LastName}".Trim()
                : null;
            dto.UpdatedByName = role.UpdatedByUser != null
                ? $"{role.UpdatedByUser.FirstName} {role.UpdatedByUser.LastName}".Trim()
                : null;

            return dto;
        }

        public async Task<List<PermissionListDto>> GetRolePermissionsAsync(int roleId)
        {
            var permissions = await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId)
                .Include(rp => rp.Permission)
                .Select(rp => rp.Permission)
                .ToListAsync();

            return _mapper.Map<List<PermissionListDto>>(permissions);
        }

        public async Task<PagedResultDto<RoleListDto>> GetArchivedRolesAsync(PaginationDto pagination)
        {
            var query = _context.Roles.IgnoreQueryFilters()
                .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .Where(r => r.DeletedAt != null);

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(pagination.SearchTerm))
            {
                var searchTerm = pagination.SearchTerm.ToLower();
                query = query.Where(r =>
                    r.Name.ToLower().Contains(searchTerm) ||
                    (r.Description != null && r.Description.ToLower().Contains(searchTerm)));
            }

            // Apply sorting
            if (!string.IsNullOrWhiteSpace(pagination.SortBy))
            {
                query = pagination.SortBy.ToLower() switch
                {
                    "name" => pagination.SortDescending ? query.OrderByDescending(r => r.Name) : query.OrderBy(r => r.Name),
                    "deletedat" => pagination.SortDescending ? query.OrderByDescending(r => r.DeletedAt) : query.OrderBy(r => r.DeletedAt),
                    _ => query.OrderByDescending(r => r.DeletedAt)
                };
            }
            else
            {
                query = query.OrderByDescending(r => r.DeletedAt);
            }

            var totalCount = await query.CountAsync();

            var roles = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var roleDtos = _mapper.Map<List<RoleListDto>>(roles);

            return new PagedResultDto<RoleListDto>
            {
                Items = roleDtos,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<RoleResponseDto> CreateRoleAsync(CreateRoleDto dto, int? currentUserId)
        {
            // Check for duplicate role name
            var exists = await _context.Roles.AnyAsync(r => r.Name == dto.Name);
            if (exists)
            {
                throw new InvalidOperationException($"Role '{dto.Name}' already exists");
            }

            var role = _mapper.Map<Role>(dto);
            role.CreatedBy = currentUserId;
            role.UpdatedBy = currentUserId;

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            // Assign permissions if provided
            if (dto.PermissionIds != null && dto.PermissionIds.Any())
            {
                foreach (var permissionId in dto.PermissionIds)
                {
                    _context.RolePermissions.Add(new RolePermission
                    {
                        RoleId = role.Id,
                        PermissionId = permissionId
                    });
                }
                await _context.SaveChangesAsync();
            }

            // Get permission names for audit log
            var permissionNames = dto.PermissionIds != null && dto.PermissionIds.Any()
                ? await _context.Permissions.Where(p => dto.PermissionIds.Contains(p.Id)).Select(p => p.Name).ToListAsync()
                : new List<string>();
            var permNamesStr = permissionNames.Any() ? string.Join(", ", permissionNames) : "None";
            var createDetails = $"Created role: {role.Name} -> Description: {role.Description ?? "null"}, Permissions: {permNamesStr}";
            await _auditService.LogAsync("Roles", "Create", createDetails, currentUserId);

            return _mapper.Map<RoleResponseDto>(await GetRoleByIdAsync(role.Id));
        }

        public async Task<RoleResponseDto?> UpdateRoleAsync(int id, UpdateRoleDto dto, int? currentUserId)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return null;

            // Track changes
            var changes = new List<string>();
            var originalName = role.Name;
            
            if (dto.Name != null && dto.Name != role.Name)
                changes.Add($"Name: {role.Name} → {dto.Name}");
            if (dto.Description != null && dto.Description != role.Description)
                changes.Add($"Description: {role.Description ?? "null"} → {dto.Description}");

            // Check for duplicate name if being changed
            if (dto.Name != null && dto.Name != role.Name)
            {
                var exists = await _context.Roles.AnyAsync(r => r.Id != id && r.Name == dto.Name);
                if (exists)
                {
                    throw new InvalidOperationException($"Role '{dto.Name}' already exists");
                }
            }

            _mapper.Map(dto, role);
            role.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            // Update permissions if provided
            if (dto.PermissionIds != null)
            {
                // Get existing permission IDs
                var existingPermIds = await _context.RolePermissions
                    .Where(rp => rp.RoleId == id)
                    .Select(rp => rp.PermissionId)
                    .ToListAsync();
                
                var addedPermIds = dto.PermissionIds.Except(existingPermIds).ToList();
                var removedPermIds = existingPermIds.Except(dto.PermissionIds).ToList();
                
                if (addedPermIds.Any() || removedPermIds.Any())
                {
                    var allPerms = await _context.Permissions.ToListAsync();
                    if (addedPermIds.Any())
                        changes.Add($"Permissions Added: {string.Join(", ", allPerms.Where(p => addedPermIds.Contains(p.Id)).Select(p => p.Name))}");
                    if (removedPermIds.Any())
                        changes.Add($"Permissions Removed: {string.Join(", ", allPerms.Where(p => removedPermIds.Contains(p.Id)).Select(p => p.Name))}");
                }

                // Remove existing role-permission assignments
                var existingRolePermissions = await _context.RolePermissions
                    .Where(rp => rp.RoleId == id)
                    .ToListAsync();
                
                _context.RolePermissions.RemoveRange(existingRolePermissions);

                // Add new role-permission assignments
                foreach (var permissionId in dto.PermissionIds)
                {
                    _context.RolePermissions.Add(new RolePermission
                    {
                        RoleId = id,
                        PermissionId = permissionId
                    });
                }
                
                await _context.SaveChangesAsync();
            }

            // Invalidate permission cache for all users who have this role
            await InvalidateCacheForRoleAsync(id);

            // Build detailed audit log
            var updateDetails = changes.Any()
                ? $"Updated role: {originalName} -> {string.Join(", ", changes)}"
                : $"Updated role: {originalName} (no changes detected)";
            await _auditService.LogAsync("Roles", "Update", updateDetails, currentUserId);

            return _mapper.Map<RoleResponseDto>(await GetRoleByIdAsync(role.Id));
        }

        public async Task<bool> DeleteRoleAsync(int id, int? currentUserId)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;

            role.DeletedAt = DateTime.UtcNow;
            role.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var deleteDetails = $"Soft deleted role: {role.Name} -> Description: {role.Description ?? "null"}";
            await _auditService.LogAsync("Roles", "Delete", deleteDetails, currentUserId);

            return true;
        }

        public async Task<bool> RestoreRoleAsync(int id, int? currentUserId)
        {
            var role = await _context.Roles.IgnoreQueryFilters()
                .FirstOrDefaultAsync(r => r.Id == id && r.DeletedAt != null);

            if (role == null) return false;

            role.DeletedAt = null;
            role.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var restoreDetails = $"Restored role: {role.Name} -> Description: {role.Description ?? "null"}";
            await _auditService.LogAsync("Roles", "Restore", restoreDetails, currentUserId);

            return true;
        }

        public async Task<bool> PermanentDeleteRoleAsync(int id, int? currentUserId)
        {
            var role = await _context.Roles.IgnoreQueryFilters()
                .FirstOrDefaultAsync(r => r.Id == id && r.DeletedAt != null);

            if (role == null) return false;

            var roleName = role.Name;

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            var permDeleteDetails = $"Permanently deleted role: {roleName} -> Description: {role.Description ?? "null"}";
            await _auditService.LogAsync("Roles", "PermanentDelete", permDeleteDetails, currentUserId);

            return true;
        }

        public async Task<bool> AssignPermissionsToRoleAsync(int roleId, AssignPermissionsDto dto, int? currentUserId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role == null) return false;

            // Remove existing role-permission assignments
            var existingRolePermissions = await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId)
                .ToListAsync();

            _context.RolePermissions.RemoveRange(existingRolePermissions);

            // Add new role-permission assignments
            foreach (var permissionId in dto.PermissionIds)
            {
                _context.RolePermissions.Add(new RolePermission
                {
                    RoleId = roleId,
                    PermissionId = permissionId
                });
            }

            await _context.SaveChangesAsync();

            // Get permission names for detailed log
            var permNames = await _context.Permissions
                .Where(p => dto.PermissionIds.Contains(p.Id))
                .Select(p => p.Name)
                .ToListAsync();
            var permNamesStr = permNames.Any() ? string.Join(", ", permNames) : "None";
            var assignDetails = $"Assigned permissions to role: {role.Name} -> Permissions: {permNamesStr}";
            await _auditService.LogAsync("Roles", "AssignPermissions", assignDetails, currentUserId);

            // Invalidate permission cache for all users who have this role
            await InvalidateCacheForRoleAsync(roleId);

            return true;
        }

        private async Task InvalidateCacheForRoleAsync(int roleId)
        {
            var affectedUserIds = await _context.UserRoles
                .Where(ur => ur.RoleId == roleId)
                .Select(ur => ur.UserId)
                .ToListAsync();

            foreach (var uid in affectedUserIds)
                _cache.Remove($"user_perms_{uid}");
        }
    }
}
