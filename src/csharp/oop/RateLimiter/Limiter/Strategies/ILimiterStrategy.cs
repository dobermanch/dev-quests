using RateLimiter.Limiter.Rules;

namespace RateLimiter.Limiter.Strategies;

public interface ILimiterStrategy
{
    bool AllowRequest(string key, LimiterRule rule);
}
