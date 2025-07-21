//https://leetcode.com/problems/jump-game-ii/

namespace LeetCode.Problems;

public sealed class Jump : ProblemBase
{
    [Theory]
    [ClassData(typeof(Jump))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[5,9,3,2,1,0,2,3,3,1,0,0]").Result(3))
          .Add(it => it.ParamArray("[2,3,1,1,4]").Result(2))
          .Add(it => it.ParamArray("[2,2,0,1,4]").Result(3))
          .Add(it => it.ParamArray("[2,3,0,1,4]").Result(2))
          .Add(it => it.ParamArray("[0]").Result(0))
        ;

    private int Solution1(int[] nums)
    {
        var result = 0;
        var left = 0;
        var right = 0;
        var max = 0;
        while (right < nums.Length - 1)
        {
            if (left <= right)
            {
                max = Math.Max(left + nums[left], max);
                left++;
            }
            else
            {
                right = max;
                result++;
            }
        }

        return result;
    }

    private int Solution2(int[] nums)
    {
        var map = new int[nums.Length];
        var jumpTo = nums.Length - 1;
        const int infinity = 9999;
        for (var i = jumpTo; i >= 0; i--)
        {
            map[i] = 1;
            if (nums[i] == 0 || i == jumpTo)
            {
                map[i] = infinity;
            }
            else if (i + nums[i] < jumpTo)
            {
                map[i] += map[(i + 1)..(i + nums[i] + 1)].Min();
            }
        }

        return map[0] >= infinity ? 0 : map[0];
    }
}