using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Roles;
using NexUs.Models.DTO.Users;
using NexUs.Models.DTO.Notifications;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAuditService _auditService;
        private readonly IPasswordService _passwordService;
        private readonly IEmailService _emailService;
        private readonly ILocationService _locationService;
        private readonly ILogger<UserService> _logger;
        private readonly IAutomationService _automationService;
        private readonly IMemoryCache _cache;
        private readonly INotificationService _notificationService;

        public UserService(
            ApplicationDbContext context,
            IMapper mapper,
            IAuditService auditService,
            IPasswordService passwordService,
            IEmailService emailService,
            ILocationService locationService,
            ILogger<UserService> logger,
            IAutomationService automationService,
            IMemoryCache cache,
            INotificationService notificationService)
        {
            _context = context;
            _mapper = mapper;
            _auditService = auditService;
            _passwordService = passwordService;
            _emailService = emailService;
            _locationService = locationService;
            _logger = logger;
            _automationService = automationService;
            _cache = cache;
            _notificationService = notificationService;
        }

        public async Task<PagedResultDto<UserListDto>> GetAllUsersAsync(PaginationDto pagination)
        {
            var excludedRoles = new[] { "Lead", "Customer" };

            var query = _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .Where(u => !u.UserRoles.Any(ur => excludedRoles.Contains(ur.Role.Name)))
                .AsQueryable();

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(pagination.SearchTerm))
            {
                var searchTerm = pagination.SearchTerm.ToLower();
                query = query.Where(u =>
                    u.FirstName.ToLower().Contains(searchTerm) ||
                    u.LastName.ToLower().Contains(searchTerm) ||
                    u.Email.ToLower().Contains(searchTerm));
            }

            // Apply sorting
            if (!string.IsNullOrWhiteSpace(pagination.SortBy))
            {
                query = pagination.SortBy.ToLower() switch
                {
                    "name" => pagination.SortDescending
                        ? query.OrderByDescending(u => u.FirstName).ThenByDescending(u => u.LastName)
                        : query.OrderBy(u => u.FirstName).ThenBy(u => u.LastName),
                    "email" => pagination.SortDescending ? query.OrderByDescending(u => u.Email) : query.OrderBy(u => u.Email),
                    "createdat" => pagination.SortDescending ? query.OrderByDescending(u => u.CreatedAt) : query.OrderBy(u => u.CreatedAt),
                    _ => query.OrderBy(u => u.Id)
                };
            }
            else
            {
                query = query.OrderBy(u => u.FirstName).ThenBy(u => u.LastName);
            }

            var totalCount = await query.CountAsync();

            var users = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var userDtos = _mapper.Map<List<UserListDto>>(users);

            return new PagedResultDto<UserListDto>
            {
                Items = userDtos,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<UserResponseDto?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .IgnoreQueryFilters() // Allow retrieving soft-deleted users
                .Include(u => u.Address)
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .Include(u => u.CreatedByUser)
                .Include(u => u.UpdatedByUser)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null) return null;

            var dto = _mapper.Map<UserResponseDto>(user);

            // Set creator and updater names manually if not handled by AutoMapper
            if (user.CreatedByUser != null)
                dto.CreatedByName = $"{user.CreatedByUser.FirstName} {user.CreatedByUser.LastName}".Trim();

            if (user.UpdatedByUser != null)
                dto.UpdatedByName = $"{user.UpdatedByUser.FirstName} {user.UpdatedByUser.LastName}".Trim();

            // Populate PreferredBuilding from StudentAssignment
            var sa = await _context.StudentAssignments
                .Include(s => s.PreferredBuilding)
                .FirstOrDefaultAsync(s => s.StudentId == id && s.DeletedAt == null);
            dto.PreferredBuildingId = sa?.PreferredBuildingId;
            dto.PreferredBuildingName = sa?.PreferredBuilding?.Name;

            return dto;
        }

        public async Task<List<RoleListDto>> GetUserRolesAsync(int userId)
        {
            var roles = await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Include(ur => ur.Role)
                .Select(ur => ur.Role)
                .ToListAsync();

            return _mapper.Map<List<RoleListDto>>(roles);
        }

        public async Task<PagedResultDto<UserListDto>> GetArchivedUsersAsync(PaginationDto pagination)
        {
            var excludedRoles = new[] { "Lead", "Customer" };

            var query = _context.Users.IgnoreQueryFilters()
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .Where(u => u.DeletedAt != null
                    && !u.UserRoles.Any(ur => excludedRoles.Contains(ur.Role.Name)));

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(pagination.SearchTerm))
            {
                var searchTerm = pagination.SearchTerm.ToLower();
                query = query.Where(u =>
                    u.FirstName.ToLower().Contains(searchTerm) ||
                    u.LastName.ToLower().Contains(searchTerm) ||
                    u.Email.ToLower().Contains(searchTerm));
            }

            // Apply sorting
            if (!string.IsNullOrWhiteSpace(pagination.SortBy))
            {
                query = pagination.SortBy.ToLower() switch
                {
                    "name" => pagination.SortDescending
                        ? query.OrderByDescending(u => u.FirstName).ThenByDescending(u => u.LastName)
                        : query.OrderBy(u => u.FirstName).ThenBy(u => u.LastName),
                    "email" => pagination.SortDescending ? query.OrderByDescending(u => u.Email) : query.OrderBy(u => u.Email),
                    "deletedat" => pagination.SortDescending ? query.OrderByDescending(u => u.DeletedAt) : query.OrderBy(u => u.DeletedAt),
                    _ => query.OrderByDescending(u => u.DeletedAt)
                };
            }
            else
            {
                query = query.OrderByDescending(u => u.DeletedAt);
            }

            var totalCount = await query.CountAsync();

            var users = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var userDtos = _mapper.Map<List<UserListDto>>(users);

            return new PagedResultDto<UserListDto>
            {
                Items = userDtos,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<UserResponseDto> CreateUserAsync(CreateUserDto dto, int? currentUserId)
        {
            // Check for duplicate email
            var exists = await _context.Users
                .IgnoreQueryFilters()
                .AnyAsync(u => u.Email == dto.Email);

            if (exists)
            {
                throw new InvalidOperationException($"User with email '{dto.Email}' already exists");
            }

            // Create user entity
            var user = _mapper.Map<User>(dto);
            user.CreatedBy = currentUserId;
            user.UpdatedBy = currentUserId;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Generate default password
            var defaultPassword = _passwordService.GeneratePassword();
            var passwordHash = _passwordService.HashPassword(defaultPassword);

            // Create user credential
            var credential = new UserCredential
            {
                UserId = user.Id,
                PasswordHash = passwordHash,
                DefaultPassword = defaultPassword, // Store for email (consider encrypting in production)
                IsPasswordChanged = false
            };

            _context.UserCredentials.Add(credential);
            await _context.SaveChangesAsync();

            // Assign roles if provided
            List<string> roleNames = new List<string>();
            if (dto.RoleIds != null && dto.RoleIds.Any())
            {
                var roles = await _context.Roles
                    .Where(r => dto.RoleIds.Contains(r.Id))
                    .ToListAsync();

                foreach (var roleId in dto.RoleIds)
                {
                    _context.UserRoles.Add(new UserRole
                    {
                        UserId = user.Id,
                        RoleId = roleId
                    });
                }
                await _context.SaveChangesAsync();

                roleNames = roles.Select(r => r.Name).ToList();
            }

            // Send welcome email via automation pipeline (don't throw if email fails)
            try
            {
                var userName = $"{user.FirstName} {user.LastName}".Trim();
                var emailSent = await _automationService.TriggerAndSendImmediatelyAsync("UserCreated", new Dictionary<string, object>
                {
                    { "Email", user.Email },
                    { "FirstName", user.FirstName ?? "" },
                    { "UserName", userName },
                    { "DefaultPassword", defaultPassword },
                    { "Roles", string.Join(", ", roleNames) }
                });

                if (!emailSent)
                {
                    _logger.LogWarning("Automation pipeline did not send welcome email to {Email}; falling back to direct send", user.Email);
                    emailSent = await _emailService.SendWelcomeEmailAsync(user.Email, userName, defaultPassword, roleNames);
                    if (!emailSent)
                        _logger.LogWarning("Direct welcome email also failed for {Email}; user was created successfully", user.Email);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception sending welcome email to {user.Email}, but user was created successfully");
            }

            // Build detailed audit log message
            var roleNamesStr = roleNames.Any() ? string.Join(", ", roleNames) : "None";
            var createDetails = $"Created user: {user.Email} -> Name: {user.FirstName} {user.LastName}, Roles: {roleNamesStr}";
            await _auditService.LogAsync("Users", "Create", createDetails, currentUserId);

            // Notify Super Admin: new user created
            try
            {
                await _notificationService.CreateAsync(new CreateNotificationDto
                {
                    RecipientRole = "Super Admin",
                    Title = "New User Created",
                    Message = $"A new user has been created: {user.FirstName} {user.LastName} ({user.Email}) with roles: {roleNamesStr}.",
                    Type = "General",
                    Priority = "Normal",
                    ReferenceId = user.Id,
                    ReferenceType = "User"
                }, currentUserId);
            }
            catch { /* silent */ }

            return _mapper.Map<UserResponseDto>(await GetUserByIdAsync(user.Id));
        }

        public async Task<UserResponseDto?> UpdateUserAsync(int id, UpdateUserDto dto, int? currentUserId)
        {
            var user = await _context.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return null;

            // Track changes before applying updates
            var changes = new List<string>();
            
            // Track basic field changes
            if (dto.FirstName != null && dto.FirstName != user.FirstName)
                changes.Add($"FirstName: {user.FirstName ?? "null"} → {dto.FirstName}");
            if (dto.LastName != null && dto.LastName != user.LastName)
                changes.Add($"LastName: {user.LastName ?? "null"} → {dto.LastName}");
            if (dto.Email != null && dto.Email != user.Email)
                changes.Add($"Email: {user.Email} → {dto.Email}");
            if (dto.Phone != null && dto.Phone != user.Phone)
                changes.Add($"Phone: {user.Phone ?? "null"} → {dto.Phone}");
            if (dto.DateOfBirth.HasValue && dto.DateOfBirth != user.DateOfBirth)
                changes.Add($"DateOfBirth: {user.DateOfBirth?.ToString("yyyy-MM-dd") ?? "null"} → {dto.DateOfBirth?.ToString("yyyy-MM-dd")}");
            if (dto.Gender != null && dto.Gender != user.Gender)
                changes.Add($"Gender: {user.Gender ?? "null"} → {dto.Gender}");

            // Track address changes
            if (dto.Address != null)
            {
                var oldAddress = user.Address;
                if (oldAddress != null)
                {
                    if (dto.Address.Street != null && dto.Address.Street != oldAddress.StreetBarangay)
                        changes.Add($"Street: {oldAddress.StreetBarangay ?? "null"} → {dto.Address.Street}");
                    if (dto.Address.City != null && dto.Address.City != oldAddress.CityMunicipality)
                        changes.Add($"City: {_locationService.ResolveCityName(oldAddress.CityMunicipality ?? "")} → {_locationService.ResolveCityName(dto.Address.City)}");
                    if (dto.Address.Province != null && dto.Address.Province != oldAddress.Province)
                        changes.Add($"Province: {_locationService.ResolveProvinceName(oldAddress.Province ?? "")} → {_locationService.ResolveProvinceName(dto.Address.Province)}");
                    if (dto.Address.Region != null && dto.Address.Region != oldAddress.Region)
                        changes.Add($"Region: {_locationService.ResolveRegionName(oldAddress.Region ?? "")} → {_locationService.ResolveRegionName(dto.Address.Region)}");
                }
                else
                {
                    changes.Add($"Address: Added new address");
                }
            }

            // Check for duplicate email if being changed
            if (dto.Email != null && dto.Email != user.Email)
            {
                var exists = await _context.Users
                    .IgnoreQueryFilters()
                    .AnyAsync(u => u.Id != id && u.Email == dto.Email);

                if (exists)
                {
                    throw new InvalidOperationException($"User with email '{dto.Email}' already exists");
                }
            }

            var originalEmail = user.Email;
            _mapper.Map(dto, user);

            // Handle address create/update
            if (dto.Address != null)
            {
                if (user.AddressId.HasValue)
                {
                    // Update existing address in-place
                    var existingAddress = await _context.Addresses.FindAsync(user.AddressId.Value);
                    if (existingAddress != null)
                    {
                        existingAddress.StreetBarangay = dto.Address.Street;
                        existingAddress.Region = dto.Address.Region;
                        existingAddress.Province = dto.Address.Province;
                        existingAddress.CityMunicipality = dto.Address.City;
                        existingAddress.Postal = dto.Address.PostalCode;
                    }
                }
                else
                {
                    // Create new address
                    var newAddress = new Address
                    {
                        StreetBarangay = dto.Address.Street,
                        Region = dto.Address.Region,
                        Province = dto.Address.Province,
                        CityMunicipality = dto.Address.City,
                        Postal = dto.Address.PostalCode
                    };
                    _context.Addresses.Add(newAddress);
                    await _context.SaveChangesAsync(); // Save to get the new ID
                    user.AddressId = newAddress.Id;
                }
            }

            // Track role changes
            if (dto.RoleIds != null)
            {
                var existingRoleIds = await _context.UserRoles
                    .Where(ur => ur.UserId == id)
                    .Select(ur => ur.RoleId)
                    .ToListAsync();
                
                var addedRoleIds = dto.RoleIds.Except(existingRoleIds).ToList();
                var removedRoleIds = existingRoleIds.Except(dto.RoleIds).ToList();
                
                if (addedRoleIds.Any() || removedRoleIds.Any())
                {
                    var allRoles = await _context.Roles.ToListAsync();
                    var addedRoleNames = allRoles.Where(r => addedRoleIds.Contains(r.Id)).Select(r => r.Name);
                    var removedRoleNames = allRoles.Where(r => removedRoleIds.Contains(r.Id)).Select(r => r.Name);
                    
                    if (addedRoleIds.Any())
                        changes.Add($"Roles Added: {string.Join(", ", addedRoleNames)}");
                    if (removedRoleIds.Any())
                        changes.Add($"Roles Removed: {string.Join(", ", removedRoleNames)}");
                }

                // Remove existing roles
                var existingRoles = await _context.UserRoles.Where(ur => ur.UserId == id).ToListAsync();
                _context.UserRoles.RemoveRange(existingRoles);

                // Add new roles
                foreach (var roleId in dto.RoleIds)
                {
                    _context.UserRoles.Add(new UserRole
                    {
                        UserId = id,
                        RoleId = roleId
                    });
                }
            }
            user.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            // Invalidate permission cache for this user (roles may have changed)
            _cache.Remove($"user_perms_{id}");

            // Sync name changes to the linked Lead record (if any)
            if (dto.FirstName != null || dto.LastName != null)
            {
                var lead = await _context.Leads.FirstOrDefaultAsync(l => l.UserId == id && l.DeletedAt == null);
                if (lead != null)
                {
                    if (dto.FirstName != null) lead.FirstName = user.FirstName;
                    if (dto.LastName != null) lead.LastName = user.LastName;
                    await _context.SaveChangesAsync();
                }
            }

            // Build detailed audit log message
            var updateDetails = changes.Any()
                ? $"Updated user: {originalEmail} -> {string.Join(", ", changes)}"
                : $"Updated user: {originalEmail} (no changes detected)";
            await _auditService.LogAsync("Users", "Update", updateDetails, currentUserId);

            return _mapper.Map<UserResponseDto>(await GetUserByIdAsync(user.Id));
        }

        public async Task<bool> DeleteUserAsync(int id, int? currentUserId)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            user.DeletedAt = DateTime.UtcNow;
            user.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var deleteDetails = $"Soft deleted user: {user.Email} -> Name: {user.FirstName} {user.LastName}";
            await _auditService.LogAsync("Users", "Delete", deleteDetails, currentUserId);

            return true;
        }

        public async Task<bool> RestoreUserAsync(int id, int? currentUserId)
        {
            var user = await _context.Users.IgnoreQueryFilters()
                .FirstOrDefaultAsync(u => u.Id == id && u.DeletedAt != null);

            if (user == null) return false;

            user.DeletedAt = null;
            user.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var restoreDetails = $"Restored user: {user.Email} -> Name: {user.FirstName} {user.LastName}";
            await _auditService.LogAsync("Users", "Restore", restoreDetails, currentUserId);

            return true;
        }

        public async Task<bool> PermanentDeleteUserAsync(int id, int? currentUserId)
        {
            var user = await _context.Users.IgnoreQueryFilters()
                .FirstOrDefaultAsync(u => u.Id == id && u.DeletedAt != null);

            if (user == null) return false;

            var userEmail = user.Email;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            var permDeleteDetails = $"Permanently deleted user: {userEmail} -> Name: {user.FirstName} {user.LastName}";
            await _auditService.LogAsync("Users", "PermanentDelete", permDeleteDetails, currentUserId);

            return true;
        }

        public async Task<bool> AssignRolesToUserAsync(int userId, List<int> roleIds, int? currentUserId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            // Remove existing user-role assignments
            var existingUserRoles = await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .ToListAsync();

            _context.UserRoles.RemoveRange(existingUserRoles);

            // Add new user-role assignments
            foreach (var roleId in roleIds)
            {
                _context.UserRoles.Add(new UserRole
                {
                    UserId = userId,
                    RoleId = roleId
                });
            }

            await _context.SaveChangesAsync();

            await _auditService.LogAsync("Users", "AssignRoles",
                $"Assigned {roleIds.Count} roles to user: {user.Email}", currentUserId);

            // Notify Super Admin: roles changed
            try
            {
                var newRoleNames = await _context.Roles
                    .Where(r => roleIds.Contains(r.Id))
                    .Select(r => r.Name)
                    .ToListAsync();
                await _notificationService.CreateAsync(new CreateNotificationDto
                {
                    RecipientRole = "Super Admin",
                    Title = "User Roles Updated",
                    Message = $"Roles for {user.Email} have been updated to: {string.Join(", ", newRoleNames)}.",
                    Type = "General",
                    Priority = "Normal",
                    ReferenceId = userId,
                    ReferenceType = "User"
                }, currentUserId);
            }
            catch { /* silent */ }

            // Invalidate permission cache for this user
            _cache.Remove($"user_perms_{userId}");

            return true;
        }

        public async Task<int> CountUsersCreatedBetweenAsync(DateTime startDate, DateTime endDate)
    {
        var excludedRoles = new[] { "Lead", "Customer" };
        return await _context.Users
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
            .Where(u => u.DeletedAt == null
                && u.CreatedAt >= startDate
                && u.CreatedAt < endDate
                && !u.UserRoles.Any(ur => excludedRoles.Contains(ur.Role.Name)))
            .CountAsync();
        }


        public async Task<List<UserListDto>> GetUsersByRoleAsync(string roleName)
        {
            var users = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .Where(u => u.DeletedAt == null &&
                       u.UserRoles.Any(ur => ur.Role.Name == roleName))
                .ToListAsync();

            return users.Select(u => _mapper.Map<UserListDto>(u)).ToList();
        }

        // ──────────────────────────────────────────────────────────────────────
        // Client Log (Lead + Customer) methods
        // ──────────────────────────────────────────────────────────────────────

        public async Task<PagedResultDto<ClientLogListDto>> GetClientSummariesAsync(PaginationDto pagination)
        {
            var clientRoles = new[] { "Lead", "Customer" };

            var query = _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .Where(u => u.DeletedAt == null &&
                            u.UserRoles.Any(ur => clientRoles.Contains(ur.Role.Name)))
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var term = pagination.SearchTerm.ToLower();
                query = query.Where(u =>
                    (u.FirstName + " " + u.LastName).ToLower().Contains(term) ||
                    u.Email.ToLower().Contains(term));
            }

            if (pagination.FromDate.HasValue)
                query = query.Where(u => u.CreatedAt >= pagination.FromDate.Value);
            if (pagination.ToDate.HasValue)
                query = query.Where(u => u.CreatedAt < pagination.ToDate.Value.AddDays(1));

            var totalCount = await query.CountAsync();

            var users = await query
                .OrderByDescending(u => u.CreatedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            // Fetch building from each user's most recent tutoring request
            var userIds = users.Select(u => u.Id).ToList();
            var latestBuildings = await _context.TutoringRequests
                .Where(r => r.StudentId.HasValue && userIds.Contains(r.StudentId!.Value) && r.DeletedAt == null)
                .Include(r => r.Building)
                .GroupBy(r => r.StudentId!.Value)
                .Select(g => new { StudentId = g.Key, BuildingName = g.OrderByDescending(r => r.CreatedAt).First().Building.Name })
                .ToListAsync();

            var buildingMap = latestBuildings.ToDictionary(x => x.StudentId, x => x.BuildingName);

            var items = users.Select(u => new ClientLogListDto
            {
                Id = u.Id,
                FullName = $"{u.FirstName} {u.LastName}",
                Email = u.Email,
                Roles = string.Join(", ", u.UserRoles.Select(ur => ur.Role.Name)),
                BuildingName = buildingMap.TryGetValue(u.Id, out var b) ? b : null,
                CreatedAt = u.CreatedAt,
            }).ToList();

            return new PagedResultDto<ClientLogListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<ClientDetailDto?> GetClientDetailAsync(int userId)
        {
            var clientRoles = new[] { "Lead", "Customer" };

            var user = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .Where(u => u.Id == userId &&
                            u.UserRoles.Any(ur => clientRoles.Contains(ur.Role.Name)))
                .FirstOrDefaultAsync();

            if (user == null) return null;

            var requests = await _context.TutoringRequests
                .Include(r => r.Subject)
                .Include(r => r.Building)
                .Include(r => r.Room)
                .Include(r => r.AvailableDay)
                .Include(r => r.AvailableTimeSlot)
                .Include(r => r.AssignedTeacher)
                .Where(r => r.StudentId == userId && r.DeletedAt == null)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            var ongoingStatuses = new[] { "Confirmed", "Waiting for Teacher Approval", "Teacher Assigned", "Waiting for Admin Approval" };

            ClientTransactionDto Map(TutoringRequest r) => new ClientTransactionDto
            {
                Id = r.Id,
                SubjectName = r.Subject?.Name ?? "—",
                BuildingName = r.Building?.Name ?? "—",
                Status = r.Status,
                Priority = r.Priority,
                IsAdminCreated = r.IsAdminCreated,
                CreatedAt = r.CreatedAt,
                AssignedTeacherName = r.AssignedTeacher != null
                    ? $"{r.AssignedTeacher.FirstName} {r.AssignedTeacher.LastName}" : null,
                RoomName = r.Room?.Name,
                DayName = r.AvailableDay?.DayName,
                TimeSlotLabel = r.AvailableTimeSlot != null
                    ? $"{r.AvailableTimeSlot.StartTime} – {r.AvailableTimeSlot.EndTime}" : null,
            };

            return new ClientDetailDto
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                Roles = string.Join(", ", user.UserRoles.Select(ur => ur.Role.Name)),
                CreatedAt = user.CreatedAt,
                Transactions = requests.Select(Map).ToList(),
                OngoingSessions = requests.Where(r => ongoingStatuses.Contains(r.Status)).Select(Map).ToList(),
            };
        }
    }
}
