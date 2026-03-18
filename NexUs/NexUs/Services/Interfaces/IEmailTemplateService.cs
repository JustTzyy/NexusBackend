using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;

namespace NexUs.Services.Interfaces
{
    public interface IEmailTemplateService
    {
        Task<PagedResultDto<EmailTemplateListDto>> GetAllAsync(PaginationDto pagination);
        Task<PagedResultDto<EmailTemplateListDto>> GetArchivedAsync(PaginationDto pagination);
        Task<EmailTemplateResponseDto?> GetByIdAsync(int id);
        Task<EmailTemplateResponseDto> CreateAsync(CreateEmailTemplateDto dto, int? currentUserId);
        Task<EmailTemplateResponseDto?> UpdateAsync(int id, UpdateEmailTemplateDto dto, int? currentUserId);
        Task<bool> DeleteAsync(int id, int? currentUserId);
        Task<bool> RestoreAsync(int id, int? currentUserId);
        Task<bool> PermanentDeleteAsync(int id);
        Task<string> RenderAsync(int templateId, Dictionary<string, string> variables);
    }
}
