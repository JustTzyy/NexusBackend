using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Notifications;
using NexUs.Models.DTO.TeacherInterests;
using NexUs.Models.DTO.TutoringRequests;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class TutoringRequestService : ITutoringRequestService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuditService _auditService;
        private readonly IEmailService _emailService;
        private readonly ILeadService _leadService;
        private readonly ICustomerService _customerService;
        private readonly IAutomationService _automationService;
        private readonly INotificationService _notificationService;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<TutoringRequestService> _logger;

        public TutoringRequestService(
            ApplicationDbContext context,
            IAuditService auditService,
            IEmailService emailService,
            ILeadService leadService,
            ICustomerService customerService,
            IAutomationService automationService,
            INotificationService notificationService,
            IServiceScopeFactory scopeFactory,
            ILogger<TutoringRequestService> logger)
        {
            _context = context;
            _auditService = auditService;
            _emailService = emailService;
            _leadService = leadService;
            _customerService = customerService;
            _automationService = automationService;
            _notificationService = notificationService;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        // ==================== Student Endpoints ====================

        public async Task<PagedResultDto<TutoringRequestListDto>> GetStudentRequestsAsync(int studentId, PaginationDto pagination)
        {
            var query = _context.TutoringRequests
                .Include(t => t.Student)
                .Include(t => t.Building)
                .Include(t => t.Department)
                .Include(t => t.Subject)
                .Include(t => t.AssignedTeacher)
                .Include(t => t.Room)
                .Include(t => t.AvailableDay)
                .Include(t => t.AvailableTimeSlot)
                .Where(t => t.StudentId == studentId && !t.IsAdminCreated && t.DeletedAt == null)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var search = pagination.SearchTerm.ToLower();
                query = query.Where(t =>
                    t.Subject.Name.ToLower().Contains(search) ||
                    t.Building.Name.ToLower().Contains(search) ||
                    t.Department.Name.ToLower().Contains(search) ||
                    t.Status.ToLower().Contains(search));
            }

            var totalCount = await query.CountAsync();

            query = (pagination.SortBy?.ToLower(), pagination.SortDescending) switch
            {
                ("subject", true) => query.OrderByDescending(t => t.Subject.Name),
                ("subject", false) => query.OrderBy(t => t.Subject.Name),
                ("status", true) => query.OrderByDescending(t => t.Status),
                ("status", false) => query.OrderBy(t => t.Status),
                ("priority", true) => query.OrderByDescending(t => t.Priority),
                ("priority", false) => query.OrderBy(t => t.Priority),
                _ => query.OrderByDescending(t => t.CreatedAt)
            };

            var items = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(t => new TutoringRequestListDto
                {
                    Id = t.Id,
                    StudentName = t.Student != null ? $"{t.Student.FirstName} {t.Student.LastName}" : null,
                    BuildingName = t.Building.Name,
                    DepartmentName = t.Department.Name,
                    SubjectName = t.Subject.Name,
                    Priority = t.Priority,
                    Status = t.Status,
                    AssignedTeacherName = t.AssignedTeacher != null
                        ? $"{t.AssignedTeacher.FirstName} {t.AssignedTeacher.LastName}" : null,
                    IsAdminCreated = t.IsAdminCreated,
                    CreatedAt = t.CreatedAt,
                    RoomName = t.Room != null ? t.Room.Name : null,
                    DayName = t.AvailableDay != null ? t.AvailableDay.DayName : null,
                    TimeSlotLabel = t.AvailableTimeSlot != null ? t.AvailableTimeSlot.Label : null,
                    ConfirmedAt = t.ConfirmedAt
                })
                .ToListAsync();

            foreach (var item in items)
            {
                if (item.Status == "Confirmed" && item.ConfirmedAt.HasValue && item.DayName != null)
                    item.FirstClassDate = ComputeStartDate(item.ConfirmedAt.Value, item.DayName);
            }

            return new PagedResultDto<TutoringRequestListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<TutoringRequestStudentDto?> GetStudentRequestByIdAsync(int id, int studentId)
        {
            var request = await _context.TutoringRequests
                .Include(t => t.Building)
                .Include(t => t.Department)
                .Include(t => t.Subject)
                .Include(t => t.AssignedTeacher)
                .Include(t => t.Room)
                .Include(t => t.AvailableDay)
                .Include(t => t.AvailableTimeSlot)
                .FirstOrDefaultAsync(t => t.Id == id && t.StudentId == studentId && t.DeletedAt == null);

            if (request == null) return null;

            var dto = new TutoringRequestStudentDto
            {
                Id = request.Id,
                BuildingName = request.Building.Name,
                DepartmentName = request.Department.Name,
                SubjectName = request.Subject.Name,
                Message = request.Message,
                Priority = request.Priority,
                Status = request.Status,
                IsAdminCreated = request.IsAdminCreated,
                CreatedAt = request.CreatedAt,
                CancelledAt = request.CancelledAt,
                CancelledBy = request.CancelledBy
            };

            // Show assigned teacher from "Teacher Assigned" onward
            var showTeacher = request.Status is "Teacher Assigned"
                or "Waiting for Teacher Approval" or "Confirmed";
            if (showTeacher && request.AssignedTeacher != null)
            {
                dto.AssignedTeacherName = $"{request.AssignedTeacher.FirstName} {request.AssignedTeacher.LastName}";
            }

            // Show schedule from "Waiting for Teacher Approval" onward
            var showSchedule = request.Status is "Waiting for Teacher Approval" or "Confirmed";
            if (showSchedule)
            {
                dto.RoomName = request.Room?.Name;
                dto.DayName = request.AvailableDay?.DayName;
                dto.TimeSlotLabel = request.AvailableTimeSlot?.Label;
                dto.ConfirmedAt = request.ConfirmedAt;
            }

            return dto;
        }

        public async Task<PagedResultDto<TutoringRequestListDto>> GetMyEnrolledSessionsAsync(int studentId, PaginationDto pagination)
        {
            var query = _context.TutoringRequests
                .Include(t => t.Building)
                .Include(t => t.Department)
                .Include(t => t.Subject)
                .Include(t => t.AssignedTeacher)
                .Include(t => t.Room)
                .Include(t => t.AvailableDay)
                .Include(t => t.AvailableTimeSlot)
                .Where(t => t.StudentId == studentId && t.IsAdminCreated && t.DeletedAt == null)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var search = pagination.SearchTerm.ToLower();
                query = query.Where(t =>
                    t.Subject.Name.ToLower().Contains(search) ||
                    t.Building.Name.ToLower().Contains(search) ||
                    t.Department.Name.ToLower().Contains(search) ||
                    t.Status.ToLower().Contains(search));
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(t => t.CreatedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(t => new TutoringRequestListDto
                {
                    Id = t.Id,
                    StudentName = t.Student != null ? $"{t.Student.FirstName} {t.Student.LastName}" : null,
                    BuildingName = t.Building.Name,
                    DepartmentName = t.Department.Name,
                    SubjectName = t.Subject.Name,
                    Priority = t.Priority,
                    Status = t.Status,
                    AssignedTeacherName = t.AssignedTeacher != null
                        ? $"{t.AssignedTeacher.FirstName} {t.AssignedTeacher.LastName}" : null,
                    IsAdminCreated = true,
                    CreatedAt = t.CreatedAt,
                    RoomName = t.Room != null ? t.Room.Name : null,
                    DayName = t.AvailableDay != null ? t.AvailableDay.DayName : null,
                    TimeSlotLabel = t.AvailableTimeSlot != null ? t.AvailableTimeSlot.Label : null,
                    ConfirmedAt = t.ConfirmedAt
                })
                .ToListAsync();

            foreach (var item in items)
            {
                if (item.Status == "Confirmed" && item.ConfirmedAt.HasValue && item.DayName != null)
                    item.FirstClassDate = ComputeStartDate(item.ConfirmedAt.Value, item.DayName);
            }

            return new PagedResultDto<TutoringRequestListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<TutoringRequestResponseDto> CreateRequestAsync(CreateTutoringRequestDto dto, int studentId)
        {
            // Validate referenced entities exist
            var building = await _context.Buildings.FirstOrDefaultAsync(b => b.Id == dto.BuildingId && b.DeletedAt == null);
            if (building == null) throw new InvalidOperationException("Building not found");

            var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == dto.DepartmentId && d.DeletedAt == null);
            if (department == null) throw new InvalidOperationException("Department not found");

            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Id == dto.SubjectId && s.DeletedAt == null);
            if (subject == null) throw new InvalidOperationException("Subject not found");

            var request = new TutoringRequest
            {
                StudentId = studentId,
                BuildingId = dto.BuildingId,
                DepartmentId = dto.DepartmentId,
                SubjectId = dto.SubjectId,
                Message = dto.Message,
                Priority = dto.Priority,
                Status = "Pending Teacher Interest",
                CreatedBy = studentId,
                UpdatedBy = studentId
            };

            _context.TutoringRequests.Add(request);
            await _context.SaveChangesAsync();

            LogStatusChange(request, "Pending Teacher Interest", studentId, "Student");
            await _context.SaveChangesAsync();

            await _auditService.LogAsync("TutoringRequests", "Create",
                $"Student created tutoring request for {subject.Name} at {building.Name}", studentId);

            // Notify Admin: new session booked
            await _notificationService.CreateAsync(new CreateNotificationDto
            {
                RecipientRole = "Admin",
                Title = "New Tutoring Request",
                Message = $"A student has submitted a tutoring request for {subject.Name} at {building.Name}.",
                Type = "Tutoring",
                Priority = request.Priority == "Urgent" ? "High" : "Normal",
                ReferenceId = request.Id,
                ReferenceType = "TutoringRequest"
            }, studentId);

            await _notificationService.CreateAsync(new CreateNotificationDto
            {
                RecipientRole = "Super Admin",
                Title = "New Tutoring Request",
                Message = $"A student has submitted a tutoring request for {subject.Name} at {building.Name}.",
                Type = "Tutoring",
                Priority = request.Priority == "Urgent" ? "High" : "Normal",
                ReferenceId = request.Id,
                ReferenceType = "TutoringRequest"
            }, studentId);

            return (await GetRequestByIdAsync(request.Id))!;
        }

        public async Task<TutoringRequestResponseDto?> UpdateRequestAsync(int id, UpdateTutoringRequestDto dto, int studentId)
        {
            var request = await _context.TutoringRequests
                .FirstOrDefaultAsync(t => t.Id == id && t.StudentId == studentId && t.DeletedAt == null);

            if (request == null) return null;

            if (request.Status != "Pending Teacher Interest")
                throw new InvalidOperationException("You can only edit requests that are still pending");

            var changes = new List<string>();

            if (!string.IsNullOrEmpty(dto.Message) && dto.Message != request.Message)
            {
                changes.Add($"Message updated");
                request.Message = dto.Message;
            }

            if (!string.IsNullOrEmpty(dto.Priority) && dto.Priority != request.Priority)
            {
                changes.Add($"Priority: {request.Priority} → {dto.Priority}");
                request.Priority = dto.Priority;
            }

            request.UpdatedBy = studentId;
            await _context.SaveChangesAsync();

            if (changes.Any())
            {
                await _auditService.LogAsync("TutoringRequests", "Update",
                    $"Student updated request #{id}: {string.Join(", ", changes)}", studentId);
            }

            return await GetRequestByIdAsync(id);
        }

        public async Task<bool> CancelRequestAsync(int id, int studentId)
        {
            var request = await _context.TutoringRequests
                .Include(t => t.TeacherInterests)
                .FirstOrDefaultAsync(t => t.Id == id && t.StudentId == studentId && t.DeletedAt == null);

            if (request == null) return false;

            var alwaysBlocked = new[] { "Cancelled by Student", "Cancelled by Admin" };
            if (alwaysBlocked.Contains(request.Status))
                throw new InvalidOperationException("This request cannot be cancelled in its current state");

            // Confirmed admin-created sessions must use withdraw instead
            if (request.Status == "Confirmed" && request.IsAdminCreated)
                throw new InvalidOperationException("Admin-created confirmed sessions cannot be cancelled directly. Please use withdraw instead.");

            // Reset assignment/schedule fields
            request.AssignedTeacherId = null;
            request.RoomId = null;
            request.AvailableDayId = null;
            request.AvailableTimeSlotId = null;
            request.ScheduledAt = null;

            // Close all teacher interests
            foreach (var ti in request.TeacherInterests)
            {
                if (ti.Status == "Interested" || ti.Status == "Selected")
                    ti.Status = "Closed";
            }

            LogStatusChange(request, "Cancelled by Student", studentId, "Student");
            request.Status = "Cancelled by Student";
            request.CancelledAt = DateTime.UtcNow;
            request.CancelledBy = "Student";
            request.UpdatedBy = studentId;
            await _context.SaveChangesAsync();

            await _auditService.LogAsync("TutoringRequests", "Cancel",
                $"Student cancelled request #{id} (was {request.Status})", studentId);

            // Notify Admin: student cancelled request
            await _notificationService.CreateAsync(new CreateNotificationDto
            {
                RecipientRole = "Admin",
                Title = "Session Cancelled by Student",
                Message = $"Tutoring request #{id} has been cancelled by the student.",
                Type = "Tutoring",
                Priority = "Normal",
                ReferenceId = id,
                ReferenceType = "TutoringRequest"
            }, studentId);

            await _notificationService.CreateAsync(new CreateNotificationDto
            {
                RecipientRole = "Super Admin",
                Title = "Session Cancelled by Student",
                Message = $"Tutoring request #{id} has been cancelled by the student.",
                Type = "Tutoring",
                Priority = "Normal",
                ReferenceId = id,
                ReferenceType = "TutoringRequest"
            }, studentId);

            return true;
        }

        public async Task<bool> AdminCancelRequestAsync(int id, int adminId, string cancellationReason)
        {
            var request = await _context.TutoringRequests
                .Include(t => t.TeacherInterests)
                .Include(t => t.Student)
                .Include(t => t.AssignedTeacher)
                .Include(t => t.Subject)
                .Include(t => t.Building)
                .FirstOrDefaultAsync(t => t.Id == id && t.DeletedAt == null);

            if (request == null) return false;

            var finalStatuses = new[] { "Cancelled by Student", "Cancelled by Admin" };
            if (finalStatuses.Contains(request.Status))
                throw new InvalidOperationException("This request is already cancelled");

            var previousStatus = request.Status;

            // Capture contact info before clearing assignments
            var studentName = request.Student != null
                ? $"{request.Student.FirstName} {request.Student.LastName}".Trim() : null;
            var studentEmail = request.Student?.Email;
            var teacherName = request.AssignedTeacher != null
                ? $"{request.AssignedTeacher.FirstName} {request.AssignedTeacher.LastName}".Trim() : null;
            var teacherEmail = request.AssignedTeacher?.Email;
            var subjectName = request.Subject?.Name ?? "Tutoring Session";
            var buildingName = request.Building?.Name ?? "";

            // Reset assignment/schedule fields
            request.AssignedTeacherId = null;
            request.RoomId = null;
            request.AvailableDayId = null;
            request.AvailableTimeSlotId = null;
            request.ScheduledAt = null;
            request.ConfirmedAt = null;

            // Close all teacher interests
            foreach (var ti in request.TeacherInterests)
            {
                if (ti.Status == "Interested" || ti.Status == "Selected")
                    ti.Status = "Closed";
            }

            var cancelledAt = DateTime.UtcNow;
            LogStatusChange(request, "Cancelled by Admin", adminId, "Admin");
            request.Status = "Cancelled by Admin";
            request.CancelledAt = cancelledAt;
            request.CancelledBy = "Admin";
            request.UpdatedBy = adminId;
            await _context.SaveChangesAsync();

            await _auditService.LogAsync("TutoringRequests", "AdminCancel",
                $"Admin cancelled request #{id} (was {previousStatus}). Reason: {cancellationReason}", adminId);

            // Notify student: admin cancelled the session
            if (request.StudentId.HasValue)
            {
                await _notificationService.CreateAsync(new CreateNotificationDto
                {
                    RecipientUserId = request.StudentId.Value,
                    Title = "Session Cancelled by Admin",
                    Message = $"Your tutoring request #{id} has been cancelled. Reason: {cancellationReason}",
                    Type = "Tutoring",
                    Priority = "High",
                    ReferenceId = id,
                    ReferenceType = "TutoringRequest"
                }, adminId);
            }

            // Notify teacher: admin cancelled the session
            if (request.AssignedTeacherId.HasValue)
            {
                await _notificationService.CreateAsync(new CreateNotificationDto
                {
                    RecipientUserId = request.AssignedTeacherId.Value,
                    Title = "Session Cancelled by Admin",
                    Message = $"Tutoring request #{id} has been cancelled by admin. Reason: {cancellationReason}",
                    Type = "Tutoring",
                    Priority = "High",
                    ReferenceId = id,
                    ReferenceType = "TutoringRequest"
                }, adminId);
            }

            // Fire-and-forget emails using own DI scope so the background task
            // isn't affected by the request scope being disposed, and doesn't
            // share a DbContext with this request.
            var scopeFactory = _scopeFactory;
            _ = Task.Run(async () =>
            {
                using var bgScope = scopeFactory.CreateScope();
                var automation = bgScope.ServiceProvider.GetRequiredService<IAutomationService>();
                var emailSvc   = bgScope.ServiceProvider.GetRequiredService<IEmailService>();
                try
                {
                    // Email the student
                    if (!string.IsNullOrEmpty(studentEmail))
                    {
                        var studentCancelled = await automation.TriggerAndSendImmediatelyAsync("SessionCancelled", new Dictionary<string, object>
                        {
                            { "Email", studentEmail },
                            { "FirstName", studentName ?? "Student" },
                            { "RecipientName", studentName ?? "Student" },
                            { "TeacherName", teacherName ?? "Not yet assigned" },
                            { "StudentName", studentName ?? "Not yet assigned" },
                            { "SubjectName", subjectName },
                            { "BuildingName", buildingName },
                            { "CancellationReason", cancellationReason },
                            { "CancelledAt", cancelledAt.ToLocalTime().ToString("MMMM dd, yyyy") }
                        });
                        if (!studentCancelled)
                            await emailSvc.SendAdminCancelEmailAsync(studentEmail, studentName ?? "Student", teacherName ?? "Not yet assigned", studentName ?? "Not yet assigned", subjectName, buildingName, cancellationReason, cancelledAt);
                    }

                    // Email the assigned teacher
                    if (!string.IsNullOrEmpty(teacherEmail))
                    {
                        var teacherCancelled = await automation.TriggerAndSendImmediatelyAsync("SessionCancelled", new Dictionary<string, object>
                        {
                            { "Email", teacherEmail },
                            { "FirstName", teacherName ?? "Teacher" },
                            { "RecipientName", teacherName ?? "Teacher" },
                            { "TeacherName", teacherName ?? "Not yet assigned" },
                            { "StudentName", studentName ?? "Not yet assigned" },
                            { "SubjectName", subjectName },
                            { "BuildingName", buildingName },
                            { "CancellationReason", cancellationReason },
                            { "CancelledAt", cancelledAt.ToLocalTime().ToString("MMMM dd, yyyy") }
                        });
                        if (!teacherCancelled)
                            await emailSvc.SendAdminCancelEmailAsync(teacherEmail, teacherName ?? "Teacher", teacherName ?? "Not yet assigned", studentName ?? "Not yet assigned", subjectName, buildingName, cancellationReason, cancelledAt);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "[AdminCancelRequestAsync] Non-fatal email error for request {RequestId}", id);
                }
            });

            return true;
        }

        public async Task<bool> AdminRestoreRequestAsync(int id, int adminId)
        {
            var request = await _context.TutoringRequests
                .Include(t => t.TeacherInterests)
                .FirstOrDefaultAsync(t => t.Id == id && t.DeletedAt == null);

            if (request == null) return false;

            var cancelledStatuses = new[] { "Cancelled by Admin", "Cancelled by Student" };
            if (!cancelledStatuses.Contains(request.Status))
                throw new InvalidOperationException("Only cancelled requests can be restored");

            // Do NOT reopen closed teacher interests — teachers must re-express interest fresh
            LogStatusChange(request, "Pending Teacher Interest", adminId, "Admin");
            request.Status = "Pending Teacher Interest";
            request.CancelledAt = null;
            request.CancelledBy = null;
            request.UpdatedBy = adminId;
            await _context.SaveChangesAsync();

            await _auditService.LogAsync("TutoringRequests", "AdminRestore",
                $"Admin restored cancelled request #{id} to Pending Teacher Interest. Teachers must re-express interest.", adminId);

            return true;
        }

        public async Task<bool> TeacherWithdrawAsync(int requestId, int teacherId)
        {
            var request = await _context.TutoringRequests
                .Include(t => t.TeacherInterests)
                .FirstOrDefaultAsync(t => t.Id == requestId && t.DeletedAt == null);

            if (request == null) return false;

            if (request.Status != "Confirmed")
                throw new InvalidOperationException("You can only withdraw from confirmed sessions");
            if (request.AssignedTeacherId != teacherId)
                throw new InvalidOperationException("You are not the assigned teacher for this request");

            // Reset to admin review
            LogStatusChange(request, "Waiting for Admin Approval", teacherId, "Teacher");
            request.Status = "Waiting for Admin Approval";
            request.AssignedTeacherId = null;
            request.RoomId = null;
            request.AvailableDayId = null;
            request.AvailableTimeSlotId = null;
            request.ScheduledAt = null;
            request.ConfirmedAt = null;
            request.UpdatedBy = teacherId;

            // Update teacher interest statuses
            foreach (var ti in request.TeacherInterests)
            {
                if (ti.TeacherId == teacherId)
                    ti.Status = "Withdrawn";
                else if (ti.Status == "Closed")
                    ti.Status = "Interested";
            }

            await _context.SaveChangesAsync();

            await _auditService.LogAsync("TutoringRequests", "TeacherWithdraw",
                $"Teacher #{teacherId} withdrew from confirmed request #{requestId}", teacherId);

            return true;
        }

        public async Task<bool> StudentWithdrawAsync(int requestId, int studentId)
        {
            var request = await _context.TutoringRequests
                .Include(t => t.TeacherInterests)
                .FirstOrDefaultAsync(t => t.Id == requestId && t.StudentId == studentId && t.DeletedAt == null);

            if (request == null) return false;

            if (request.Status != "Confirmed" && request.Status != "Waiting for Teacher Approval")
                throw new InvalidOperationException("You can only withdraw from scheduled or confirmed sessions");

            if (request.IsAdminCreated)
            {
                // Admin-created: free the slot for another student
                LogStatusChange(request, "Pending Student Interest", studentId, "Student");
                request.Status = "Pending Student Interest";
                request.StudentId = null;
            }
            else
            {
                // Student-created: full reset like teacher withdraw
                LogStatusChange(request, "Waiting for Admin Approval", studentId, "Student");
                request.Status = "Waiting for Admin Approval";
                request.AssignedTeacherId = null;
                request.RoomId = null;
                request.AvailableDayId = null;
                request.AvailableTimeSlotId = null;
                request.ScheduledAt = null;
                request.ConfirmedAt = null;

                foreach (var ti in request.TeacherInterests)
                {
                    if (ti.Status == "Selected" || ti.Status == "Closed")
                        ti.Status = "Interested";
                }
            }

            request.UpdatedBy = studentId;
            await _context.SaveChangesAsync();

            await _auditService.LogAsync("TutoringRequests", "StudentWithdraw",
                $"Student #{studentId} withdrew from request #{requestId}", studentId);

            return true;
        }

        // ==================== Teacher Endpoints ====================

        public async Task<PagedResultDto<TutoringRequestListDto>> GetAvailableRequestsForTeacherAsync(int teacherId, PaginationDto pagination)
        {
            // Get teacher's assignments (building + department combos)
            var assignments = await _context.TeacherAssignments
                .Where(a => a.TeacherId == teacherId && a.DeletedAt == null)
                .Select(a => new { a.BuildingId, a.DepartmentId })
                .ToListAsync();

            var query = _context.TutoringRequests
                .Include(t => t.Student)
                .Include(t => t.Building)
                .Include(t => t.Department)
                .Include(t => t.Subject)
                .Where(t => (t.Status == "Pending Teacher Interest" || t.Status == "Waiting for Admin Approval") && t.DeletedAt == null)
                .AsQueryable();

            // Filter by teacher's assigned buildings/departments
            var buildingIds = assignments.Select(a => a.BuildingId).Distinct().ToList();
            var departmentIds = assignments.Select(a => a.DepartmentId).Distinct().ToList();
            query = query.Where(t => buildingIds.Contains(t.BuildingId) && departmentIds.Contains(t.DepartmentId));

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var search = pagination.SearchTerm.ToLower();
                query = query.Where(t =>
                    t.Subject.Name.ToLower().Contains(search) ||
                    t.Building.Name.ToLower().Contains(search));
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(t => t.CreatedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(t => new TutoringRequestListDto
                {
                    Id = t.Id,
                    StudentName = t.Student != null ? $"{t.Student.FirstName} {t.Student.LastName}" : null,
                    BuildingName = t.Building.Name,
                    DepartmentName = t.Department.Name,
                    SubjectName = t.Subject.Name,
                    Priority = t.Priority,
                    Status = t.Status,
                    IsAdminCreated = t.IsAdminCreated,
                    CreatedAt = t.CreatedAt
                })
                .ToListAsync();

            return new PagedResultDto<TutoringRequestListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<bool> ExpressInterestAsync(int requestId, int teacherId, CreateTeacherInterestDto dto)
        {
            var request = await _context.TutoringRequests
                .Include(t => t.TeacherInterests)
                .FirstOrDefaultAsync(t => t.Id == requestId && t.DeletedAt == null);

            if (request == null) throw new InvalidOperationException("Request not found");

            var existingInterest = request.TeacherInterests.FirstOrDefault(ti => ti.TeacherId == teacherId);

            // Re-expression path: allowed if the teacher previously withdrew OR
            // their interest was closed due to a cancel+restore cycle
            if (existingInterest != null)
            {
                if (existingInterest.Status != "Withdrawn" && existingInterest.Status != "Closed")
                    throw new InvalidOperationException("You have already expressed interest in this request");

                if (request.Status != "Pending Teacher Interest" && request.Status != "Waiting for Admin Approval")
                    throw new InvalidOperationException("This request is no longer accepting interest");

                // Reset the closed/withdrawn record instead of creating a duplicate
                existingInterest.Status = "Interested";
                if (!string.IsNullOrWhiteSpace(dto.Description))
                    existingInterest.Description = dto.Description;
                existingInterest.UpdatedBy = teacherId;
                existingInterest.UpdatedAt = DateTime.UtcNow;

                // Advance the request status if it is still in the open/pending state
                if (request.Status == "Pending Teacher Interest")
                {
                    LogStatusChange(request, "Waiting for Admin Approval", teacherId, "Teacher");
                    request.Status = "Waiting for Admin Approval";
                    request.UpdatedBy = teacherId;
                }

                await _context.SaveChangesAsync();
                await _auditService.LogAsync("TutoringRequests", "ReExpressInterest",
                    $"Teacher #{teacherId} re-expressed interest in request #{requestId}", teacherId);
                return true;
            }

            // First-time interest: only allowed when the request is awaiting teacher interest
            if (request.Status != "Pending Teacher Interest")
                throw new InvalidOperationException("This request is no longer accepting teacher interest");

            var interest = new TeacherInterest
            {
                TutoringRequestId = requestId,
                TeacherId = teacherId,
                Description = dto.Description,
                Status = "Interested",
                CreatedBy = teacherId,
                UpdatedBy = teacherId
            };

            _context.TeacherInterests.Add(interest);
            LogStatusChange(request, "Waiting for Admin Approval", teacherId, "Teacher");
            request.Status = "Waiting for Admin Approval";
            request.UpdatedBy = teacherId;
            await _context.SaveChangesAsync();

            await _auditService.LogAsync("TutoringRequests", "ExpressInterest",
                $"Teacher #{teacherId} expressed interest in request #{requestId}", teacherId);

            return true;
        }

        public async Task<PagedResultDto<TutoringRequestListDto>> GetTeacherInterestHistoryAsync(int teacherId, PaginationDto pagination)
        {
            var query = _context.TutoringRequests
                .Include(t => t.Student)
                .Include(t => t.Building)
                .Include(t => t.Department)
                .Include(t => t.Subject)
                .Include(t => t.AssignedTeacher)
                .Include(t => t.Room)
                .Include(t => t.AvailableDay)
                .Include(t => t.AvailableTimeSlot)
                .Include(t => t.TeacherInterests)
                .Where(t => t.TeacherInterests.Any(ti => ti.TeacherId == teacherId) && t.DeletedAt == null)
                .AsQueryable();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(t => t.CreatedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(t => new TutoringRequestListDto
                {
                    Id = t.Id,
                    StudentName = t.Student != null ? $"{t.Student.FirstName} {t.Student.LastName}" : null,
                    BuildingName = t.Building.Name,
                    DepartmentName = t.Department.Name,
                    SubjectName = t.Subject.Name,
                    Priority = t.Priority,
                    Status = t.Status,
                    AssignedTeacherName = t.AssignedTeacher != null
                        ? $"{t.AssignedTeacher.FirstName} {t.AssignedTeacher.LastName}" : null,
                    IsAdminCreated = t.IsAdminCreated,
                    CreatedAt = t.CreatedAt,
                    RoomName = t.Room != null ? t.Room.Name : null,
                    DayName = t.AvailableDay != null ? t.AvailableDay.DayName : null,
                    TimeSlotLabel = t.AvailableTimeSlot != null ? t.AvailableTimeSlot.Label : null,
                    MyInterestStatus = t.TeacherInterests
                        .Where(ti => ti.TeacherId == teacherId)
                        .Select(ti => ti.Status)
                        .FirstOrDefault(),
                    ConfirmedAt = t.ConfirmedAt
                })
                .ToListAsync();

            // Compute FirstClassDate for confirmed sessions (one week after ConfirmedAt, on the scheduled weekday)
            foreach (var item in items)
            {
                if (item.Status == "Confirmed" && item.ConfirmedAt.HasValue && item.DayName != null)
                    item.FirstClassDate = ComputeStartDate(item.ConfirmedAt.Value, item.DayName);
            }

            return new PagedResultDto<TutoringRequestListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<bool> ConfirmSessionAsync(int requestId, int teacherId, bool accepted)
        {
            var request = await _context.TutoringRequests
                .Include(t => t.TeacherInterests)
                .FirstOrDefaultAsync(t => t.Id == requestId && t.DeletedAt == null);

            if (request == null) throw new InvalidOperationException("Request not found");
            if (request.Status != "Waiting for Teacher Approval")
                throw new InvalidOperationException("This request is not awaiting teacher approval");
            if (request.AssignedTeacherId != teacherId)
                throw new InvalidOperationException("You are not the assigned teacher for this request");

            if (accepted)
            {
                // Admin-created requests go to "Pending Student Interest" instead of "Confirmed"
                if (request.IsAdminCreated && request.StudentId == null)
                {
                    LogStatusChange(request, "Pending Student Interest", teacherId, "Teacher");
                    request.Status = "Pending Student Interest";
                    await _auditService.LogAsync("TutoringRequests", "Confirm",
                        $"Teacher #{teacherId} confirmed admin-created request #{requestId}. Waiting for student enrollment.", teacherId);
                }
                else
                {
                    if (request.StudentId.HasValue && request.AvailableDayId.HasValue && request.AvailableTimeSlotId.HasValue)
                    {
                        var studentConflict = await HasStudentScheduleConflictAsync(
                            request.StudentId.Value,
                            request.AvailableDayId.Value,
                            request.AvailableTimeSlotId.Value,
                            request.Id);

                        if (studentConflict)
                            throw new InvalidOperationException("The student already has a session at this day and time");
                    }

                    LogStatusChange(request, "Confirmed", teacherId, "Teacher");
                    request.Status = "Confirmed";
                    request.ConfirmedAt = DateTime.UtcNow;
                    await _auditService.LogAsync("TutoringRequests", "Confirm",
                        $"Teacher #{teacherId} confirmed request #{requestId}", teacherId);

                    // Option B: send confirmation emails to both parties
                    await SendConfirmationEmailsAsync(request);

                    // Notify student: session confirmed
                    if (request.StudentId.HasValue)
                    {
                        await _notificationService.CreateAsync(new CreateNotificationDto
                        {
                            RecipientUserId = request.StudentId.Value,
                            Title = "Session Confirmed",
                            Message = $"Your tutoring request #{requestId} has been confirmed by the teacher.",
                            Type = "Tutoring",
                            Priority = "High",
                            ReferenceId = requestId,
                            ReferenceType = "TutoringRequest"
                        }, teacherId);
                    }

                    // Notify Admin: session confirmed
                    await _notificationService.CreateAsync(new CreateNotificationDto
                    {
                        RecipientRole = "Admin",
                        Title = "Session Confirmed",
                        Message = $"Tutoring request #{requestId} has been confirmed by the assigned teacher.",
                        Type = "Tutoring",
                        Priority = "Normal",
                        ReferenceId = requestId,
                        ReferenceType = "TutoringRequest"
                    }, teacherId);

                    await _notificationService.CreateAsync(new CreateNotificationDto
                    {
                        RecipientRole = "Super Admin",
                        Title = "Session Confirmed",
                        Message = $"Tutoring request #{requestId} has been confirmed by the assigned teacher.",
                        Type = "Tutoring",
                        Priority = "Normal",
                        ReferenceId = requestId,
                        ReferenceType = "TutoringRequest"
                    }, teacherId);
                }
            }
            else
            {
                // Reset schedule, go back to admin
                LogStatusChange(request, "Waiting for Admin Approval", teacherId, "Teacher");
                request.Status = "Waiting for Admin Approval";
                request.AssignedTeacherId = null;
                request.RoomId = null;
                request.AvailableDayId = null;
                request.AvailableTimeSlotId = null;
                request.ScheduledAt = null;

                // Update teacher interest statuses
                foreach (var ti in request.TeacherInterests)
                {
                    if (ti.Status == "Selected") ti.Status = "Declined";
                    else if (ti.Status == "Closed") ti.Status = "Interested";
                }

                await _auditService.LogAsync("TutoringRequests", "Decline",
                    $"Teacher #{teacherId} declined request #{requestId}", teacherId);
            }

            request.UpdatedBy = teacherId;
            await _context.SaveChangesAsync();

            // Promote Lead → Customer if this is a student-created confirmed session
            if (accepted && !(request.IsAdminCreated && request.StudentId == null) && request.StudentId.HasValue)
                await PromoteLeadToCustomerAsync(request.StudentId.Value, request.Id);

            return true;
        }

        // ==================== Admin Endpoints ====================

        public async Task<PagedResultDto<TutoringRequestListDto>> GetAllRequestsAsync(PaginationDto pagination)
        {
            var query = _context.TutoringRequests
                .Include(t => t.Student)
                .Include(t => t.Building)
                .Include(t => t.Department)
                .Include(t => t.Subject)
                .Include(t => t.AssignedTeacher)
                .Include(t => t.Room)
                .Include(t => t.AvailableDay)
                .Include(t => t.AvailableTimeSlot)
                .Where(t => t.DeletedAt == null)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var search = pagination.SearchTerm.ToLower();
                query = query.Where(t =>
                    t.Subject.Name.ToLower().Contains(search) ||
                    t.Building.Name.ToLower().Contains(search) ||
                    t.Department.Name.ToLower().Contains(search) ||
                    t.Student.FirstName.ToLower().Contains(search) ||
                    t.Student.LastName.ToLower().Contains(search) ||
                    t.Status.ToLower().Contains(search));
            }

            var totalCount = await query.CountAsync();

            query = (pagination.SortBy?.ToLower(), pagination.SortDescending) switch
            {
                ("subject", true) => query.OrderByDescending(t => t.Subject.Name),
                ("subject", false) => query.OrderBy(t => t.Subject.Name),
                ("status", true) => query.OrderByDescending(t => t.Status),
                ("status", false) => query.OrderBy(t => t.Status),
                ("student", true) => query.OrderByDescending(t => t.Student.FirstName),
                ("student", false) => query.OrderBy(t => t.Student.FirstName),
                _ => query.OrderByDescending(t => t.CreatedAt)
            };

            var items = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(t => new TutoringRequestListDto
                {
                    Id = t.Id,
                    StudentName = t.Student != null ? $"{t.Student.FirstName} {t.Student.LastName}" : null,
                    BuildingName = t.Building.Name,
                    DepartmentName = t.Department.Name,
                    SubjectName = t.Subject.Name,
                    Priority = t.Priority,
                    Status = t.Status,
                    AssignedTeacherName = t.AssignedTeacher != null
                        ? $"{t.AssignedTeacher.FirstName} {t.AssignedTeacher.LastName}" : null,
                    IsAdminCreated = t.IsAdminCreated,
                    CreatedAt = t.CreatedAt,
                    RoomName = t.Room != null ? t.Room.Name : null,
                    DayName = t.AvailableDay != null ? t.AvailableDay.DayName : null,
                    TimeSlotLabel = t.AvailableTimeSlot != null ? t.AvailableTimeSlot.Label : null,
                    StartTime = t.AvailableTimeSlot != null ? t.AvailableTimeSlot.StartTime : null,
                    EndTime = t.AvailableTimeSlot != null ? t.AvailableTimeSlot.EndTime : null,
                })
                .ToListAsync();

            return new PagedResultDto<TutoringRequestListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<TutoringRequestResponseDto?> GetRequestByIdAsync(int id)
        {
            var request = await _context.TutoringRequests
                .IgnoreQueryFilters()
                .Include(t => t.Student)
                .Include(t => t.Building)
                .Include(t => t.Department)
                .Include(t => t.Subject)
                .Include(t => t.AssignedTeacher)
                .Include(t => t.Room)
                .Include(t => t.AvailableDay)
                .Include(t => t.AvailableTimeSlot)
                .Include(t => t.TeacherInterests)
                    .ThenInclude(ti => ti.Teacher)
                .Include(t => t.CreatedByUser)
                .Include(t => t.UpdatedByUser)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (request == null) return null;

            return new TutoringRequestResponseDto
            {
                Id = request.Id,
                StudentId = request.StudentId,
                StudentName = request.Student != null
                    ? $"{request.Student.FirstName} {request.Student.LastName}" : null,
                BuildingId = request.BuildingId,
                BuildingName = request.Building.Name,
                DepartmentId = request.DepartmentId,
                DepartmentName = request.Department.Name,
                SubjectId = request.SubjectId,
                SubjectName = request.Subject.Name,
                Message = request.Message,
                Priority = request.Priority,
                Status = request.Status,
                IsAdminCreated = request.IsAdminCreated,
                AssignedTeacherId = request.AssignedTeacherId,
                AssignedTeacherName = request.AssignedTeacher != null
                    ? $"{request.AssignedTeacher.FirstName} {request.AssignedTeacher.LastName}" : null,
                RoomId = request.RoomId,
                RoomName = request.Room?.Name,
                AvailableDayId = request.AvailableDayId,
                DayName = request.AvailableDay?.DayName,
                AvailableTimeSlotId = request.AvailableTimeSlotId,
                TimeSlotLabel = request.AvailableTimeSlot?.Label,
                CreatedAt = request.CreatedAt,
                ScheduledAt = request.ScheduledAt,
                ConfirmedAt = request.ConfirmedAt,
                FirstClassDate = request.Status == "Confirmed" && request.ConfirmedAt.HasValue && request.AvailableDay != null
                    ? ComputeStartDate(request.ConfirmedAt.Value, request.AvailableDay.DayName)
                    : (DateTime?)null,
                CancelledAt = request.CancelledAt,
                CancelledBy = request.CancelledBy,
                DeletedAt = request.DeletedAt,
                CreatedBy = request.CreatedBy,
                UpdatedBy = request.UpdatedBy,
                CreatedByName = request.CreatedByUser != null
                    ? $"{request.CreatedByUser.FirstName} {request.CreatedByUser.LastName}".Trim() : null,
                UpdatedByName = request.UpdatedByUser != null
                    ? $"{request.UpdatedByUser.FirstName} {request.UpdatedByUser.LastName}".Trim() : null,
                InterestedTeachers = request.TeacherInterests.Select(ti => new TeacherInterestResponseDto
                {
                    Id = ti.Id,
                    TutoringRequestId = ti.TutoringRequestId,
                    TeacherId = ti.TeacherId,
                    TeacherName = $"{ti.Teacher.FirstName} {ti.Teacher.LastName}",
                    Description = ti.Description,
                    Status = ti.Status,
                    CreatedAt = ti.CreatedAt
                }).ToList()
            };
        }

        public async Task<bool> AssignTeacherAsync(int requestId, int teacherId, int adminId)
        {
            var request = await _context.TutoringRequests
                .Include(t => t.TeacherInterests)
                .FirstOrDefaultAsync(t => t.Id == requestId && t.DeletedAt == null);

            if (request == null) throw new InvalidOperationException("Request not found");
            if (request.Status != "Waiting for Admin Approval")
                throw new InvalidOperationException("This request is not awaiting admin approval");

            // Verify the teacher has expressed interest
            var interest = request.TeacherInterests.FirstOrDefault(ti => ti.TeacherId == teacherId);
            if (interest == null)
                throw new InvalidOperationException("This teacher has not expressed interest in this request");

            request.AssignedTeacherId = teacherId;
            LogStatusChange(request, "Teacher Assigned", adminId, "Admin");
            request.Status = "Teacher Assigned";
            request.UpdatedBy = adminId;

            // Mark selected teacher, close others
            foreach (var ti in request.TeacherInterests)
            {
                ti.Status = ti.TeacherId == teacherId ? "Selected" : "Closed";
            }

            await _context.SaveChangesAsync();

            await _auditService.LogAsync("TutoringRequests", "AssignTeacher",
                $"Admin assigned teacher #{teacherId} to request #{requestId}", adminId);

            // Notify teacher: you have been assigned
            await _notificationService.CreateAsync(new CreateNotificationDto
            {
                RecipientUserId = teacherId,
                Title = "Tutor Assignment",
                Message = $"You have been assigned to tutoring request #{requestId}. Please review the details.",
                Type = "Tutoring",
                Priority = "High",
                ReferenceId = requestId,
                ReferenceType = "TutoringRequest"
            }, adminId);

            // Notify student: a teacher has been assigned
            if (request.StudentId.HasValue)
            {
                await _notificationService.CreateAsync(new CreateNotificationDto
                {
                    RecipientUserId = request.StudentId.Value,
                    Title = "Teacher Assigned to Your Request",
                    Message = $"A teacher has been assigned to your tutoring request #{requestId}.",
                    Type = "Tutoring",
                    Priority = "Normal",
                    ReferenceId = requestId,
                    ReferenceType = "TutoringRequest"
                }, adminId);
            }

            return true;
        }

        public async Task<TutoringRequestResponseDto?> ScheduleSessionAsync(int requestId, ScheduleSessionDto dto, int adminId)
        {
            var request = await _context.TutoringRequests
                .FirstOrDefaultAsync(t => t.Id == requestId && t.DeletedAt == null);

            if (request == null) return null;
            if (request.Status != "Teacher Assigned")
                throw new InvalidOperationException("A teacher must be assigned before scheduling");

            // Validate room, day, time slot exist
            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == dto.RoomId && r.DeletedAt == null);
            if (room == null) throw new InvalidOperationException("Room not found");

            var day = await _context.AvailableDays.FirstOrDefaultAsync(d => d.Id == dto.AvailableDayId && d.DeletedAt == null);
            if (day == null) throw new InvalidOperationException("Available day not found");

            var slot = await _context.AvailableTimeSlots.FirstOrDefaultAsync(s => s.Id == dto.AvailableTimeSlotId && s.DeletedAt == null);
            if (slot == null) throw new InvalidOperationException("Time slot not found");

            // Check for scheduling conflicts — include all statuses that have committed a teacher/room
            var conflictStatuses = new[] { "Confirmed", "Waiting for Teacher Approval", "Teacher Assigned" };

            var teacherConflict = await _context.TutoringRequests
                .AnyAsync(t => t.Id != requestId
                    && t.AssignedTeacherId == request.AssignedTeacherId
                    && t.AvailableDayId == dto.AvailableDayId
                    && t.AvailableTimeSlotId == dto.AvailableTimeSlotId
                    && conflictStatuses.Contains(t.Status)
                    && t.DeletedAt == null);

            if (teacherConflict)
                throw new InvalidOperationException("The assigned teacher already has a session at this day and time");

            var roomConflict = await _context.TutoringRequests
                .AnyAsync(t => t.Id != requestId
                    && t.RoomId == dto.RoomId
                    && t.AvailableDayId == dto.AvailableDayId
                    && t.AvailableTimeSlotId == dto.AvailableTimeSlotId
                    && conflictStatuses.Contains(t.Status)
                    && t.DeletedAt == null);

            if (roomConflict)
                throw new InvalidOperationException("This room is already booked at this day and time");

            if (request.StudentId.HasValue)
            {
                var studentConflict = await HasStudentScheduleConflictAsync(
                    request.StudentId.Value,
                    dto.AvailableDayId,
                    dto.AvailableTimeSlotId,
                    requestId);

                if (studentConflict)
                    throw new InvalidOperationException("The student already has a session at this day and time");
            }

            request.RoomId = dto.RoomId;
            request.AvailableDayId = dto.AvailableDayId;
            request.AvailableTimeSlotId = dto.AvailableTimeSlotId;
            LogStatusChange(request, "Waiting for Teacher Approval", adminId, "Admin");
            request.Status = "Waiting for Teacher Approval";
            request.ScheduledAt = DateTime.UtcNow;
            request.UpdatedBy = adminId;

            await _context.SaveChangesAsync();

            await _auditService.LogAsync("TutoringRequests", "Schedule",
                $"Admin scheduled request #{requestId}: {room.Name}, {day.DayName}, {slot.Label}", adminId);

            // Fetch email data before fire-and-forget (DbContext is scoped and may be disposed inside Task.Run)
            var teacher = await _context.Users.FindAsync(request.AssignedTeacherId);
            var student = request.StudentId.HasValue
                ? await _context.Users.FindAsync(request.StudentId.Value)
                : null;
            var subjectEntity = await _context.Subjects.FindAsync(request.SubjectId);

            if (teacher?.Email != null)
            {
                var teacherEmail = teacher.Email;
                var teacherName = $"{teacher.FirstName} {teacher.LastName}";
                var studentName = student != null ? $"{student.FirstName} {student.LastName}" : "Enrolled Student";
                var subjectName = subjectEntity?.Name ?? "Tutoring Session";
                var roomName = room.Name;
                var dayName = day.DayName;
                var timeSlotLabel = $"{slot.StartTime} – {slot.EndTime}";

                // Notify the teacher by email — try automation, fall back to direct EmailService
                try
                {
                    var assigned = await _automationService.TriggerAndSendImmediatelyAsync("SessionAssigned", new Dictionary<string, object>
                    {
                        { "Email", teacherEmail },
                        { "FirstName", teacherName },
                        { "TeacherName", teacherName },
                        { "StudentName", studentName },
                        { "SubjectName", subjectName },
                        { "RoomName", roomName },
                        { "DayName", dayName },
                        { "TimeSlot", timeSlotLabel }
                    });
                    if (!assigned)
                        await _emailService.SendScheduleAssignedEmailAsync(teacherEmail, teacherName, studentName, subjectName, roomName, dayName, timeSlotLabel);
                }
                catch { /* non-fatal */ }
            }

            return await GetRequestByIdAsync(requestId);
        }

        public async Task<bool> DeleteRequestAsync(int id, int? currentUserId)
        {
            var request = await _context.TutoringRequests
                .FirstOrDefaultAsync(t => t.Id == id && t.DeletedAt == null);

            if (request == null) return false;

            request.DeletedAt = DateTime.UtcNow;
            request.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();

            await _auditService.LogAsync("TutoringRequests", "Delete",
                $"Soft deleted tutoring request #{id}", currentUserId);

            return true;
        }

        public async Task<bool> RestoreRequestAsync(int id, int? currentUserId)
        {
            var request = await _context.TutoringRequests
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(t => t.Id == id && t.DeletedAt != null);

            if (request == null) return false;

            request.DeletedAt = null;
            request.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();

            await _auditService.LogAsync("TutoringRequests", "Restore",
                $"Restored tutoring request #{id}", currentUserId);

            return true;
        }

        // ==================== Admin Create Request ====================

        public async Task<TutoringRequestResponseDto> CreateAdminRequestAsync(CreateAdminTutoringRequestDto dto, int adminId)
        {
            // Validate referenced entities exist
            var building = await _context.Buildings.FirstOrDefaultAsync(b => b.Id == dto.BuildingId && b.DeletedAt == null);
            if (building == null) throw new InvalidOperationException("Building not found");

            var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == dto.DepartmentId && d.DeletedAt == null);
            if (department == null) throw new InvalidOperationException("Department not found");

            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Id == dto.SubjectId && s.DeletedAt == null);
            if (subject == null) throw new InvalidOperationException("Subject not found");

            var request = new TutoringRequest
            {
                StudentId = null, // No student yet — will be assigned when a student enrolls
                BuildingId = dto.BuildingId,
                DepartmentId = dto.DepartmentId,
                SubjectId = dto.SubjectId,
                Message = dto.Message,
                Priority = dto.Priority,
                Status = "Pending Teacher Interest",
                IsAdminCreated = true,
                CreatedBy = adminId,
                UpdatedBy = adminId
            };

            _context.TutoringRequests.Add(request);
            await _context.SaveChangesAsync();

            LogStatusChange(request, "Pending Teacher Interest", adminId, "Admin");
            await _context.SaveChangesAsync();

            await _auditService.LogAsync("TutoringRequests", "AdminCreate",
                $"Admin created tutoring request for {subject.Name} at {building.Name}", adminId);

            return (await GetRequestByIdAsync(request.Id))!;
        }

        // ==================== Student Enrollment (for admin-created requests) ====================

        public async Task<PagedResultDto<TutoringRequestListDto>> GetAvailableSessionsForStudentAsync(int studentId, PaginationDto pagination)
        {
            var query = _context.TutoringRequests
                .Include(t => t.Building)
                .Include(t => t.Department)
                .Include(t => t.Subject)
                .Include(t => t.AssignedTeacher)
                .Include(t => t.Room)
                .Include(t => t.AvailableDay)
                .Include(t => t.AvailableTimeSlot)
                .Where(t => t.IsAdminCreated
                    && t.Status == "Pending Student Interest"
                    && t.StudentId == null
                    && t.DeletedAt == null)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var search = pagination.SearchTerm.ToLower();
                query = query.Where(t =>
                    t.Subject.Name.ToLower().Contains(search) ||
                    t.Building.Name.ToLower().Contains(search) ||
                    t.Department.Name.ToLower().Contains(search));
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(t => t.CreatedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(t => new TutoringRequestListDto
                {
                    Id = t.Id,
                    StudentName = null,
                    BuildingId = t.Building.Id,
                    BuildingName = t.Building.Name,
                    DepartmentName = t.Department.Name,
                    SubjectName = t.Subject.Name,
                    Priority = t.Priority,
                    Status = t.Status,
                    AssignedTeacherName = t.AssignedTeacher != null
                        ? $"{t.AssignedTeacher.FirstName} {t.AssignedTeacher.LastName}" : null,
                    IsAdminCreated = true,
                    CreatedAt = t.CreatedAt,
                    RoomName = t.Room != null ? t.Room.Name : null,
                    DayName = t.AvailableDay != null ? t.AvailableDay.DayName : null,
                    TimeSlotLabel = t.AvailableTimeSlot != null ? t.AvailableTimeSlot.Label : null
                })
                .ToListAsync();

            return new PagedResultDto<TutoringRequestListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<bool> StudentEnrollAsync(int requestId, int studentId)
        {
            var request = await _context.TutoringRequests
                .FirstOrDefaultAsync(t => t.Id == requestId && t.DeletedAt == null);

            if (request == null) throw new InvalidOperationException("Request not found");
            if (!request.IsAdminCreated)
                throw new InvalidOperationException("This is not an admin-created request");
            if (request.Status != "Pending Student Interest")
                throw new InvalidOperationException("This session is not accepting student enrollment");
            if (request.StudentId != null)
                throw new InvalidOperationException("A student has already enrolled in this session");
            if (!request.AvailableDayId.HasValue || !request.AvailableTimeSlotId.HasValue)
                throw new InvalidOperationException("Session schedule is incomplete");

            var studentConflict = await HasStudentScheduleConflictAsync(
                studentId,
                request.AvailableDayId.Value,
                request.AvailableTimeSlotId.Value,
                request.Id);
            if (studentConflict)
                throw new InvalidOperationException("You already have a session at this day and time");

            request.StudentId = studentId;
            LogStatusChange(request, "Confirmed", studentId, "Student");
            request.Status = "Confirmed";
            request.ConfirmedAt = DateTime.UtcNow;
            request.UpdatedBy = studentId;
            await _context.SaveChangesAsync();

            // Option B: send confirmation emails to both parties
            await SendConfirmationEmailsAsync(request);

            // Promote Lead → Customer on first confirmed session
            await PromoteLeadToCustomerAsync(studentId, requestId);

            await _auditService.LogAsync("TutoringRequests", "StudentEnroll",
                $"Student #{studentId} enrolled in admin-created request #{requestId}", studentId);

            return true;
        }

        // ==================== Helper: Confirmation Emails ====================

        /// <summary>
        /// Sends schedule confirmation emails to both teacher and student.
        /// Loads navigation properties if not already loaded.
        /// </summary>
        private async Task SendConfirmationEmailsAsync(TutoringRequest request)
        {
            try
            {
                // Ensure navigation properties are loaded
                if (request.AssignedTeacher == null && request.AssignedTeacherId.HasValue)
                    await _context.Entry(request).Reference(r => r.AssignedTeacher).LoadAsync();
                if (request.Student == null && request.StudentId.HasValue)
                    await _context.Entry(request).Reference(r => r.Student).LoadAsync();
                if (request.Subject == null)
                    await _context.Entry(request).Reference(r => r.Subject).LoadAsync();
                if (request.AvailableDay == null && request.AvailableDayId.HasValue)
                    await _context.Entry(request).Reference(r => r.AvailableDay).LoadAsync();
                if (request.AvailableTimeSlot == null && request.AvailableTimeSlotId.HasValue)
                    await _context.Entry(request).Reference(r => r.AvailableTimeSlot).LoadAsync();

                var teacherName = request.AssignedTeacher != null
                    ? $"{request.AssignedTeacher.FirstName} {request.AssignedTeacher.LastName}"
                    : "Assigned Teacher";
                var studentName = request.Student != null
                    ? $"{request.Student.FirstName} {request.Student.LastName}"
                    : "Enrolled Student";
                var subjectName = request.Subject?.Name ?? "Tutoring Session";
                var dayName    = request.AvailableDay?.DayName ?? "Scheduled Day";
                var timeSlot   = request.AvailableTimeSlot != null
                    ? $"{request.AvailableTimeSlot.StartTime} – {request.AvailableTimeSlot.EndTime}"
                    : "Scheduled Time";
                var startDate  = ComputeStartDate(request.ConfirmedAt ?? DateTime.UtcNow, dayName);

                // Email the teacher — try automation first, fall back to direct EmailService
                if (request.AssignedTeacher?.Email is { } teacherEmail)
                {
                    var teacherAutomated = await _automationService.TriggerAndSendImmediatelyAsync("SessionConfirmed", new Dictionary<string, object>
                    {
                        { "Email", teacherEmail },
                        { "FirstName", teacherName },
                        { "RecipientName", teacherName },
                        { "TeacherName", teacherName },
                        { "StudentName", studentName },
                        { "SubjectName", subjectName },
                        { "DayName", dayName },
                        { "TimeSlot", timeSlot },
                        { "StartDate", startDate.ToString("dddd, MMMM d, yyyy") }
                    });
                    if (!teacherAutomated)
                        await _emailService.SendScheduleConfirmedEmailAsync(teacherEmail, teacherName, teacherName, studentName, subjectName, dayName, timeSlot, startDate);
                }

                // Email the student/lead — try automation first, fall back to direct EmailService
                if (request.Student?.Email is { } studentEmail)
                {
                    var studentAutomated = await _automationService.TriggerAndSendImmediatelyAsync("SessionConfirmed", new Dictionary<string, object>
                    {
                        { "Email", studentEmail },
                        { "FirstName", studentName },
                        { "RecipientName", studentName },
                        { "TeacherName", teacherName },
                        { "StudentName", studentName },
                        { "SubjectName", subjectName },
                        { "DayName", dayName },
                        { "TimeSlot", timeSlot },
                        { "StartDate", startDate.ToString("dddd, MMMM d, yyyy") }
                    });
                    if (!studentAutomated)
                        await _emailService.SendScheduleConfirmedEmailAsync(studentEmail, studentName, teacherName, studentName, subjectName, dayName, timeSlot, startDate);
                }
            }
            catch (Exception ex)
            {
                // Email failure must never break the confirmation flow
                _logger.LogWarning(ex, "[SendConfirmationEmailsAsync] Non-fatal email error for request {RequestId}", request.Id);
            }
        }

        /// <summary>
        /// Returns the next date for the given weekday that is at least 7 days from confirmedAt.
        /// </summary>
        private static DateTime ComputeStartDate(DateTime confirmedAt, string dayName)
        {
            var dayMap = new Dictionary<string, DayOfWeek>(StringComparer.OrdinalIgnoreCase)
            {
                ["Sunday"]    = DayOfWeek.Sunday,
                ["Monday"]    = DayOfWeek.Monday,
                ["Tuesday"]   = DayOfWeek.Tuesday,
                ["Wednesday"] = DayOfWeek.Wednesday,
                ["Thursday"]  = DayOfWeek.Thursday,
                ["Friday"]    = DayOfWeek.Friday,
                ["Saturday"]  = DayOfWeek.Saturday,
            };

            if (!dayMap.TryGetValue(dayName, out var targetDow))
                return confirmedAt.AddDays(7); // fallback

            // Start looking from 7 days after confirmation
            var candidate = confirmedAt.Date.AddDays(7);
            while (candidate.DayOfWeek != targetDow)
                candidate = candidate.AddDays(1);

            return candidate;
        }

        // ==================== Role Promotion ====================

        private async Task PromoteLeadToCustomerAsync(int studentId, int tutoringRequestId)
        {
            var leadRole = await _context.Roles
                .FirstOrDefaultAsync(r => r.Name == "Lead" && r.DeletedAt == null);
            var customerRole = await _context.Roles
                .FirstOrDefaultAsync(r => r.Name == "Customer" && r.DeletedAt == null);

            if (leadRole == null || customerRole == null) return;

            var userLeadRole = await _context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == studentId && ur.RoleId == leadRole.Id);

            if (userLeadRole == null) return; // Not a Lead — no promotion needed

            _context.UserRoles.Remove(userLeadRole);

            var alreadyCustomer = await _context.UserRoles
                .AnyAsync(ur => ur.UserId == studentId && ur.RoleId == customerRole.Id);

            if (!alreadyCustomer)
                _context.UserRoles.Add(new NexUs.Models.Entities.UserRole { UserId = studentId, RoleId = customerRole.Id });

            await _context.SaveChangesAsync();

            // Marketing: mark lead converted + create customer record + trigger automation
            try
            {
                var lead = await _context.Leads.FirstOrDefaultAsync(l => l.UserId == studentId && l.DeletedAt == null);
                await _leadService.MarkConvertedAsync(studentId);
                await _customerService.CreateFromConversionAsync(studentId, lead?.Id, tutoringRequestId);
                var user = await _context.Users.FindAsync(studentId);
                await _automationService.TriggerAsync("LeadConverted", new Dictionary<string, object>
                {
                    { "UserId", studentId },
                    { "Email", user?.Email ?? "" },
                    { "FirstName", user?.FirstName ?? "" }
                });
            }
            catch (Exception)
            {
                // Marketing hook failure must not block role promotion
            }
        }

        // ==================== Status History ====================

        private void LogStatusChange(TutoringRequest request, string toStatus, int? changedByUserId, string changedByRole)
        {
            var history = new TutoringRequestStatusHistory
            {
                TutoringRequestId = request.Id,
                FromStatus = request.Status,
                ToStatus = toStatus,
                ChangedByRole = changedByRole,
                CreatedBy = changedByUserId,
                UpdatedBy = changedByUserId,
            };
            _context.TutoringRequestStatusHistories.Add(history);
        }

        public async Task<List<TutoringRequestStatusHistoryDto>> GetAllStatusHistoryAsync()
        {
            return await _context.TutoringRequestStatusHistories
                .Include(h => h.TutoringRequest)
                    .ThenInclude(r => r.Subject)
                .Include(h => h.TutoringRequest)
                    .ThenInclude(r => r.Building)
                .Include(h => h.TutoringRequest)
                    .ThenInclude(r => r.Student)
                .Include(h => h.CreatedByUser)
                .Where(h => h.DeletedAt == null && h.TutoringRequest.DeletedAt == null)
                .OrderByDescending(h => h.CreatedAt)
                .Select(h => new TutoringRequestStatusHistoryDto
                {
                    Id = h.Id,
                    TutoringRequestId = h.TutoringRequestId,
                    SubjectName = h.TutoringRequest.Subject.Name,
                    StudentName = h.TutoringRequest.Student != null
                        ? h.TutoringRequest.Student.FirstName + " " + h.TutoringRequest.Student.LastName
                        : null,
                    BuildingName = h.TutoringRequest.Building.Name,
                    IsAdminCreated = h.TutoringRequest.IsAdminCreated,
                    FromStatus = h.FromStatus,
                    ToStatus = h.ToStatus,
                    ChangedByRole = h.ChangedByRole,
                    ChangedByName = h.CreatedByUser != null
                        ? h.CreatedByUser.FirstName + " " + h.CreatedByUser.LastName
                        : null,
                    ChangedAt = h.CreatedAt,
                })
                .ToListAsync();
        }

        private async Task<bool> HasStudentScheduleConflictAsync(int studentId, int availableDayId, int availableTimeSlotId, int excludeRequestId)
        {
            var activeStatuses = new[] { "Confirmed", "Waiting for Teacher Approval", "Teacher Assigned" };

            return await _context.TutoringRequests
                .AnyAsync(t => t.Id != excludeRequestId
                    && t.StudentId == studentId
                    && t.AvailableDayId == availableDayId
                    && t.AvailableTimeSlotId == availableTimeSlotId
                    && activeStatuses.Contains(t.Status)
                    && t.DeletedAt == null);
        }

        public async Task<ConflictCheckResultDto> GetConflictDataAsync(int teacherId, int excludeRequestId)
        {
            // Include all statuses where a teacher/room is already committed
            var activeStatuses = new[] { "Confirmed", "Waiting for Teacher Approval", "Teacher Assigned" };

            var activeSessions = await _context.TutoringRequests
                .Where(t => t.Id != excludeRequestId
                    && t.DeletedAt == null
                    && activeStatuses.Contains(t.Status)
                    && t.AvailableDayId != null
                    && t.AvailableTimeSlotId != null)
                .Select(t => new
                {
                    t.AssignedTeacherId,
                    t.RoomId,
                    DayId = t.AvailableDayId!.Value,
                    TimeSlotId = t.AvailableTimeSlotId!.Value,
                })
                .ToListAsync();

            var teacherBusy = activeSessions
                .Where(t => t.AssignedTeacherId == teacherId)
                .Select(t => new BusySlotDto { DayId = t.DayId, TimeSlotId = t.TimeSlotId })
                .ToList();

            var roomBusy = activeSessions
                .Where(t => t.RoomId != null)
                .Select(t => new BusyRoomSlotDto { RoomId = t.RoomId!.Value, DayId = t.DayId, TimeSlotId = t.TimeSlotId })
                .ToList();

            // Fetch teacher's availability settings
            var availabilityRows = await _context.TeacherAvailabilities
                .Where(a => a.TeacherId == teacherId && a.DeletedAt == null)
                .Select(a => new { a.AvailableDayId, a.AvailableTimeSlotId })
                .ToListAsync();

            var teacherAvailableSlots = availabilityRows
                .Select(a => new TeacherAvailableSlotDto { DayId = a.AvailableDayId, TimeSlotId = a.AvailableTimeSlotId })
                .ToList();

            var teacherAvailableDayIds = availabilityRows
                .Select(a => a.AvailableDayId)
                .Distinct()
                .ToList();

            return new ConflictCheckResultDto
            {
                TeacherBusy = teacherBusy,
                RoomBusy = roomBusy,
                TeacherAvailableSlots = teacherAvailableSlots,
                TeacherAvailableDayIds = teacherAvailableDayIds,
            };
        }
    }
}
