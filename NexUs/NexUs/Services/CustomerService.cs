using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<CustomerListDto>> GetAllAsync(PaginationDto pagination)
        {
            var query = _context.Customers
                .Where(c => c.DeletedAt == null)
                .Include(c => c.User)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var term = pagination.SearchTerm.ToLower();
                query = query.Where(c => c.User != null &&
                    (c.User.Email.ToLower().Contains(term) ||
                     c.User.FirstName.ToLower().Contains(term) ||
                     c.User.LastName.ToLower().Contains(term)));
            }

            var totalCount = await query.CountAsync();
            query = query.OrderByDescending(c => c.CreatedAt);

            var items = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PagedResultDto<CustomerListDto>
            {
                Items = items.Select(c => new CustomerListDto
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    UserFullName = c.User != null ? $"{c.User.FirstName} {c.User.LastName}".Trim() : null,
                    UserEmail = c.User?.Email,
                    LeadId = c.LeadId,
                    FirstTutoringRequestId = c.FirstTutoringRequestId,
                    Notes = c.Notes,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                }).ToList(),
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<CustomerResponseDto?> GetByIdAsync(int id)
        {
            var c = await _context.Customers
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id && x.DeletedAt == null);
            if (c == null) return null;

            return new CustomerResponseDto
            {
                Id = c.Id,
                UserId = c.UserId,
                UserFullName = c.User != null ? $"{c.User.FirstName} {c.User.LastName}".Trim() : null,
                UserEmail = c.User?.Email,
                LeadId = c.LeadId,
                FirstTutoringRequestId = c.FirstTutoringRequestId,
                Notes = c.Notes,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            };
        }

        public async Task<CustomerResponseDto?> CreateFromConversionAsync(int userId, int? leadId, int? tutoringRequestId, int? currentUserId = null)
        {
            // Idempotent
            var existing = await _context.Customers.FirstOrDefaultAsync(c => c.UserId == userId);
            if (existing != null) return await GetByIdAsync(existing.Id);

            var entity = new Customer
            {
                UserId = userId,
                LeadId = leadId,
                FirstTutoringRequestId = tutoringRequestId,
                CreatedBy = currentUserId,
                UpdatedBy = currentUserId
            };
            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(entity.Id);
        }
    }
}
