using TicTacToe.Game;
using Xunit.Abstractions;

namespace TicTacToe.Tests;

public class TicTacToeTests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void ShouldParkVehicleAndCalculateCorrectPrice()
    {
        var game = new Game.TicTacToe();

        var player2 = new Player("Player 2", '0');
        var player1 = new Player("Player 1", 'X');

        game.StartGame(player1, player2);

        game.MakeMove(player1, 1, 1);
        game.MakeMove(player2, 0, 1);
        game.MakeMove(player1, 2, 0);
        game.MakeMove(player2, 0, 2);
        game.MakeMove(player1, 0, 0);
        game.MakeMove(player2, 1, 0);
        game.MakeMove(player1, 2, 2);

        if (game.Status.Sate == GameState.GameEnded)
        {
            if (game.Status.Winner is not null)
            {
                var score = game.GetPlayerScore(game.Status.Winner.Value).Score;
                testOutputHelper.WriteLine($"The '{game.Status.Winner.Value.Name}' player won the game. The players score is {score}");
            }

            if (game.Status.IsDraw)
            {
                testOutputHelper.WriteLine($"The game has ended with draw");
            }

            testOutputHelper.WriteLine("The game ended");
        }

        var scores = game.GetScoreBoard();
        foreach (var score in scores)
        {
            testOutputHelper.WriteLine($"{score.Player}: {score.Score}");
        }
    }
}
