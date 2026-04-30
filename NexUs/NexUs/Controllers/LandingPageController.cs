using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Landing;

namespace NexUs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LandingPageController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LandingPageController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("stats")]
    [AllowAnonymous]
    public async Task<ActionResult<ApiResponse<LandingPageStatsDto>>> GetStats()
    {
        try
        {
            var studentRoles = new[] { "Lead", "Customer" };

            var totalStudents = await _context.Users
                .Where(u => u.DeletedAt == null)
                .Where(u => u.UserRoles.Any(ur => studentRoles.Contains(ur.Role!.Name)))
                .CountAsync();

            var totalTutors = await _context.Users
                .Where(u => u.DeletedAt == null)
                .Where(u => u.UserRoles.Any(ur => ur.Role!.Name == "Teacher"))
                .CountAsync();

            var totalRequests = await _context.TutoringRequests
                .Where(r => r.DeletedAt == null)
                .CountAsync();

            var confirmedSessions = await _context.TutoringRequests
                .Where(r => r.DeletedAt == null && r.Status == "Confirmed")
                .CountAsync();

            var successRate = totalRequests > 0
                ? Math.Round((double)confirmedSessions / totalRequests * 100, 1)
                : 0;

            var totalSubjects = await _context.Subjects
                .Where(s => s.DeletedAt == null)
                .CountAsync();

            var stats = new LandingPageStatsDto
            {
                TotalStudents = totalStudents,
                TotalTutors = totalTutors,
                TotalSessions = confirmedSessions,
                TotalSubjects = totalSubjects,
                SuccessRate = successRate
            };

            return Ok(ApiResponse<LandingPageStatsDto>.SuccessResponse(stats, "Landing page stats retrieved successfully"));
        }
        catch (Exception)
        {
            return StatusCode(500, ApiResponse<LandingPageStatsDto>.ErrorResponse("An unexpected error occurred"));
        }
    }

    [HttpGet("feedbacks")]
    [AllowAnonymous]
    public async Task<ActionResult<ApiResponse<List<LandingFeedbackDto>>>> GetFeedbacks()
    {
        try
        {
            var feedbacks = await _context.Feedbacks
                .Include(f => f.Customer)
                .Include(f => f.TutoringRequest)
                    .ThenInclude(t => t.Subject)
                .Where(f => f.DeletedAt == null && f.Rating >= 4 && f.Comment != null && f.Comment != "")
                .OrderByDescending(f => f.CreatedAt)
                .Take(6)
                .Select(f => new LandingFeedbackDto
                {
                    CustomerName = (f.Customer.FirstName + " " + f.Customer.LastName).Trim(),
                    SubjectName = f.TutoringRequest.Subject != null ? f.TutoringRequest.Subject.Name : null,
                    Rating = f.Rating,
                    Comment = f.Comment,
                    CreatedAt = f.CreatedAt
                })
                .ToListAsync();

            return Ok(ApiResponse<List<LandingFeedbackDto>>.SuccessResponse(feedbacks, "Feedbacks retrieved successfully"));
        }
        catch (Exception)
        {
            return StatusCode(500, ApiResponse<List<LandingFeedbackDto>>.ErrorResponse("An unexpected error occurred"));
        }
    }
}
