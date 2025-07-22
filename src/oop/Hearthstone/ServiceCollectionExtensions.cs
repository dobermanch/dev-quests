using System.Reflection;
using Hearthstone.Game;
using Hearthstone.Game.Decks.Providers;
using Hearthstone.Game.Decks.Shuffle;
using Hearthstone.Game.Players;
using Hearthstone.Game.Players.Selectors;
using Hearthstone.Renders;
using Microsoft.Extensions.DependencyInjection;

namespace Hearthstone;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGameServices(this IServiceCollection services) 
        => services
            .AddSingleton<IGame, Game.Game>()
            .AddTransient<PlayerOptions>()
            .AddTransient<IDeckProvider, DefaultDeckProvider>()
            .AddTransient<IPlayerSelector, DefaultPlayerSelector>()
            .AddTransient<ICardShuffle, DefaultCardShuffle>()
            .AddTransient<IDeckProvider, DefaultDeckProvider>()
            .AddTransient<GameOptions>();
    
    public static IServiceCollection AddRenders(this IServiceCollection services)
    {
        services.AddSingleton<GameRender>();
        services.AddSingleton<IRenderProvider>(provider => provider.GetRequiredService<GameRender>());

        var renders =
            Assembly
               .GetAssembly(typeof(GameRender))
               !.GetTypes()
               .Where(t => t.BaseType != null
                       && t.BaseType.IsGenericType
                       && t.BaseType.GetGenericTypeDefinition() == typeof(RenderBase<>))
               .ToList();

        foreach (var render in renders)
        {
            services.Add(new ServiceDescriptor(typeof(IRender), render, ServiceLifetime.Transient));
        }

        return services;
    }
}
