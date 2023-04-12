//https://leetcode.com/problems/car-fleet/

namespace LeetCode.Problems;

public sealed class CarFleet : ProblemBase
{
    [Theory]
    [ClassData(typeof(CarFleet))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param(12).ParamArray("[10,8,0,5,3]").ParamArray("[2,4,1,1,3]").Result(3))
          .Add(it => it.Param(10).ParamArray("[6,8]").ParamArray("[3,2]").Result(2))
          .Add(it => it.Param(10).ParamArray("[3]").ParamArray("[3]").Result(1))
          .Add(it => it.Param(0).ParamArray("[0]").ParamArray("[1]").Result(1))
          .Add(it => it.Param(100).ParamArray("[0,2,4]").ParamArray("[4,2,1]").Result(1));

    private int Solution(int target, int[] position, int[] speed)
    {
        var queue = new PriorityQueue<float, int>();
        for (int i = 0; i < position.Length; i++)
        {
            var time = (target - position[i]) / (float)speed[i];
            queue.Enqueue(time, -position[i]);
        }

        var result = 0;
        var previousTime = -1f;
        while (queue.Count > 0)
        {
            var time = queue.Dequeue();
            if (time > previousTime)
            {
                result++;
                previousTime = time;
            }
        }

        return result;
    }
}