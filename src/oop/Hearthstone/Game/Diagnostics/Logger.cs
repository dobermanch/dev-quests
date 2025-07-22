using Hearthstone.Game.Cards;
using Hearthstone.Game.Players;
using Microsoft.Extensions.Logging;

namespace Hearthstone.Game.Diagnostics;

internal static class Logger
{
    private static readonly Action<ILogger, string, Exception> _gameStarted =
        LoggerMessage.Define<string>(
            LogLevel.Information,
            LogEvents.GameStarted,
            "Game started. Details: [Players={player}]");

    private static readonly Action<ILogger, Exception> _gameStopped =
        LoggerMessage.Define(
            LogLevel.Information,
            LogEvents.GameStopped,
            "Game stopped manually.");

    private static readonly Action<ILogger, string, Exception> _gameAppPlayer =
        LoggerMessage.Define<string>(
            LogLevel.Information,
            LogEvents.GameInit,
            "Added player. Details: [Player={player}]");

    private static readonly Action<ILogger, string, string, int, Exception> _gamePlayCard =
        LoggerMessage.Define<string, string, int>(
            LogLevel.Debug,
            LogEvents.GameInProgress,
            "Player made move. Details: [Player={player}, Card={card} {cardValue}]");

    private static readonly Action<ILogger, string, Exception> _gameEndTurn =
        LoggerMessage.Define<string>(
            LogLevel.Debug,
            LogEvents.GameInProgress,
            "Player finished move. Details: [Player={player}]");

    private static readonly Action<ILogger, string, Exception> _gameStartTurn =
        LoggerMessage.Define<string>(
            LogLevel.Debug,
            LogEvents.GameInProgress,
            "Player started move. Details: [Player={player}]");

    public static void GameAddPlayer(this ILogger logger, IPlayer player)
        => _gameAppPlayer(logger, player.Name, default!);

    public static void GameStarted(this ILogger logger, IGame game)
        => _gameStarted(logger, string.Join(", ", game.Players.Select(it => it.Name)), default!);

    public static void GameStopped(this ILogger logger, IGame game)
        => _gameStopped(logger, default!);

    public static void GamePlayerCard(this ILogger logger, IPlayer player, Card card)
        => _gamePlayCard(logger, player.Name, card.GetType().Name, card.Value, default!);

    public static void GameEndOfTurn(this ILogger logger, IPlayer player)
        => _gameEndTurn(logger, player.Name, default!);

    public static void GameStartTurn(this ILogger logger, IPlayer player)
        => _gameStartTurn(logger, player.Name, default!);
}
