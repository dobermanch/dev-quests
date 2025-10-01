namespace RateLimiter.Limiter.Rules;

public sealed class LimiterRuleProvider(IReadOnlyCollection<LimiterRule> rules) : ILimiterRuleProvider
{
    public IReadOnlyCollection<LimiterRule> GetRules(string key)
    {
        LimiterRule[] endpoints = rules
            .Where(it => it.Endpoint == key)
            .ToArray();

        return endpoints;
    }
}
