using Microsoft.EntityFrameworkCore;
using Moq;
using NexUs.Data;
using NexUs.Models.DTO.Feedbacks;
using NexUs.Models.Entities;
using NexUs.Services;
using NexUs.Services.Interfaces;
using NexUs.Utilities;
using Xunit;

namespace NexUs.Tests;

/// <summary>
/// C-2: Verifies that Feedback endpoints enforce ownership —
/// users can only read/update/delete their own feedback.
/// </summary>
public class C2_FeedbackOwnershipTests : IDisposable
{
    private readonly ApplicationDbContext _db;
    private readonly FeedbackService _service;

    private const int OwnerUserId = 1;
    private const int OtherUserId = 2;
    private const int TeacherId = 3;

    public C2_FeedbackOwnershipTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        _db = new ApplicationDbContext(options);

        SeedData();

        var notificationMock = new Mock<INotificationService>();
        _service = new FeedbackService(_db, notificationMock.Object);
    }

    private void SeedData()
    {
        var owner = new User { Id = OwnerUserId, FirstName = "Alice", LastName = "Owner", Email = "alice@test.com" };
        var other = new User { Id = OtherUserId, FirstName = "Bob", LastName = "Other", Email = "bob@test.com" };
        var teacher = new User { Id = TeacherId, FirstName = "Carol", LastName = "Teacher", Email = "carol@test.com" };
        _db.Users.AddRange(owner, other, teacher);

        var subject = new Subject { Id = 1, Name = "Math" };
        _db.Subjects.Add(subject);

        var request = new TutoringRequest
        {
            Id = 1, StudentId = OwnerUserId, SubjectId = 1,
            Status = "Scheduled", AssignedTeacherId = TeacherId
        };
        _db.TutoringRequests.Add(request);

        var sessionLog = new SessionLog
        {
            Id = 1, TutoringRequestId = 1,
            SessionDate = DateTimeHelper.PhilippineNow.AddDays(-1),
            Outcome = "Completed"
        };
        _db.SessionLogs.Add(sessionLog);

        var feedback = new Feedback
        {
            Id = 10, CustomerId = OwnerUserId, TeacherId = TeacherId,
            TutoringRequestId = 1, SessionLogId = 1,
            Rating = 5, Comment = "Great session"
        };
        _db.Feedbacks.Add(feedback);

        _db.SaveChanges();
    }

    [Fact]
    public async Task GetById_Owner_ReturnsOwnFeedback()
    {
        var result = await _service.GetByIdAsync(10, requesterId: OwnerUserId, isAdmin: false);

        Assert.NotNull(result);
        Assert.Equal(10, result.Id);
    }

    [Fact]
    public async Task GetById_OtherUser_ReturnsNull()
    {
        // Before fix: returned the feedback regardless of requester
        var result = await _service.GetByIdAsync(10, requesterId: OtherUserId, isAdmin: false);

        Assert.Null(result);
    }

    [Fact]
    public async Task GetById_Admin_CanAccessAnyFeedback()
    {
        var result = await _service.GetByIdAsync(10, requesterId: OtherUserId, isAdmin: true);

        Assert.NotNull(result);
    }

    [Fact]
    public async Task Update_OtherUser_ThrowsUnauthorized()
    {
        var dto = new UpdateFeedbackDto { Rating = 1, Comment = "Malicious edit" };

        await Assert.ThrowsAsync<UnauthorizedAccessException>(
            () => _service.UpdateAsync(10, dto, userId: OtherUserId, isAdmin: false));
    }

    [Fact]
    public async Task Update_Owner_Succeeds()
    {
        var dto = new UpdateFeedbackDto { Rating = 4, Comment = "Updated comment" };

        var result = await _service.UpdateAsync(10, dto, userId: OwnerUserId, isAdmin: false);

        Assert.NotNull(result);
        Assert.Equal(4, result.Rating);
    }

    [Fact]
    public async Task Delete_OtherUser_ThrowsUnauthorized()
    {
        await Assert.ThrowsAsync<UnauthorizedAccessException>(
            () => _service.DeleteAsync(10, userId: OtherUserId, isAdmin: false));
    }

    [Fact]
    public async Task Delete_Owner_Succeeds()
    {
        var result = await _service.DeleteAsync(10, userId: OwnerUserId, isAdmin: false);

        Assert.True(result);
        // Verify soft delete was applied
        var feedback = await _db.Feedbacks.IgnoreQueryFilters().FirstAsync(f => f.Id == 10);
        Assert.NotNull(feedback.DeletedAt);
    }

    [Fact]
    public async Task Delete_Admin_CanDeleteAnyFeedback()
    {
        var result = await _service.DeleteAsync(10, userId: OtherUserId, isAdmin: true);

        Assert.True(result);
    }

    public void Dispose() => _db.Dispose();
}
