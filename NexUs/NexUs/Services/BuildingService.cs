using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Buildings;
using NexUs.Models.DTO.Common;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAuditService _auditService;
        private readonly IAddressService _addressService;
        private readonly ILocationService _locationService;

        public BuildingService(
            ApplicationDbContext context,
            IMapper mapper,
            IAuditService auditService,
            IAddressService addressService,
            ILocationService locationService)
        {
            _context = context;
            _mapper = mapper;
            _auditService = auditService;
            _addressService = addressService;
            _locationService = locationService;
        }

        public async Task<PagedResultDto<BuildingListDto>> GetAllBuildingsAsync(PaginationDto pagination)
        {
            var query = _context.Buildings
                .Include(b => b.Manager)
                .Include(b => b.Address)
                .Where(b => b.DeletedAt == null)
                .AsQueryable();

            // Search by name
            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(b => b.Name.ToLower().Contains(searchLower));
            }

            var totalCount = await query.CountAsync();

            // Sorting
            query = (pagination.SortBy?.ToLower(), pagination.SortDescending) switch
            {
                ("name", true) => query.OrderByDescending(b => b.Name),
                ("name", false) => query.OrderBy(b => b.Name),
                ("createdat", true) => query.OrderByDescending(b => b.CreatedAt),
                ("createdat", false) => query.OrderBy(b => b.CreatedAt),
                ("updatedat", true) => query.OrderByDescending(b => b.UpdatedAt),
                ("updatedat", false) => query.OrderBy(b => b.UpdatedAt),
                _ => query.OrderByDescending(b => b.CreatedAt)
            };

            var buildings = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var items = buildings.Select(b => new BuildingListDto
            {
                Id = b.Id,
                Name = b.Name,
                IsActive = b.IsActive,
                ManagerName = b.Manager != null ? $"{b.Manager.FirstName} {b.Manager.LastName}" : null,
                AddressLine = b.Address != null ? $"{b.Address.StreetBarangay}, {_locationService.ResolveCityName(b.Address.CityMunicipality ?? "")}" : null,
                CityMunicipality = b.Address?.CityMunicipality,
                Province = b.Address?.Province,
                Region = b.Address?.Region,
                CreatedAt = b.CreatedAt,
                UpdatedAt = b.UpdatedAt
            }).ToList();

            return new PagedResultDto<BuildingListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<BuildingListDto?> GetMyBuildingAsync(int userId)
        {
            var building = await _context.Buildings
                .Include(b => b.Manager)
                .Include(b => b.Address)
                .Where(b => b.ManagedBy == userId && b.DeletedAt == null)
                .FirstOrDefaultAsync();

            if (building == null) return null;

            return new BuildingListDto
            {
                Id = building.Id,
                Name = building.Name,
                IsActive = building.IsActive,
                ManagerName = building.Manager != null ? $"{building.Manager.FirstName} {building.Manager.LastName}" : null,
                AddressLine = building.Address != null
                    ? $"{building.Address.StreetBarangay}, {_locationService.ResolveCityName(building.Address.CityMunicipality ?? "")}"
                    : null,
                CityMunicipality = building.Address?.CityMunicipality,
                Province = building.Address?.Province,
                Region = building.Address?.Region,
                CreatedAt = building.CreatedAt,
                UpdatedAt = building.UpdatedAt
            };
        }

        public async Task<BuildingListDto?> GetRecommendedBuildingAsync(string cityCode, string provinceCode, string regionCode, int? preferredBuildingId = null)
        {
            if (string.IsNullOrEmpty(cityCode) && string.IsNullOrEmpty(provinceCode) && string.IsNullOrEmpty(regionCode) && !preferredBuildingId.HasValue)
                return null;

            var buildings = await _context.Buildings
                .Include(b => b.Address)
                .Where(b => b.IsActive && b.DeletedAt == null)
                .ToListAsync();

            // Resolve the user's address to human-readable names.
            // LocationService.Resolve*Name returns the input unchanged when it is already a name,
            // so this handles both stored PSGC codes and stored text names uniformly.
            var userCity = _locationService.ResolveCityName(cityCode).ToLower();
            var userProvince = _locationService.ResolveProvinceName(provinceCode).ToLower();
            var userRegion = _locationService.ResolveRegionName(regionCode).ToLower();

            Building? best = null;
            int bestScore = 0;

            foreach (var b in buildings)
            {
                if (b.Address == null) continue;

                var bCity = _locationService.ResolveCityName(b.Address.CityMunicipality ?? "").ToLower();
                var bProvince = _locationService.ResolveProvinceName(b.Address.Province ?? "").ToLower();
                var bRegion = _locationService.ResolveRegionName(b.Address.Region ?? "").ToLower();

                int score = 0;
                if (!string.IsNullOrEmpty(bCity) && !string.IsNullOrEmpty(userCity) && bCity == userCity)
                    score = 3;
                else if (!string.IsNullOrEmpty(bProvince) && !string.IsNullOrEmpty(userProvince) && bProvince == userProvince)
                    score = 2;
                else if (!string.IsNullOrEmpty(bRegion) && !string.IsNullOrEmpty(userRegion) && bRegion == userRegion)
                    score = 1;

                if (score > bestScore)
                {
                    bestScore = score;
                    best = b;
                }
            }

            if ((best == null || bestScore == 0) && preferredBuildingId.HasValue)
            {
                // No address-based match — fall back to the user's previously assigned building
                best = await _context.Buildings
                    .Include(b => b.Address)
                    .Where(b => b.Id == preferredBuildingId.Value && b.IsActive && b.DeletedAt == null)
                    .FirstOrDefaultAsync();
            }

            if (best == null) return null;

            return new BuildingListDto
            {
                Id = best.Id,
                Name = best.Name,
                IsActive = best.IsActive,
                AddressLine = best.Address != null
                    ? $"{best.Address.StreetBarangay}, {_locationService.ResolveCityName(best.Address.CityMunicipality ?? "")}"
                    : null,
                CityMunicipality = best.Address?.CityMunicipality,
                Province = best.Address?.Province,
                Region = best.Address?.Region,
                CreatedAt = best.CreatedAt,
                UpdatedAt = best.UpdatedAt,
            };
        }

        public async Task<BuildingResponseDto?> GetBuildingByIdAsync(int id)
        {
            var building = await _context.Buildings
                .IgnoreQueryFilters()
                .Include(b => b.Manager)
                .Include(b => b.Address)
                .Include(b => b.CreatedByUser)
                .Include(b => b.UpdatedByUser)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (building == null) return null;

            return new BuildingResponseDto
            {
                Id = building.Id,
                Name = building.Name,
                IsActive = building.IsActive,
                ManagedBy = building.ManagedBy,
                ManagerName = building.Manager != null ? $"{building.Manager.FirstName} {building.Manager.LastName}" : null,
                AddressId = building.AddressId,
                Address = building.Address != null ? new AddressDto
                {
                    Id = building.Address.Id,
                    StreetBarangay = building.Address.StreetBarangay,
                    Region = building.Address.Region,
                    Province = building.Address.Province,
                    CityMunicipality = building.Address.CityMunicipality,
                    Postal = building.Address.Postal
                } : null,
                CreatedAt = building.CreatedAt,
                UpdatedAt = building.UpdatedAt,
                DeletedAt = building.DeletedAt,
                CreatedBy = building.CreatedBy,
                UpdatedBy = building.UpdatedBy,
                CreatedByName = building.CreatedByUser != null
                    ? $"{building.CreatedByUser.FirstName} {building.CreatedByUser.LastName}".Trim()
                    : null,
                UpdatedByName = building.UpdatedByUser != null
                    ? $"{building.UpdatedByUser.FirstName} {building.UpdatedByUser.LastName}".Trim()
                    : null
            };
        }

        public async Task<PagedResultDto<BuildingListDto>> GetArchivedBuildingsAsync(PaginationDto pagination)
        {
            var query = _context.Buildings
                .IgnoreQueryFilters()
                .Include(b => b.Manager)
                .Include(b => b.Address)
                .Where(b => b.DeletedAt != null)
                .AsQueryable();

            // Search by name
            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(b => b.Name.ToLower().Contains(searchLower));
            }

            var totalCount = await query.CountAsync();

            var buildings = await query
                .OrderByDescending(b => b.DeletedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var items = buildings.Select(b => new BuildingListDto
            {
                Id = b.Id,
                Name = b.Name,
                IsActive = b.IsActive,
                ManagerName = b.Manager != null ? $"{b.Manager.FirstName} {b.Manager.LastName}" : null,
                AddressLine = b.Address != null ? $"{b.Address.StreetBarangay}, {_locationService.ResolveCityName(b.Address.CityMunicipality ?? "")}" : null,
                CityMunicipality = b.Address?.CityMunicipality,
                Province = b.Address?.Province,
                Region = b.Address?.Region,
                CreatedAt = b.CreatedAt,
                UpdatedAt = b.UpdatedAt
            }).ToList();

            return new PagedResultDto<BuildingListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<List<AvailableManagerDto>> GetAvailableManagersAsync(int? excludeBuildingId)
        {
            // Get all user IDs that are already managing an active building
            var assignedManagerIds = await _context.Buildings
                .Where(b => b.DeletedAt == null && b.ManagedBy != null)
                .Where(b => excludeBuildingId == null || b.Id != excludeBuildingId)
                .Select(b => b.ManagedBy!.Value)
                .ToListAsync();

            // Get the "Building Manager" role
            var bmRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Building Manager");
            if (bmRole == null) return new List<AvailableManagerDto>();

            // Get users with that role who are NOT already assigned
            var availableManagers = await _context.Users
                .Where(u => u.DeletedAt == null)
                .Where(u => u.UserRoles.Any(ur => ur.RoleId == bmRole.Id))
                .Where(u => !assignedManagerIds.Contains(u.Id))
                .OrderBy(u => u.FirstName)
                .Select(u => new AvailableManagerDto
                {
                    Id = u.Id,
                    FullName = u.FirstName + " " + u.LastName
                })
                .ToListAsync();

            return availableManagers;
        }

        public async Task<BuildingResponseDto> CreateBuildingAsync(CreateBuildingDto dto, int? currentUserId)
        {
            // Check for duplicate name
            var existingBuilding = await _context.Buildings
                .FirstOrDefaultAsync(b => b.Name.ToLower() == dto.Name.ToLower() && b.DeletedAt == null);
            
            if (existingBuilding != null)
            {
                throw new InvalidOperationException($"A building with the name '{dto.Name}' already exists.");
            }

            // Check if the manager is already assigned to another active building
            if (dto.ManagedBy.HasValue)
            {
                var managerAlreadyAssigned = await _context.Buildings
                    .AnyAsync(b => b.ManagedBy == dto.ManagedBy.Value && b.DeletedAt == null);

                if (managerAlreadyAssigned)
                {
                    throw new InvalidOperationException("This user is already managing another building. Each building manager can only manage one building.");
                }
            }

            var building = new Building
            {
                Name = dto.Name,
                IsActive = dto.IsActive,
                ManagedBy = dto.ManagedBy,
                CreatedBy = currentUserId,
                UpdatedBy = currentUserId
            };

            // Create address if provided
            if (dto.Address != null)
            {
                var addressId = await _addressService.CreateAddressAsync(dto.Address);
                building.AddressId = addressId;
            }

            _context.Buildings.Add(building);
            await _context.SaveChangesAsync();

            var createDetails = $"Created building: {building.Name} -> IsActive: {building.IsActive}";
            await _auditService.LogAsync("Buildings", "Create", createDetails, currentUserId);

            return (await GetBuildingByIdAsync(building.Id))!;
        }

        public async Task<BuildingResponseDto?> UpdateBuildingAsync(int id, UpdateBuildingDto dto, int? currentUserId)
        {
            var building = await _context.Buildings
                .Include(b => b.Address)
                .FirstOrDefaultAsync(b => b.Id == id && b.DeletedAt == null);

            if (building == null) return null;

            var changes = new List<string>();
            var originalName = building.Name;

            // Check for duplicate name if name is being changed
            if (!string.IsNullOrEmpty(dto.Name) && dto.Name.ToLower() != building.Name.ToLower())
            {
                var existingBuilding = await _context.Buildings
                    .FirstOrDefaultAsync(b => b.Name.ToLower() == dto.Name.ToLower() && b.Id != id && b.DeletedAt == null);
                
                if (existingBuilding != null)
                {
                    throw new InvalidOperationException($"A building with the name '{dto.Name}' already exists.");
                }

                changes.Add($"Name: {building.Name} → {dto.Name}");
                building.Name = dto.Name;
            }

            if (dto.IsActive.HasValue && dto.IsActive.Value != building.IsActive)
            {
                changes.Add($"IsActive: {building.IsActive} → {dto.IsActive.Value}");
                building.IsActive = dto.IsActive.Value;
            }

            if (dto.ManagedBy.HasValue && dto.ManagedBy.Value != building.ManagedBy)
            {
                // Check if the new manager is already assigned to another active building
                var managerAlreadyAssigned = await _context.Buildings
                    .AnyAsync(b => b.ManagedBy == dto.ManagedBy.Value && b.Id != id && b.DeletedAt == null);

                if (managerAlreadyAssigned)
                {
                    throw new InvalidOperationException("This user is already managing another building. Each building manager can only manage one building.");
                }

                changes.Add($"ManagedBy: {building.ManagedBy} → {dto.ManagedBy.Value}");
                building.ManagedBy = dto.ManagedBy.Value;
            }

            // Handle address update
            if (dto.Address != null)
            {
                var addressId = await _addressService.CreateAddressAsync(dto.Address);
                if (building.AddressId != addressId)
                {
                    changes.Add($"AddressId: {building.AddressId} → {addressId}");
                    building.AddressId = addressId;
                }
            }
            else if (dto.AddressId.HasValue && dto.AddressId.Value != building.AddressId)
            {
                changes.Add($"AddressId: {building.AddressId} → {dto.AddressId.Value}");
                building.AddressId = dto.AddressId.Value;
            }

            building.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();

            var updateDetails = changes.Any()
                ? $"Updated building: {originalName} -> {string.Join(", ", changes)}"
                : $"Updated building: {originalName} (no changes detected)";
            await _auditService.LogAsync("Buildings", "Update", updateDetails, currentUserId);

            return await GetBuildingByIdAsync(building.Id);
        }

        public async Task<bool> DeleteBuildingAsync(int id, int? currentUserId)
        {
            var building = await _context.Buildings
                .FirstOrDefaultAsync(b => b.Id == id && b.DeletedAt == null);

            if (building == null) return false;

            building.IsActive = false;
            building.DeletedAt = DateTime.UtcNow;
            building.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var deleteDetails = $"Soft deleted building: {building.Name}";
            await _auditService.LogAsync("Buildings", "Delete", deleteDetails, currentUserId);

            return true;
        }

        public async Task<bool> RestoreBuildingAsync(int id, int? currentUserId)
        {
            var building = await _context.Buildings.IgnoreQueryFilters()
                .FirstOrDefaultAsync(b => b.Id == id && b.DeletedAt != null);

            if (building == null) return false;

            building.IsActive = true;
            building.DeletedAt = null;
            building.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var restoreDetails = $"Restored building: {building.Name}";
            await _auditService.LogAsync("Buildings", "Restore", restoreDetails, currentUserId);

            return true;
        }

        public async Task<bool> PermanentDeleteBuildingAsync(int id, int? currentUserId)
        {
            var building = await _context.Buildings.IgnoreQueryFilters()
                .FirstOrDefaultAsync(b => b.Id == id && b.DeletedAt != null);

            if (building == null) return false;

            var buildingName = building.Name;

            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync();

            var permanentDeleteDetails = $"Permanently deleted building: {buildingName}";
            await _auditService.LogAsync("Buildings", "PermanentDelete", permanentDeleteDetails, currentUserId);

            return true;
        }
    }
}
