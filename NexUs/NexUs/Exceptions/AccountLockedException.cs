namespace NexUs.Exceptions;

public class AccountLockedException(int remainingMinutes)
    : Exception($"Too many failed attempts. Try again in {remainingMinutes} minute(s).")
{
    public int RemainingMinutes { get; } = remainingMinutes;
}
