namespace RateLimiter.Limiter;

public interface ILimiterSystem<in T>
{
    bool AllowRequest(T request);
}
