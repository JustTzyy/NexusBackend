namespace NexUs.Services.Interfaces
{
    public interface IEmailService
    {
        /// <summary>
        /// Sends a welcome email to a newly created user with their credentials and assigned roles
        /// </summary>
        /// <param name="userEmail">User's email address</param>
        /// <param name="userName">User's full name</param>
        /// <param name="defaultPassword">Generated default password</param>
        /// <param name="roles">List of assigned role names</param>
        /// <returns>True if email sent successfully, false otherwise</returns>
        Task<bool> SendWelcomeEmailAsync(string userEmail, string userName, string defaultPassword, List<string> roles);
        
        /// <summary>
        /// Sends a password reset email with a reset link
        /// </summary>
        Task<bool> SendPasswordResetEmailAsync(string userEmail, string userName, string resetLink);

        /// <summary>
        /// Sends an OTP verification email for registration
        /// </summary>
        Task<bool> SendOtpVerificationEmailAsync(string userEmail, string otpCode);

        /// <summary>
        /// Sends a welcome email to a self-registered user (email or Google sign-up)
        /// </summary>
        Task<bool> SendWelcomeNewUserEmailAsync(string userEmail, string userName);

        /// <summary>
        /// Sends a schedule confirmation email to a recipient (teacher or student/lead)
        /// when a tutoring session is confirmed.
        /// </summary>
        Task<bool> SendScheduleConfirmedEmailAsync(
            string recipientEmail, string recipientName,
            string teacherName, string studentName,
            string subjectName, string dayName, string timeSlot,
            DateTime startDate);

        /// <summary>
        /// Notifies the teacher that an admin has assigned a session to them and asks them to confirm.
        /// </summary>
        Task<bool> SendScheduleAssignedEmailAsync(
            string teacherEmail, string teacherName,
            string studentName, string subjectName,
            string roomName, string dayName, string timeSlot);

        /// <summary>
        /// Notifies a recipient (student or teacher) that an admin has cancelled a session, including the reason.
        /// </summary>
        Task<bool> SendAdminCancelEmailAsync(
            string recipientEmail, string recipientName,
            string teacherName, string studentName,
            string subjectName, string buildingName,
            string cancellationReason, DateTime cancelledAt);

        /// <summary>
        /// Sends a 24-hour reminder email to a recipient (teacher or student) before their scheduled session.
        /// </summary>
        Task<bool> SendSessionReminderEmailAsync(
            string recipientEmail, string recipientName,
            string teacherName, string studentName,
            string subjectName, string dayName, string timeSlot,
            string roomName, string buildingName,
            DateTime sessionDate);
    }
}
