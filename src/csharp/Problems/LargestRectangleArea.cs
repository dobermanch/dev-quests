//https://leetcode.com/problems/largest-rectangle-in-histogram/

namespace LeetCode.Problems;

public sealed class LargestRectangleArea : ProblemBase
{
    [Theory]
    [ClassData(typeof(LargestRectangleArea))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[4,2]").Result(4))
          .Add(it => it.ParamArray("[1]").Result(1))
          .Add(it => it.ParamArray("[1,1]").Result(2))
          .Add(it => it.ParamArray("[3,6,5,7,4,8,1,0]").Result(20))
          .Add(it => it.ParamArray("[4,2,0,3,2,4,3,4]").Result(10))
          .Add(it => it.ParamArray("[5,4,1,2]").Result(8))
          .Add(it => it.ParamArray("[1,2,3,4,5]").Result(9))
          .Add(it => it.ParamArray("[2,1,5,6,2,3,2,3]").Result(12))
          .Add(it => it.ParamArray("[2,1,5,6,2,3]").Result(10))
          .Add(it => it.ParamArray("[2,4]").Result(4));

    private int Solution(int[] heights)
    {
        var stack = new Stack<(int height, int count)>();
        var result = 0;
        int count;
        foreach (var height in heights)
        {
            count = 0;
            while (stack.Any() && height <= stack.Peek().height)
            {
                var item = stack.Pop();
                count += item.count;
                result = Math.Max(result, item.height * count);
            }

            stack.Push((height, count + 1));
        }

        count = 0;
        while (stack.Any())
        {
            var item = stack.Pop();
            count += item.count;
            result = Math.Max(result, item.height * count);
        }

        return result;
    }
}