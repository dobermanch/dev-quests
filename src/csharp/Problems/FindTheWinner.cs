//https://leetcode.com/problems/find-the-winner-of-the-circular-game/

namespace LeetCode.Problems;

public sealed class FindTheWinner : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindTheWinner))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param(5).Param(2).Result(3))
          .Add(it => it.Param(6).Param(5).Result(1))
          .Add(it => it.Param(10).Param(7).Result(9));

    private int Solution(int n, int k)
    {
        var players = Enumerable.Range(1, n).ToList();
        var index = k - 1;

        while (players.Count > 1)
        {
            players.RemoveAt(index);
            index = (index + k - 1) % players.Count;
        }

        return players[0];
    }

    private int Solution1(int n, int k)
    {
        var players = new Queue<int>();
        for (int i = 1; i <= n; i++)
        {
            players.Enqueue(i);
        }

        var count = k;
        while (players.Count > 1)
        {
            var player = players.Dequeue();
            if (--count > 0)
            {
                players.Enqueue(player);
            }
            else
            {
                count = k;
            }
        }

        return players.Dequeue();
    }
}