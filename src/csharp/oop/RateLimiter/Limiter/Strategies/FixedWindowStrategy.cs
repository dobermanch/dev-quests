using System.Collections.Concurrent;
using RateLimiter.Limiter.Rules;

namespace RateLimiter.Limiter.Strategies;

public sealed class FixedWindowStrategy : ILimiterStrategy
{
    private readonly ConcurrentDictionary<string, (int Count, DateTime WindowStart)> _counters = new();

    public bool AllowRequest(string key, LimiterRule rule)
    {
        var now = DateTime.UtcNow;
        var windowStart = now - rule.Period;

        var entry = _counters.GetOrAdd(key, _ => (0, now));
        if (entry.WindowStart < windowStart)
        {
            _counters[key] = (1, now);
            return true;
        }

        if (entry.Count < rule.Limit)
        {
            _counters[key] = (entry.Count + 1, entry.WindowStart);
            return true;
        }

        return false;
    }
}
