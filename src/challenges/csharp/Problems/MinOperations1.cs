//https://leetcode.com/problems/minimum-number-of-operations-to-make-array-empty

namespace LeetCode.Problems;

public sealed class MinOperations1 : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinOperations1))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[14,12,14,14,12,14,14,12,12,12,12,14,14,12,14,14,14,12,12]").Result(7))
          .Add(it => it.ParamArray("[2,3,3,2,2,4,2,3,4]").Result(4))
          .Add(it => it.ParamArray("[2,1,2,2,3,3]").Result(-1));

    private int Solution(int[] nums)
    {
        var map = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            map[nums[i]] = map.GetValueOrDefault(nums[i], 0) + 1;
        }

        var result = 0;
        foreach (var item in map)
        {
            if (item.Value == 1)
            {
                return -1;
            }

            result += item.Value / 3 + (item.Value % 3 == 0 ? 0 : 1);
        }

        return result;
    }
}