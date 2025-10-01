using RateLimiter.Limiter.Rules;

namespace RateLimiter.Limiter.Strategies;

public sealed class LimiterStrategyProvider : ILimiterStrategyProvider
{
    private readonly Dictionary<LimiterStrategyType, ILimiterStrategy> _strategies = new ()
    {
        {LimiterStrategyType.FixedWindow, new FixedWindowStrategy()}
    };

    public ILimiterStrategy? GetStrategy(LimiterRule rule)
        => _strategies.GetValueOrDefault(rule.StrategyType);
}
