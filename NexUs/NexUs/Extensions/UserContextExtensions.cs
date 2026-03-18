using System.Security.Claims;

namespace NexUs.Extensions
{
    public static class UserContextExtensions
    {
        /// <summary>
        /// Gets the current user ID from JWT claims
        /// </summary>
        /// <param name="context">The HttpContext</param>
        /// <returns>User ID if found, null otherwise</returns>
        public static int? GetCurrentUserId(this HttpContext context)
        {
            var userIdClaim = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                           ?? context.User?.FindFirst("sub")?.Value
                           ?? context.User?.FindFirst("userId")?.Value;

            if (int.TryParse(userIdClaim, out int userId))
            {
                return userId;
            }

            return null;
        }

        /// <summary>
        /// Gets the current user email from JWT claims
        /// </summary>
        /// <param name="context">The HttpContext</param>
        /// <returns>User email if found, null otherwise</returns>
        public static string? GetCurrentUserEmail(this HttpContext context)
        {
            return context.User?.FindFirst(ClaimTypes.Email)?.Value
                ?? context.User?.FindFirst("email")?.Value;
        }
    }
}
