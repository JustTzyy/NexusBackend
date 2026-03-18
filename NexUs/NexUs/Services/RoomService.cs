using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Rooms;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuditService _auditService;

        public RoomService(
            ApplicationDbContext context,
            IAuditService auditService)
        {
            _context = context;
            _auditService = auditService;
        }

        public async Task<PagedResultDto<RoomListDto>> GetAllRoomsAsync(PaginationDto pagination)
        {
            var query = _context.Rooms
                .Include(r => r.Building)
                .Where(r => r.DeletedAt == null)
                .AsQueryable();

            // Search by name or building name
            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(r =>
                    r.Name.ToLower().Contains(searchLower) ||
                    r.Building.Name.ToLower().Contains(searchLower));
            }

            var totalCount = await query.CountAsync();

            // Sorting
            query = (pagination.SortBy?.ToLower(), pagination.SortDescending) switch
            {
                ("name", true) => query.OrderByDescending(r => r.Name),
                ("name", false) => query.OrderBy(r => r.Name),
                ("capacity", true) => query.OrderByDescending(r => r.Capacity),
                ("capacity", false) => query.OrderBy(r => r.Capacity),
                ("buildingname", true) => query.OrderByDescending(r => r.Building.Name),
                ("buildingname", false) => query.OrderBy(r => r.Building.Name),
                ("createdat", true) => query.OrderByDescending(r => r.CreatedAt),
                ("createdat", false) => query.OrderBy(r => r.CreatedAt),
                ("updatedat", true) => query.OrderByDescending(r => r.UpdatedAt),
                ("updatedat", false) => query.OrderBy(r => r.UpdatedAt),
                _ => query.OrderByDescending(r => r.CreatedAt)
            };

            var rooms = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var items = rooms.Select(r => new RoomListDto
            {
                Id = r.Id,
                Name = r.Name,
                Capacity = r.Capacity,
                IsActive = r.IsActive,
                BuildingId = r.BuildingId,
                BuildingName = r.Building.Name,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt
            }).ToList();

            return new PagedResultDto<RoomListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<RoomResponseDto?> GetRoomByIdAsync(int id)
        {
            var room = await _context.Rooms
                .IgnoreQueryFilters()
                .Include(r => r.Building)
                .Include(r => r.CreatedByUser)
                .Include(r => r.UpdatedByUser)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (room == null) return null;

            return new RoomResponseDto
            {
                Id = room.Id,
                Name = room.Name,
                Capacity = room.Capacity,
                IsActive = room.IsActive,
                BuildingId = room.BuildingId,
                BuildingName = room.Building.Name,
                CreatedAt = room.CreatedAt,
                UpdatedAt = room.UpdatedAt,
                DeletedAt = room.DeletedAt,
                CreatedBy = room.CreatedBy,
                UpdatedBy = room.UpdatedBy,
                CreatedByName = room.CreatedByUser != null
                    ? $"{room.CreatedByUser.FirstName} {room.CreatedByUser.LastName}".Trim()
                    : null,
                UpdatedByName = room.UpdatedByUser != null
                    ? $"{room.UpdatedByUser.FirstName} {room.UpdatedByUser.LastName}".Trim()
                    : null
            };
        }

        public async Task<PagedResultDto<RoomListDto>> GetArchivedRoomsAsync(PaginationDto pagination)
        {
            var query = _context.Rooms
                .IgnoreQueryFilters()
                .Include(r => r.Building)
                .Where(r => r.DeletedAt != null)
                .AsQueryable();

            // Search by name or building name
            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(r =>
                    r.Name.ToLower().Contains(searchLower) ||
                    r.Building.Name.ToLower().Contains(searchLower));
            }

            var totalCount = await query.CountAsync();

            var rooms = await query
                .OrderByDescending(r => r.DeletedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var items = rooms.Select(r => new RoomListDto
            {
                Id = r.Id,
                Name = r.Name,
                Capacity = r.Capacity,
                IsActive = r.IsActive,
                BuildingId = r.BuildingId,
                BuildingName = r.Building.Name,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt
            }).ToList();

            return new PagedResultDto<RoomListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<RoomResponseDto> CreateRoomAsync(CreateRoomDto dto, int? currentUserId)
        {
            // Validate building exists
            var building = await _context.Buildings
                .FirstOrDefaultAsync(b => b.Id == dto.BuildingId && b.DeletedAt == null);

            if (building == null)
            {
                throw new InvalidOperationException("The specified building does not exist.");
            }

            // Check for duplicate name within the same building
            var existingRoom = await _context.Rooms
                .FirstOrDefaultAsync(r =>
                    r.Name.ToLower() == dto.Name.ToLower() &&
                    r.BuildingId == dto.BuildingId &&
                    r.DeletedAt == null);

            if (existingRoom != null)
            {
                throw new InvalidOperationException($"A room with the name '{dto.Name}' already exists in {building.Name}.");
            }

            var room = new Room
            {
                Name = dto.Name,
                Capacity = dto.Capacity,
                IsActive = dto.IsActive,
                BuildingId = dto.BuildingId,
                CreatedBy = currentUserId,
                UpdatedBy = currentUserId
            };

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            var createDetails = $"Created room: {room.Name} -> Building: {building.Name}, Capacity: {room.Capacity}, IsActive: {room.IsActive}";
            await _auditService.LogAsync("Rooms", "Create", createDetails, currentUserId);

            return (await GetRoomByIdAsync(room.Id))!;
        }

        public async Task<RoomResponseDto?> UpdateRoomAsync(int id, UpdateRoomDto dto, int? currentUserId)
        {
            var room = await _context.Rooms
                .Include(r => r.Building)
                .FirstOrDefaultAsync(r => r.Id == id && r.DeletedAt == null);

            if (room == null) return null;

            var changes = new List<string>();
            var originalName = room.Name;

            // Check for duplicate name if name is being changed
            if (!string.IsNullOrEmpty(dto.Name) && dto.Name.ToLower() != room.Name.ToLower())
            {
                var targetBuildingId = dto.BuildingId ?? room.BuildingId;
                var existingRoom = await _context.Rooms
                    .FirstOrDefaultAsync(r =>
                        r.Name.ToLower() == dto.Name.ToLower() &&
                        r.BuildingId == targetBuildingId &&
                        r.Id != id &&
                        r.DeletedAt == null);

                if (existingRoom != null)
                {
                    throw new InvalidOperationException($"A room with the name '{dto.Name}' already exists in that building.");
                }

                changes.Add($"Name: {room.Name} → {dto.Name}");
                room.Name = dto.Name;
            }

            if (dto.Capacity.HasValue && dto.Capacity.Value != room.Capacity)
            {
                changes.Add($"Capacity: {room.Capacity} → {dto.Capacity.Value}");
                room.Capacity = dto.Capacity.Value;
            }

            if (dto.IsActive.HasValue && dto.IsActive.Value != room.IsActive)
            {
                changes.Add($"IsActive: {room.IsActive} → {dto.IsActive.Value}");
                room.IsActive = dto.IsActive.Value;
            }

            if (dto.BuildingId.HasValue && dto.BuildingId.Value != room.BuildingId)
            {
                // Validate new building exists
                var newBuilding = await _context.Buildings
                    .FirstOrDefaultAsync(b => b.Id == dto.BuildingId.Value && b.DeletedAt == null);

                if (newBuilding == null)
                {
                    throw new InvalidOperationException("The specified building does not exist.");
                }

                changes.Add($"BuildingId: {room.BuildingId} → {dto.BuildingId.Value}");
                room.BuildingId = dto.BuildingId.Value;
            }

            room.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();

            var updateDetails = changes.Any()
                ? $"Updated room: {originalName} -> {string.Join(", ", changes)}"
                : $"Updated room: {originalName} (no changes detected)";
            await _auditService.LogAsync("Rooms", "Update", updateDetails, currentUserId);

            return await GetRoomByIdAsync(room.Id);
        }

        public async Task<bool> DeleteRoomAsync(int id, int? currentUserId)
        {
            var room = await _context.Rooms
                .FirstOrDefaultAsync(r => r.Id == id && r.DeletedAt == null);

            if (room == null) return false;

            room.IsActive = false;
            room.DeletedAt = DateTime.UtcNow;
            room.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var deleteDetails = $"Soft deleted room: {room.Name}";
            await _auditService.LogAsync("Rooms", "Delete", deleteDetails, currentUserId);

            return true;
        }

        public async Task<bool> RestoreRoomAsync(int id, int? currentUserId)
        {
            var room = await _context.Rooms.IgnoreQueryFilters()
                .FirstOrDefaultAsync(r => r.Id == id && r.DeletedAt != null);

            if (room == null) return false;

            room.IsActive = true;
            room.DeletedAt = null;
            room.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var restoreDetails = $"Restored room: {room.Name}";
            await _auditService.LogAsync("Rooms", "Restore", restoreDetails, currentUserId);

            return true;
        }

        public async Task<bool> PermanentDeleteRoomAsync(int id, int? currentUserId)
        {
            var room = await _context.Rooms.IgnoreQueryFilters()
                .FirstOrDefaultAsync(r => r.Id == id && r.DeletedAt != null);

            if (room == null) return false;

            var roomName = room.Name;

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            var permanentDeleteDetails = $"Permanently deleted room: {roomName}";
            await _auditService.LogAsync("Rooms", "PermanentDelete", permanentDeleteDetails, currentUserId);

            return true;
        }
    }
}
