using RateLimiter.Limiter;
using RateLimiter.Limiter.Rules;
using RateLimiter.Limiter.Strategies;

namespace RateLimiter.Tests;

public class LimiterSystemTests
{
    [Fact]
    public void Test()
    {
        ILimiterSystem<HttpRequest> system = new LimiterSystem(
            new LimiterRuleProvider([
                new LimiterRule("/login", LimiterTargetType.Ip, LimiterStrategyType.FixedWindow, 5, TimeSpan.FromSeconds(5)),
                new LimiterRule("/orders", LimiterTargetType.User, LimiterStrategyType.FixedWindow, 5, TimeSpan.FromSeconds(5))
            ]),
            new LimiterStrategyProvider());

        foreach (var request in Enumerable.Range(0, 10))
        {
            var result = system.AllowRequest(new HttpRequest("/login", "127.0.0.1", "user1"));
            if (request < 5)
            {
                Assert.True(result);
            }
            else
            {
                Assert.False(result);
            }
        }
    }
}
