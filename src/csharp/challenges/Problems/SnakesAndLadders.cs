// https://leetcode.com/problems/snakes-and-ladders

namespace LeetCode.Problems;

public sealed class SnakesAndLadders : ProblemBase
{
    [Theory]
    [ClassData(typeof(SnakesAndLadders))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,1,-1],[1,1,1],[-1,1,1]]").Result(-1))
          .Add(it => it.Param2dArray("[[-1,-1,-1,-1,-1,-1],[-1,-1,-1,-1,-1,-1],[-1,-1,-1,-1,-1,-1],[-1,35,-1,-1,13,-1],[-1,-1,-1,-1,-1,-1],[-1,15,-1,-1,-1,-1]]").Result(4))
          .Add(it => it.Param2dArray("[[-1,1,2,-1],[2,13,15,-1],[-1,10,-1,-1],[-1,6,2,8]]").Result(2))
          .Add(it => it.Param2dArray("[[-1,-1,19,10,-1],[2,-1,-1,6,-1],[-1,17,-1,19,-1],[25,-1,20,-1,-1],[-1,-1,-1,-1,15]]").Result(2))
          .Add(it => it.Param2dArray("[[-1,-1,27,13,-1,25,-1],[-1,-1,-1,-1,-1,-1,-1],[44,-1,8,-1,-1,2,-1],[-1,30,-1,-1,-1,-1,-1],[3,-1,20,-1,46,6,-1],[-1,-1,-1,-1,-1,-1,29],[-1,29,21,33,-1,-1,-1]]").Result(4))
          .Add(it => it.Param2dArray("[[-1,-1,30,14,15,-1],[23,9,-1,-1,-1,9],[12,5,7,24,-1,30],[10,-1,-1,-1,25,17],[32,-1,28,-1,-1,32],[-1,-1,23,-1,13,19]]").Result(2))
          .Add(it => it.Param2dArray("[[-1,-1],[-1,3]]").Result(1));

    private int Solution(int[][] board)
    {
        var oneDBoard = board
            .Reverse()
            .SelectMany((it, index) => index % 2 == 0 ? it : it.Reverse())
            .ToArray();

        var queue = new Queue<(int square, int moves)>();
        var visited = new bool[oneDBoard.Length];

        queue.Enqueue((0, 1));

        const int dieSides = 6;
        while (queue.Count > 0)
        {
            var (square, moves) = queue.Dequeue();
            for (var steps = 1; steps <= dieSides; steps++)
            {
                var moveTo = square + steps;
                if (oneDBoard[moveTo] != -1)
                {
                    moveTo = oneDBoard[moveTo] - 1;
                }

                if (moveTo == oneDBoard.Length - 1)
                {
                    return moves;
                }

                if (!visited[moveTo])
                {
                    queue.Enqueue((moveTo, moves + 1));
                }

                visited[moveTo] = true;
            }
        }

        return -1;
    }
}