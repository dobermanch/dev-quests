namespace RateLimiter.Limiter.Rules;

public interface ILimiterRuleProvider
{
    IReadOnlyCollection<LimiterRule> GetRules(string key);
}
