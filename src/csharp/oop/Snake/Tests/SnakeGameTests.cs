using Snake.Game;

namespace Snake.Tests;

public class SnakeGameTests
{
    [Fact]
    public void Test()
    {
        var game = new SnakeGame(6);


        game.GameLoop();
        game.UpdateDirection(Direction.Up);
        game.GameLoop();



    }
}
