using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.TeacherInterests;
using NexUs.Models.DTO.TutoringRequests;

namespace NexUs.Services.Interfaces
{
    public interface ITutoringRequestService
    {
        // Student endpoints
        Task<PagedResultDto<TutoringRequestListDto>> GetStudentRequestsAsync(int studentId, PaginationDto pagination);
        Task<TutoringRequestStudentDto?> GetStudentRequestByIdAsync(int id, int studentId);
        Task<TutoringRequestResponseDto> CreateRequestAsync(CreateTutoringRequestDto dto, int studentId);
        Task<TutoringRequestResponseDto?> UpdateRequestAsync(int id, UpdateTutoringRequestDto dto, int studentId);
        Task<bool> CancelRequestAsync(int id, int studentId);

        // Student enrollment (for admin-created requests)
        Task<PagedResultDto<TutoringRequestListDto>> GetAvailableSessionsForStudentAsync(int studentId, PaginationDto pagination);
        Task<PagedResultDto<TutoringRequestListDto>> GetMyEnrolledSessionsAsync(int studentId, PaginationDto pagination);
        Task<bool> StudentEnrollAsync(int requestId, int studentId);

        // Teacher endpoints
        Task<PagedResultDto<TutoringRequestListDto>> GetAvailableRequestsForTeacherAsync(int teacherId, PaginationDto pagination);
        Task<bool> ExpressInterestAsync(int requestId, int teacherId, CreateTeacherInterestDto dto);
        Task<PagedResultDto<TutoringRequestListDto>> GetTeacherInterestHistoryAsync(int teacherId, PaginationDto pagination);
        Task<bool> ConfirmSessionAsync(int requestId, int teacherId, bool accepted);
        Task<bool> TeacherWithdrawAsync(int requestId, int teacherId);
    Task<bool> StudentWithdrawAsync(int requestId, int studentId);

        // Admin endpoints
        Task<PagedResultDto<TutoringRequestListDto>> GetAllRequestsAsync(PaginationDto pagination);
        Task<TutoringRequestResponseDto?> GetRequestByIdAsync(int id);
        Task<TutoringRequestResponseDto> CreateAdminRequestAsync(CreateAdminTutoringRequestDto dto, int adminId);
        Task<bool> AssignTeacherAsync(int requestId, int teacherId, int adminId);
        Task<TutoringRequestResponseDto?> ScheduleSessionAsync(int requestId, ScheduleSessionDto dto, int adminId);
        Task<bool> AdminCancelRequestAsync(int id, int adminId, string cancellationReason);
        Task<bool> AdminRestoreRequestAsync(int id, int adminId);
        Task<bool> DeleteRequestAsync(int id, int? currentUserId);
        Task<bool> RestoreRequestAsync(int id, int? currentUserId);

        // Status history
        Task<List<TutoringRequestStatusHistoryDto>> GetAllStatusHistoryAsync();

        // Conflict check (for admin scheduling UI)
        Task<ConflictCheckResultDto> GetConflictDataAsync(int teacherId, int excludeRequestId);
    }
}
