using RateLimiter.Limiter.Rules;

namespace RateLimiter.Limiter.Strategies;

public interface ILimiterStrategyProvider
{
    ILimiterStrategy? GetStrategy(LimiterRule rule);
}
