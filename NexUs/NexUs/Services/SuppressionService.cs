using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;
using NexUs.Utilities;

namespace NexUs.Services
{
    public class SuppressionService : ISuppressionService
    {
        private readonly ApplicationDbContext _context;

        public SuppressionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<SuppressionListDto>> GetAllAsync(PaginationDto pagination)
        {
            var query = _context.Suppressions
                .Where(s => s.DeletedAt == null)
                .Include(s => s.CreatedByUser)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var term = pagination.SearchTerm.ToLower();
                query = query.Where(s => s.Email.ToLower().Contains(term) ||
                                         s.Reason.ToLower().Contains(term));
            }

            var totalCount = await query.CountAsync();
            query = query.OrderByDescending(s => s.CreatedAt);

            var items = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(s => new SuppressionListDto
                {
                    Id = s.Id,
                    Email = s.Email,
                    Reason = s.Reason,
                    Source = s.Source,
                    Notes = s.Notes,
                    CreatedAt = s.CreatedAt,
                    CreatedByName = s.CreatedByUser != null
                        ? $"{s.CreatedByUser.FirstName} {s.CreatedByUser.LastName}".Trim()
                        : null
                })
                .ToListAsync();

            return new PagedResultDto<SuppressionListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<SuppressionListDto?> GetByIdAsync(int id)
        {
            var s = await _context.Suppressions
                .Include(s => s.CreatedByUser)
                .FirstOrDefaultAsync(s => s.Id == id && s.DeletedAt == null);

            if (s == null) return null;

            return new SuppressionListDto
            {
                Id = s.Id,
                Email = s.Email,
                Reason = s.Reason,
                Source = s.Source,
                Notes = s.Notes,
                CreatedAt = s.CreatedAt,
                CreatedByName = s.CreatedByUser != null
                    ? $"{s.CreatedByUser.FirstName} {s.CreatedByUser.LastName}".Trim()
                    : null
            };
        }

        public async Task<bool> IsSuppressedAsync(string email)
        {
            return await _context.Suppressions
                .AnyAsync(s => s.Email.ToLower() == email.ToLower() && s.DeletedAt == null);
        }

        public async Task EnsureSuppressedAsync(string email, string reason, string source, string? notes = null, int? currentUserId = null)
        {
            var existing = await _context.Suppressions
                .FirstOrDefaultAsync(s => s.Email.ToLower() == email.ToLower());

            if (existing == null)
            {
                var suppression = new Suppression
                {
                    Email = email.ToLower(),
                    Reason = reason,
                    Source = source,
                    Notes = notes,
                    CreatedBy = currentUserId,
                    UpdatedBy = currentUserId
                };
                _context.Suppressions.Add(suppression);
            }
            else if (existing.DeletedAt != null)
            {
                existing.DeletedAt = null;
                existing.Reason = reason;
                existing.Source = source;
                existing.Notes = notes;
                existing.UpdatedBy = currentUserId;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<SuppressionListDto> CreateAsync(CreateSuppressionDto dto, int? currentUserId)
        {
            var existing = await _context.Suppressions
                .FirstOrDefaultAsync(s => s.Email.ToLower() == dto.Email.ToLower());

            if (existing != null && existing.DeletedAt == null)
                throw new InvalidOperationException($"Email '{dto.Email}' is already suppressed.");

            if (existing != null)
            {
                existing.DeletedAt = null;
                existing.Reason = dto.Reason;
                existing.Source = dto.Source;
                existing.Notes = dto.Notes;
                existing.UpdatedBy = currentUserId;
                await _context.SaveChangesAsync();
                return new SuppressionListDto { Id = existing.Id, Email = existing.Email, Reason = existing.Reason, Source = existing.Source, Notes = existing.Notes, CreatedAt = existing.CreatedAt };
            }

            var suppression = new Suppression
            {
                Email = dto.Email.ToLower(),
                Reason = dto.Reason,
                Source = dto.Source,
                Notes = dto.Notes,
                CreatedBy = currentUserId,
                UpdatedBy = currentUserId
            };
            _context.Suppressions.Add(suppression);
            await _context.SaveChangesAsync();

            return new SuppressionListDto { Id = suppression.Id, Email = suppression.Email, Reason = suppression.Reason, Source = suppression.Source, Notes = suppression.Notes, CreatedAt = suppression.CreatedAt };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var suppression = await _context.Suppressions.FindAsync(id);
            if (suppression == null) return false;
            _context.Suppressions.Remove(suppression);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
