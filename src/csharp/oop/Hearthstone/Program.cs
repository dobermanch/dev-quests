using Hearthstone;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateDefaultBuilder();
builder.ConfigureLogging(configure =>
{
    configure.ClearProviders();
    configure.AddDebug();
});
builder.ConfigureServices(services =>
{
    services
        .AddRenders()
        .AddGameServices()
        .AddHostedService<GameService>();
});

var app = builder.Build();

await app.RunAsync();