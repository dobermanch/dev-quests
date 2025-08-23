using Hearthstone.Game;
using Hearthstone.Game.Notifications;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace Hearthstone.Renders;

internal sealed class GameRender(IServiceProvider provider) : IRenderProvider
{
    private IDictionary<Type, IRender>? _renders;

    public void Render<T>(T toRender)
    {
        if (_renders is null)
        {
            _renders =
                provider
                    .GetServices<IRender>()
                    .Select(it => (it, it.GetType().BaseType))
                    .Where(it => it.BaseType != null
                           && it.BaseType.IsGenericType
                           && it.BaseType.GetGenericTypeDefinition() == typeof(RenderBase<>))
                    .ToDictionary(it => it.BaseType!.GetGenericArguments()[0], it => it.it);
        }

        var type = toRender!.GetType();
        if (!_renders.ContainsKey(type))
        {
            var baseType = type.BaseType;
            while (baseType != null)
            {
                if (_renders.ContainsKey(baseType))
                {
                    _renders[type] = _renders[baseType];
                    break;
                }

                baseType = baseType.BaseType;
            }
        }

        _renders[type].Render(toRender);
    }

    public async Task RenderGameAsync(IGame game, CancellationToken cancellation)
    {
        Console.Clear();
        Console.OutputEncoding = Encoding.UTF8;

        Render(new GameTitle());

        if (game.State == GameState.InProgress)
        {
            Render(game.CurrentPlayer);

            foreach(var player in game.Players.Where(it => !it.IsCurrent))
            {
                Render(player);
            }

            Render(game.CurrentPlayer.Hand);

            if (game.Notifications.Any())
            {
                Render(game.Notifications);
            }

            RenderCommandLegend(game);
        }
        else if (game.State == GameState.Finished || game.State == GameState.Stopped)
        {
            var stats = await game.GetStatsAsync(cancellation);
            Render(stats);

            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }
    }

    public string InputUserName(string defaultName)
    {
        Console.Write($"Enter player name (default {defaultName}): ");

        var name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            name = defaultName;
        }

        return name;
    }

    public string? ReadInput()
    {
        return Console.ReadLine()?.Trim().ToLower();
    }

    private void RenderCommandLegend(IGame game)
    {
        if (game.Notifications.All(it => it is not NoManaNotification && it is not EmptyHandNotification))
        {
            Console.WriteLine("Enter card number to the play card.");
        }

        Console.WriteLine("Enter 'X' to end your turn.");
        Console.WriteLine("Enter 'S' to stop the game.");
        Console.Write("What is your choice? ");
    }
}
