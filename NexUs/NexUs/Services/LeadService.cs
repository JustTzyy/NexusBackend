using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Models.DTO.Notifications;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;
using NexUs.Utilities;

namespace NexUs.Services
{
    public class LeadService : ILeadService
    {
        private readonly ApplicationDbContext _context;
        private readonly INotificationService _notificationService;

        public LeadService(ApplicationDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        private static LeadListDto ToDto(Lead l) => new()
        {
            Id = l.Id,
            UserId = l.UserId,
            Email = l.Email,
            FirstName = l.FirstName,
            LastName = l.LastName,
            Phone = l.Phone,
            Source = l.Source,
            Status = l.Status,
            ConvertedAt = l.ConvertedAt,
            Notes = l.Notes,
            CreatedAt = l.CreatedAt,
            UpdatedAt = l.UpdatedAt,
            CreatedByName = l.CreatedByUser != null ? $"{l.CreatedByUser.FirstName} {l.CreatedByUser.LastName}".Trim() : null,
            UpdatedByName = l.UpdatedByUser != null ? $"{l.UpdatedByUser.FirstName} {l.UpdatedByUser.LastName}".Trim() : null
        };

        public async Task<PagedResultDto<LeadListDto>> GetAllAsync(PaginationDto pagination, string? statusFilter = null)
        {
            var query = _context.Leads
                .Where(l => l.DeletedAt == null)
                .Include(l => l.CreatedByUser)
                .Include(l => l.UpdatedByUser)
                .AsQueryable();

            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "all")
                query = query.Where(l => l.Status == statusFilter);

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var term = pagination.SearchTerm.ToLower();
                query = query.Where(l => l.Email.ToLower().Contains(term) ||
                                         l.FirstName.ToLower().Contains(term) ||
                                         l.LastName.ToLower().Contains(term));
            }

            var totalCount = await query.CountAsync();
            query = query.OrderByDescending(l => l.CreatedAt);

            var items = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PagedResultDto<LeadListDto>
            {
                Items = items.Select(ToDto).ToList(),
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<PagedResultDto<LeadListDto>> GetArchivedAsync(PaginationDto pagination)
        {
            var query = _context.Leads
                .Where(l => l.DeletedAt != null)
                .Include(l => l.CreatedByUser)
                .Include(l => l.UpdatedByUser)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var term = pagination.SearchTerm.ToLower();
                query = query.Where(l => l.Email.ToLower().Contains(term) || l.FirstName.ToLower().Contains(term) || l.LastName.ToLower().Contains(term));
            }

            var totalCount = await query.CountAsync();
            query = query.OrderByDescending(l => l.DeletedAt);

            var items = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PagedResultDto<LeadListDto> { Items = items.Select(ToDto).ToList(), TotalCount = totalCount, PageNumber = pagination.PageNumber, PageSize = pagination.PageSize };
        }

        public async Task<LeadResponseDto?> GetByIdAsync(int id)
        {
            var l = await _context.Leads.Include(x => x.CreatedByUser).Include(x => x.UpdatedByUser)
                .FirstOrDefaultAsync(x => x.Id == id && x.DeletedAt == null);
            if (l == null) return null;
            var dto = ToDto(l);
            return new LeadResponseDto { Id = dto.Id, UserId = dto.UserId, Email = dto.Email, FirstName = dto.FirstName, LastName = dto.LastName, Phone = dto.Phone, Source = dto.Source, Status = dto.Status, ConvertedAt = dto.ConvertedAt, Notes = dto.Notes, CreatedAt = dto.CreatedAt, UpdatedAt = dto.UpdatedAt, CreatedByName = dto.CreatedByName, UpdatedByName = dto.UpdatedByName };
        }

        public async Task<LeadResponseDto> CreateAsync(CreateLeadDto dto, int? currentUserId)
        {
            var entity = new Lead
            {
                Email = dto.Email.ToLower(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Phone = dto.Phone,
                Source = dto.Source,
                Status = dto.Status,
                Notes = dto.Notes,
                CreatedBy = currentUserId,
                UpdatedBy = currentUserId
            };
            _context.Leads.Add(entity);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(entity.Id) ?? throw new Exception("Failed to load lead.");
        }

        public async Task<LeadResponseDto?> UpdateAsync(int id, UpdateLeadDto dto, int? currentUserId)
        {
            var entity = await _context.Leads.FindAsync(id);
            if (entity == null || entity.DeletedAt != null) return null;

            entity.Email = dto.Email.ToLower();
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.Phone = dto.Phone;
            entity.Source = dto.Source;
            entity.Status = dto.Status;
            entity.Notes = dto.Notes;
            entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();
            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id, int? currentUserId)
        {
            var entity = await _context.Leads.FindAsync(id);
            if (entity == null || entity.DeletedAt != null) return false;
            entity.DeletedAt = DateTimeHelper.PhilippineNow;
            entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RestoreAsync(int id, int? currentUserId)
        {
            var entity = await _context.Leads.FindAsync(id);
            if (entity == null || entity.DeletedAt == null) return false;
            entity.DeletedAt = null;
            entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PermanentDeleteAsync(int id)
        {
            var entity = await _context.Leads.FindAsync(id);
            if (entity == null) return false;
            _context.Leads.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<LeadResponseDto?> CreateFromUserAsync(int userId, string email, string firstName, string lastName, string source = "Registration")
        {
            // Idempotent — skip if already linked to this user
            var existingByUser = await _context.Leads.FirstOrDefaultAsync(l => l.UserId == userId && l.DeletedAt == null);
            if (existingByUser != null) return null;

            // Also skip if email already suppressed
            var emailSuppressed = await _context.Suppressions.AnyAsync(s => s.Email.ToLower() == email.ToLower() && s.DeletedAt == null);
            if (emailSuppressed) return null;

            // If a manually-created lead already exists with this email, link it instead of creating a duplicate
            var existingByEmail = await _context.Leads.FirstOrDefaultAsync(l => l.Email.ToLower() == email.ToLower() && l.UserId == null && l.DeletedAt == null);
            if (existingByEmail != null)
            {
                existingByEmail.UserId = userId;
                existingByEmail.Source = source;
                await _context.SaveChangesAsync();
                return await GetByIdAsync(existingByEmail.Id);
            }

            var entity = new Lead
            {
                UserId = userId,
                Email = email.ToLower(),
                FirstName = firstName,
                LastName = lastName,
                Source = source,
                Status = "New"
            };
            _context.Leads.Add(entity);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(entity.Id);
        }

        public async Task<bool> MarkConvertedAsync(int userId)
        {
            var lead = await _context.Leads.FirstOrDefaultAsync(l => l.UserId == userId && l.DeletedAt == null);
            if (lead == null) return false;
            lead.Status = "Converted";
            lead.ConvertedAt = DateTimeHelper.PhilippineNow;
            await _context.SaveChangesAsync();

            // Notify Marketing Staff: lead converted
            await _notificationService.CreateAsync(new CreateNotificationDto
            {
                RecipientRole = "Marketing Staff",
                Title = "Lead Converted",
                Message = $"Lead \"{lead.FirstName} {lead.LastName}\" has been converted to a customer.",
                Type = "Marketing",
                Priority = "Normal",
                ReferenceId = lead.Id,
                ReferenceType = "Lead"
            });

            return true;
        }
    }
}
