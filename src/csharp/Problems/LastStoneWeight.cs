//https://leetcode.com/problems/last-stone-weight

namespace LeetCode.Problems;

public sealed class LastStoneWeight : ProblemBase
{
    [Theory]
    [ClassData(typeof(LastStoneWeight))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[2,7,4,1,8,1]").Result(1))
          .Add(it => it.ParamArray("[1]").Result(1))
          .Add(it => it.ParamArray("[2, 2]").Result(0))
        ;

    private int Solution(int[] stones)
    {
        var comparer = Comparer<int>.Create((left, right) => right - left);
        var ordered = new PriorityQueue<int, int>(stones.Select(it => (it, it)), comparer);

        while (ordered.Count > 1)
        {
            var right = ordered.Dequeue();
            var left = ordered.Dequeue();

            if (right != left)
            {
                var value = right - left;
                ordered.Enqueue(value, value);
            }
        }

        return ordered.Count > 0 ? ordered.Dequeue() : 0;
    }
}