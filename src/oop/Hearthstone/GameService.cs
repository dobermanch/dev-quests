using Hearthstone.Game;
using Hearthstone.Renders;
using Microsoft.Extensions.Hosting;

namespace Hearthstone;

class GameService(GameRender render, IGame game, IHost hostLifetime) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await render.RenderGameAsync(game, stoppingToken);

        for (var i = 0; i < 2; i++)
        {
            var name = render.InputUserName($"Player {i + 1}");
            await game.AddPlayerAsync(name, stoppingToken);
        }

        await game.StartAsync(stoppingToken);

        while (!stoppingToken.IsCancellationRequested && game.State == GameState.InProgress)
        {
            await render.RenderGameAsync(game, stoppingToken);

            string? key = render.ReadInput();
            if (int.TryParse(key, out var index) && index > 0 && index <= game.CurrentPlayer.Hand.Count)
            {
                await game.CurrentPlayer.PlayCardAsync(game.CurrentPlayer.Hand[index - 1], stoppingToken);
            }
            else if (key == "x")
            {
                await game.CurrentPlayer.EndTurnAsync(stoppingToken);
            }
            else if (key == "s")
            {
                await game.StopAsync(stoppingToken);
            }
        }

        if (!stoppingToken.IsCancellationRequested)
        {
            await render.RenderGameAsync(game, stoppingToken);
            _ = hostLifetime.StopAsync(stoppingToken);
        }
    }
}