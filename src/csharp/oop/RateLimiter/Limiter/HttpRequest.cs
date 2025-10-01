namespace RateLimiter.Limiter;

public sealed record HttpRequest(string RequestUri, string Ip, string User);
