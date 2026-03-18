namespace NexUs.Utilities
{
    public static class DateTimeHelper
    {
        // Singapore Standard Time is the Windows timezone ID for UTC+8 (same as Philippine Standard Time)
        private static readonly TimeZoneInfo PhilippineTimeZone = 
            TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");

        /// <summary>
        /// Gets the current date and time in Philippine Standard Time (UTC+8)
        /// </summary>
        public static DateTime PhilippineNow => 
            TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, PhilippineTimeZone);
    }
}
