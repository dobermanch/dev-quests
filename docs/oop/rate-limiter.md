# Rate Limiter

**Topics:** `OOP`

**Solutions:** [`C#`](../../src/csharp/oop/RateLimiter)

## Rules

The rate limiter system should restrict how often clients can access specific endpoints based on configurable rules.
Each rule defines a target endpoint pattern, a key type (like IP address or user ID), a request limit, a time window,
and a strategy (such as fixed window or token bucket). The system must support multiple strategies, allow per-endpoint
customization. It should be thread-safe, extensible, and optionally support distributed storage like Redis for scalability.

## Build and Run

### C#

``` bash
dotnet test ./RateLimiter.csproj
```
