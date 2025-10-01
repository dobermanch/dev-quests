using RateLimiter.Limiter.Strategies;

namespace RateLimiter.Limiter.Rules;

public sealed record LimiterRule(
    string Endpoint,
    LimiterTargetType TargetType,
    LimiterStrategyType StrategyType,
    int Limit,
    TimeSpan Period
);
