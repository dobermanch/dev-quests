using RateLimiter.Limiter.Rules;
using RateLimiter.Limiter.Strategies;

namespace RateLimiter.Limiter;

public sealed class LimiterSystem(ILimiterRuleProvider limiterRuleProvider, ILimiterStrategyProvider limiterStrategyProvider) : ILimiterSystem<HttpRequest>
{
    public bool AllowRequest(HttpRequest request)
    {
        IReadOnlyCollection<LimiterRule> rules = limiterRuleProvider.GetRules(request.RequestUri);

        foreach (var rule in rules)
        {
            var strategy = limiterStrategyProvider.GetStrategy(rule);
            if (strategy == null)
            {
                continue;
            }

            string key = $"{rule.TargetType}:{ExtractKey(request, rule)}:{rule.Endpoint}";
            if (!strategy.AllowRequest(key, rule))
            {
                return false;
            }
        }

        return true;
    }

    private string ExtractKey(HttpRequest request, LimiterRule rule)
    {
        return rule.TargetType switch
        {
            LimiterTargetType.Ip => request.Ip,
            LimiterTargetType.User => request.User,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
