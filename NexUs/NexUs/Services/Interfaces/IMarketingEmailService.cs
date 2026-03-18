namespace NexUs.Services.Interfaces
{
    public interface IMarketingEmailService
    {
        /// <summary>
        /// Sends a queued EmailMessage record via existing IEmailService.
        /// Updates email_messages status + appends email_events lifecycle rows.
        /// </summary>
        Task<bool> SendAsync(int emailMessageId);
    }
}
