//https://leetcode.com/problems/k-closest-points-to-origin/

namespace LeetCode.Problems;

public sealed class KClosest : ProblemBase
{
    [Theory]
    [ClassData(typeof(KClosest))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,3],[-2,2]]").Param(1).Result2dArray("[[-2,2]]"))
          .Add(it => it.Param2dArray("[[3,3],[5,-1],[-2,4]]").Param(2).Result2dArray("[[-2,4],[3,3]]"));

    private int[][] Solution(int[][] points, int k)
    {
        var queue = new PriorityQueue<int[], double>();

        foreach (var point in points)
        {
            var dist = Math.Pow(point[0], 2) + Math.Pow(point[1], 2);
            queue.Enqueue(point, dist);
        }

        var result = new int[k][];
        while (queue.Count > 0 && k-- > 0)
        {
            result[k] = queue.Dequeue();
        }

        return result;
    }
}