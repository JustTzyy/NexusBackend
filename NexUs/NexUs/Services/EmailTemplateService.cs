using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;
using NexUs.Utilities;

namespace NexUs.Services
{
    public class EmailTemplateService : IEmailTemplateService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EmailTemplateService(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        private static EmailTemplateListDto ToListDto(EmailTemplate t) => new()
        {
            Id = t.Id,
            Name = t.Name,
            Subject = t.Subject,
            FileName = t.FileName,
            Category = t.Category,
            Variables = t.Variables,
            IsActive = t.IsActive,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            CreatedByName = t.CreatedByUser != null ? $"{t.CreatedByUser.FirstName} {t.CreatedByUser.LastName}".Trim() : null,
            UpdatedByName = t.UpdatedByUser != null ? $"{t.UpdatedByUser.FirstName} {t.UpdatedByUser.LastName}".Trim() : null
        };

        private EmailTemplateResponseDto ToResponseDto(EmailTemplate t)
        {
            var dto = new EmailTemplateResponseDto
            {
                Id = t.Id,
                Name = t.Name,
                Subject = t.Subject,
                FileName = t.FileName,
                Category = t.Category,
                Variables = t.Variables,
                IsActive = t.IsActive,
                CreatedAt = t.CreatedAt,
                UpdatedAt = t.UpdatedAt,
                CreatedByName = t.CreatedByUser != null ? $"{t.CreatedByUser.FirstName} {t.CreatedByUser.LastName}".Trim() : null,
                UpdatedByName = t.UpdatedByUser != null ? $"{t.UpdatedByUser.FirstName} {t.UpdatedByUser.LastName}".Trim() : null
            };

            // Prefer DB body; fall back to file for templates not yet migrated
            if (!string.IsNullOrEmpty(t.Body))
            {
                dto.HtmlContent = t.Body;
            }
            else if (!string.IsNullOrEmpty(t.FileName))
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Templates", "Email", t.FileName);
                if (File.Exists(filePath))
                    dto.HtmlContent = File.ReadAllText(filePath);
            }

            return dto;
        }

        public async Task<PagedResultDto<EmailTemplateListDto>> GetAllAsync(PaginationDto pagination)
        {
            var query = _context.EmailTemplates
                .Where(t => t.DeletedAt == null)
                .Include(t => t.CreatedByUser)
                .Include(t => t.UpdatedByUser)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var term = pagination.SearchTerm.ToLower();
                query = query.Where(t => t.Name.ToLower().Contains(term) || t.Subject.ToLower().Contains(term));
            }

            var totalCount = await query.CountAsync();
            query = query.OrderByDescending(t => t.CreatedAt);

            var items = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PagedResultDto<EmailTemplateListDto>
            {
                Items = items.Select(ToListDto).ToList(),
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<PagedResultDto<EmailTemplateListDto>> GetArchivedAsync(PaginationDto pagination)
        {
            var query = _context.EmailTemplates
                .Where(t => t.DeletedAt != null)
                .Include(t => t.CreatedByUser)
                .Include(t => t.UpdatedByUser)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var term = pagination.SearchTerm.ToLower();
                query = query.Where(t => t.Name.ToLower().Contains(term));
            }

            var totalCount = await query.CountAsync();
            query = query.OrderByDescending(t => t.DeletedAt);

            var items = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PagedResultDto<EmailTemplateListDto>
            {
                Items = items.Select(ToListDto).ToList(),
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<EmailTemplateResponseDto?> GetByIdAsync(int id)
        {
            var t = await _context.EmailTemplates
                .Include(x => x.CreatedByUser)
                .Include(x => x.UpdatedByUser)
                .FirstOrDefaultAsync(x => x.Id == id && x.DeletedAt == null);
            return t == null ? null : ToResponseDto(t);
        }

        public async Task<EmailTemplateResponseDto> CreateAsync(CreateEmailTemplateDto dto, int? currentUserId)
        {
            var fileName = dto.FileName;

            // Auto-generate filename and save HTML file if content is provided
            if (!string.IsNullOrWhiteSpace(dto.HtmlContent))
            {
                if (string.IsNullOrWhiteSpace(fileName))
                    fileName = GenerateFileName(dto.Name);
                await SaveHtmlFileAsync(fileName, dto.HtmlContent);
            }

            var entity = new EmailTemplate
            {
                Name = dto.Name,
                Subject = dto.Subject,
                FileName = fileName,
                Body = string.IsNullOrWhiteSpace(dto.HtmlContent) ? null : dto.HtmlContent,
                Variables = dto.Variables,
                Category = dto.Category,
                IsActive = dto.IsActive,
                CreatedBy = currentUserId,
                UpdatedBy = currentUserId
            };
            _context.EmailTemplates.Add(entity);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(entity.Id) ?? throw new Exception("Failed to load created template.");
        }

        public async Task<EmailTemplateResponseDto?> UpdateAsync(int id, UpdateEmailTemplateDto dto, int? currentUserId)
        {
            var entity = await _context.EmailTemplates.FindAsync(id);
            if (entity == null || entity.DeletedAt != null) return null;

            var fileName = dto.FileName;

            // Update HTML file if content is provided
            if (!string.IsNullOrWhiteSpace(dto.HtmlContent))
            {
                if (string.IsNullOrWhiteSpace(fileName))
                    fileName = string.IsNullOrWhiteSpace(entity.FileName) ? GenerateFileName(dto.Name) : entity.FileName;
                await SaveHtmlFileAsync(fileName, dto.HtmlContent);
            }

            entity.Name = dto.Name;
            entity.Subject = dto.Subject;
            entity.FileName = fileName;
            entity.Body = string.IsNullOrWhiteSpace(dto.HtmlContent) ? entity.Body : dto.HtmlContent;
            entity.Variables = dto.Variables;
            entity.Category = dto.Category;
            entity.IsActive = dto.IsActive;
            entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();
            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id, int? currentUserId)
        {
            var entity = await _context.EmailTemplates.FindAsync(id);
            if (entity == null || entity.DeletedAt != null) return false;
            entity.DeletedAt = DateTimeHelper.PhilippineNow;
            entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RestoreAsync(int id, int? currentUserId)
        {
            var entity = await _context.EmailTemplates.FindAsync(id);
            if (entity == null || entity.DeletedAt == null) return false;
            entity.DeletedAt = null;
            entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PermanentDeleteAsync(int id)
        {
            var entity = await _context.EmailTemplates.FindAsync(id);
            if (entity == null) return false;
            _context.EmailTemplates.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string> RenderAsync(int templateId, Dictionary<string, string> variables)
        {
            var template = await _context.EmailTemplates.FindAsync(templateId)
                ?? throw new FileNotFoundException($"Email template {templateId} not found.");

            string html;
            if (!string.IsNullOrEmpty(template.Body))
            {
                html = template.Body;
            }
            else
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Templates", "Email", template.FileName);
                if (!File.Exists(filePath))
                    throw new FileNotFoundException($"Template file not found: {template.FileName}");
                html = await File.ReadAllTextAsync(filePath);
            }
            foreach (var kv in variables)
                html = html.Replace($"{{{{{kv.Key}}}}}", kv.Value);

            return html;
        }

        private static string GenerateFileName(string templateName)
        {
            // "Welcome Email" -> "WelcomeEmailTemplate.html"
            var safe = string.Concat(templateName.Split(Path.GetInvalidFileNameChars()));
            var pascal = string.Concat(safe.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(w => char.ToUpper(w[0]) + w[1..]));
            if (!pascal.EndsWith("Template", StringComparison.OrdinalIgnoreCase))
                pascal += "Template";
            return pascal + ".html";
        }

        private async Task SaveHtmlFileAsync(string fileName, string htmlContent)
        {
            var dir = Path.Combine(_env.ContentRootPath, "Templates", "Email");
            Directory.CreateDirectory(dir);
            var filePath = Path.Combine(dir, fileName);
            await File.WriteAllTextAsync(filePath, htmlContent);
        }
    }
}
