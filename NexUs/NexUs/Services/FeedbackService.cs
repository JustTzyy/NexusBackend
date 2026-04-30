using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Feedbacks;
using NexUs.Models.DTO.Notifications;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;
using NexUs.Utilities;

namespace NexUs.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly ApplicationDbContext _context;
        private readonly INotificationService _notificationService;

        public FeedbackService(ApplicationDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        private IQueryable<Feedback> BaseQuery() => _context.Feedbacks
            .Include(f => f.Customer)
            .Include(f => f.Teacher)
            .Include(f => f.SessionLog)
            .Include(f => f.TutoringRequest)
                .ThenInclude(t => t.Subject);

        private static FeedbackListDto ToListDto(Feedback f) => new()
        {
            Id = f.Id,
            CustomerName = $"{f.Customer.FirstName} {f.Customer.LastName}".Trim(),
            TeacherName = $"{f.Teacher.FirstName} {f.Teacher.LastName}".Trim(),
            SubjectName = f.TutoringRequest.Subject?.Name,
            Rating = f.Rating,
            Comment = f.Comment,
            SessionDate = f.SessionLog.SessionDate,
            CreatedAt = f.CreatedAt,
        };

        private static FeedbackResponseDto ToResponseDto(Feedback f) => new()
        {
            Id = f.Id,
            TutoringRequestId = f.TutoringRequestId,
            SessionLogId = f.SessionLogId,
            CustomerId = f.CustomerId,
            CustomerName = $"{f.Customer.FirstName} {f.Customer.LastName}".Trim(),
            TeacherId = f.TeacherId,
            TeacherName = $"{f.Teacher.FirstName} {f.Teacher.LastName}".Trim(),
            SubjectName = f.TutoringRequest.Subject?.Name,
            Rating = f.Rating,
            Comment = f.Comment,
            SessionDate = f.SessionLog.SessionDate,
            CreatedAt = f.CreatedAt,
            UpdatedAt = f.UpdatedAt,
        };

        public async Task<PagedResultDto<FeedbackListDto>> GetAllAsync(PaginationDto pagination)
        {
            var query = BaseQuery().Where(f => f.DeletedAt == null && f.TutoringRequest.DeletedAt == null);

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var term = pagination.SearchTerm.ToLower();
                query = query.Where(f =>
                    f.Comment != null && f.Comment.ToLower().Contains(term) ||
                    f.Customer.FirstName.ToLower().Contains(term) ||
                    f.Customer.LastName.ToLower().Contains(term) ||
                    f.Teacher.FirstName.ToLower().Contains(term) ||
                    f.Teacher.LastName.ToLower().Contains(term) ||
                    (f.TutoringRequest.Subject != null && f.TutoringRequest.Subject.Name.ToLower().Contains(term)));
            }

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderByDescending(f => f.CreatedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PagedResultDto<FeedbackListDto>
            {
                Items = items.Select(ToListDto).ToList(),
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<PagedResultDto<FeedbackListDto>> GetByCustomerAsync(int customerId, PaginationDto pagination)
        {
            var query = BaseQuery().Where(f => f.DeletedAt == null && f.CustomerId == customerId);

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderByDescending(f => f.CreatedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PagedResultDto<FeedbackListDto>
            {
                Items = items.Select(ToListDto).ToList(),
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<FeedbackResponseDto?> GetByIdAsync(int id, int? requesterId = null, bool isAdmin = false)
        {
            var f = await BaseQuery().FirstOrDefaultAsync(f => f.Id == id && f.DeletedAt == null);
            if (f == null) return null;
            if (requesterId.HasValue && !isAdmin && f.CustomerId != requesterId.Value) return null;
            return ToResponseDto(f);
        }

        public async Task<bool> CanSubmitFeedbackAsync(int customerId, int sessionLogId)
        {
            // Check that the session log exists, is completed, and belongs to customer's tutoring request
            var sessionLog = await _context.SessionLogs
                .Include(sl => sl.TutoringRequest)
                .FirstOrDefaultAsync(sl => sl.Id == sessionLogId && sl.DeletedAt == null);

            if (sessionLog == null) return false;
            if (sessionLog.Outcome != "Completed") return false;
            if (sessionLog.TutoringRequest.StudentId != customerId) return false;

            // Check no duplicate feedback for same session log
            var exists = await _context.Feedbacks
                .AnyAsync(f => f.SessionLogId == sessionLogId && f.CustomerId == customerId && f.DeletedAt == null);

            return !exists;
        }

        public async Task<FeedbackResponseDto> CreateAsync(CreateFeedbackDto dto, int customerId)
        {
            // Validate session log exists and is completed
            var sessionLog = await _context.SessionLogs
                .Include(sl => sl.TutoringRequest)
                    .ThenInclude(t => t.Subject)
                .FirstOrDefaultAsync(sl => sl.Id == dto.SessionLogId && sl.DeletedAt == null);

            if (sessionLog == null)
                throw new InvalidOperationException("Session log not found.");

            if (sessionLog.Outcome != "Completed")
                throw new InvalidOperationException("Feedback can only be submitted for completed sessions.");

            if (sessionLog.TutoringRequestId != dto.TutoringRequestId)
                throw new InvalidOperationException("Session log does not match the tutoring request.");

            var tutoringRequest = sessionLog.TutoringRequest;
            if (tutoringRequest.StudentId != customerId)
                throw new InvalidOperationException("You can only submit feedback for your own sessions.");

            if (!tutoringRequest.AssignedTeacherId.HasValue)
                throw new InvalidOperationException("No teacher assigned to this session.");

            // Check duplicate
            var exists = await _context.Feedbacks
                .AnyAsync(f => f.SessionLogId == dto.SessionLogId && f.CustomerId == customerId && f.DeletedAt == null);
            if (exists)
                throw new InvalidOperationException("You have already submitted feedback for this session.");

            var feedback = new Feedback
            {
                TutoringRequestId = dto.TutoringRequestId,
                SessionLogId = dto.SessionLogId,
                CustomerId = customerId,
                TeacherId = tutoringRequest.AssignedTeacherId.Value,
                Rating = dto.Rating,
                Comment = dto.Comment,
                CreatedBy = customerId,
                UpdatedBy = customerId,
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            // Notify admin & super admin
            var subjectName = tutoringRequest.Subject?.Name ?? "Session";
            try
            {
                await _notificationService.CreateAsync(new CreateNotificationDto
                {
                    RecipientRole = "Admin",
                    Title = "New Session Feedback",
                    Message = $"A customer submitted a {dto.Rating}-star review for {subjectName}.",
                    Type = "General",
                    Priority = "Normal",
                    ReferenceId = feedback.Id,
                    ReferenceType = "Feedback"
                }, customerId);

                await _notificationService.CreateAsync(new CreateNotificationDto
                {
                    RecipientRole = "Super Admin",
                    Title = "New Session Feedback",
                    Message = $"A customer submitted a {dto.Rating}-star review for {subjectName}.",
                    Type = "General",
                    Priority = "Normal",
                    ReferenceId = feedback.Id,
                    ReferenceType = "Feedback"
                }, customerId);
            }
            catch { /* silent */ }

            return (await GetByIdAsync(feedback.Id))!;
        }

        public async Task<FeedbackResponseDto?> UpdateAsync(int id, UpdateFeedbackDto dto, int userId, bool isAdmin = false)
        {
            var feedback = await _context.Feedbacks.FirstOrDefaultAsync(f => f.Id == id && f.DeletedAt == null);
            if (feedback == null) return null;
            if (!isAdmin && feedback.CustomerId != userId)
                throw new UnauthorizedAccessException("You can only edit your own feedback.");

            if (dto.Rating.HasValue) feedback.Rating = dto.Rating.Value;
            if (dto.Comment != null) feedback.Comment = dto.Comment;
            feedback.UpdatedBy = userId;

            await _context.SaveChangesAsync();
            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id, int userId, bool isAdmin = false)
        {
            var feedback = await _context.Feedbacks.FirstOrDefaultAsync(f => f.Id == id && f.DeletedAt == null);
            if (feedback == null) return false;
            if (!isAdmin && feedback.CustomerId != userId)
                throw new UnauthorizedAccessException("You can only delete your own feedback.");

            feedback.DeletedAt = DateTimeHelper.PhilippineNow;
            feedback.UpdatedBy = userId;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
