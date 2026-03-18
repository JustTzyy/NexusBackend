using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.SessionLogs;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class SessionLogService : ISessionLogService
    {
        private readonly ApplicationDbContext _context;

        public SessionLogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SessionLogResponseDto>> GetByTutoringRequestAsync(int tutoringRequestId)
        {
            return await _context.SessionLogs
                .Include(s => s.TutoringRequest)
                    .ThenInclude(t => t.Subject)
                .Include(s => s.CreatedByUser)
                .Where(s => s.TutoringRequestId == tutoringRequestId && s.DeletedAt == null)
                .OrderByDescending(s => s.SessionDate)
                .Select(s => new SessionLogResponseDto
                {
                    Id = s.Id,
                    TutoringRequestId = s.TutoringRequestId,
                    SubjectName = s.TutoringRequest.Subject != null ? s.TutoringRequest.Subject.Name : null,
                    SessionDate = s.SessionDate,
                    Outcome = s.Outcome,
                    AbsentParty = s.AbsentParty,
                    Notes = s.Notes,
                    CreatedAt = s.CreatedAt,
                    CreatedByName = s.CreatedByUser != null
                        ? $"{s.CreatedByUser.FirstName} {s.CreatedByUser.LastName}" : null,
                })
                .ToListAsync();
        }

        public async Task<SessionLogResponseDto?> GetByIdAsync(int id)
        {
            var s = await _context.SessionLogs
                .Include(s => s.TutoringRequest)
                    .ThenInclude(t => t.Subject)
                .Include(s => s.CreatedByUser)
                .FirstOrDefaultAsync(s => s.Id == id && s.DeletedAt == null);

            if (s == null) return null;

            return new SessionLogResponseDto
            {
                Id = s.Id,
                TutoringRequestId = s.TutoringRequestId,
                SubjectName = s.TutoringRequest.Subject?.Name,
                SessionDate = s.SessionDate,
                Outcome = s.Outcome,
                AbsentParty = s.AbsentParty,
                Notes = s.Notes,
                CreatedAt = s.CreatedAt,
                CreatedByName = s.CreatedByUser != null
                    ? $"{s.CreatedByUser.FirstName} {s.CreatedByUser.LastName}" : null,
            };
        }

        public async Task<PagedResultDto<SessionLogResponseDto>> GetAllAsync(PaginationDto pagination)
        {
            var query = _context.SessionLogs
                .Include(s => s.TutoringRequest)
                    .ThenInclude(t => t.Subject)
                .Include(s => s.CreatedByUser)
                .Where(s => s.DeletedAt == null && s.TutoringRequest.DeletedAt == null)
                .AsQueryable();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(s => s.SessionDate)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(s => new SessionLogResponseDto
                {
                    Id = s.Id,
                    TutoringRequestId = s.TutoringRequestId,
                    SubjectName = s.TutoringRequest.Subject != null ? s.TutoringRequest.Subject.Name : null,
                    SessionDate = s.SessionDate,
                    Outcome = s.Outcome,
                    AbsentParty = s.AbsentParty,
                    Notes = s.Notes,
                    CreatedAt = s.CreatedAt,
                    CreatedByName = s.CreatedByUser != null
                        ? $"{s.CreatedByUser.FirstName} {s.CreatedByUser.LastName}" : null,
                })
                .ToListAsync();

            return new PagedResultDto<SessionLogResponseDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<SessionLogResponseDto> CreateAsync(CreateSessionLogDto dto, int? userId)
        {
            // Check for duplicate log for same request + date (date only, ignore time)
            var sessionDateOnly = dto.SessionDate.Date;
            var duplicate = await _context.SessionLogs
                .AnyAsync(s => s.TutoringRequestId == dto.TutoringRequestId
                    && s.SessionDate.Date == sessionDateOnly
                    && s.DeletedAt == null);

            if (duplicate)
                throw new InvalidOperationException("A session log for this tutoring request on this date already exists.");

            var log = new SessionLog
            {
                TutoringRequestId = dto.TutoringRequestId,
                SessionDate = dto.SessionDate,
                Outcome = dto.Outcome,
                AbsentParty = dto.AbsentParty,
                Notes = dto.Notes,
                CreatedBy = userId,
                UpdatedBy = userId,
            };

            _context.SessionLogs.Add(log);
            await _context.SaveChangesAsync();

            // Reload with includes for the response
            var created = await _context.SessionLogs
                .Include(s => s.TutoringRequest)
                    .ThenInclude(t => t.Subject)
                .Include(s => s.CreatedByUser)
                .FirstAsync(s => s.Id == log.Id);

            return new SessionLogResponseDto
            {
                Id = created.Id,
                TutoringRequestId = created.TutoringRequestId,
                SubjectName = created.TutoringRequest.Subject?.Name,
                SessionDate = created.SessionDate,
                Outcome = created.Outcome,
                AbsentParty = created.AbsentParty,
                Notes = created.Notes,
                CreatedAt = created.CreatedAt,
                CreatedByName = created.CreatedByUser != null
                    ? $"{created.CreatedByUser.FirstName} {created.CreatedByUser.LastName}" : null,
            };
        }

        public async Task<SessionLogResponseDto?> UpdateAsync(int id, UpdateSessionLogDto dto, int? userId)
        {
            var log = await _context.SessionLogs
                .FirstOrDefaultAsync(s => s.Id == id && s.DeletedAt == null);

            if (log == null) return null;

            if (dto.Outcome != null) log.Outcome = dto.Outcome;
            if (dto.AbsentParty != null) log.AbsentParty = dto.AbsentParty;
            if (dto.Notes != null) log.Notes = dto.Notes;
            log.UpdatedBy = userId;

            await _context.SaveChangesAsync();

            var updated = await _context.SessionLogs
                .Include(s => s.TutoringRequest)
                    .ThenInclude(t => t.Subject)
                .Include(s => s.CreatedByUser)
                .FirstAsync(s => s.Id == id);

            return new SessionLogResponseDto
            {
                Id = updated.Id,
                TutoringRequestId = updated.TutoringRequestId,
                SubjectName = updated.TutoringRequest.Subject?.Name,
                SessionDate = updated.SessionDate,
                Outcome = updated.Outcome,
                AbsentParty = updated.AbsentParty,
                Notes = updated.Notes,
                CreatedAt = updated.CreatedAt,
                CreatedByName = updated.CreatedByUser != null
                    ? $"{updated.CreatedByUser.FirstName} {updated.CreatedByUser.LastName}" : null,
            };
        }

        public async Task<bool> DeleteAsync(int id, int? userId)
        {
            var log = await _context.SessionLogs
                .FirstOrDefaultAsync(s => s.Id == id && s.DeletedAt == null);

            if (log == null) return false;

            log.DeletedAt = DateTime.UtcNow;
            log.UpdatedBy = userId;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
