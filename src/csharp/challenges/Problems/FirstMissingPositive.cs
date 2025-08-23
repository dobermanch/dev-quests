//https://leetcode.com/problems/first-missing-positive/description/

namespace LeetCode.Problems;

public sealed class FirstMissingPositive : ProblemBase
{
    [Theory]
    [ClassData(typeof(FirstMissingPositive))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,0]").Result(3))
          .Add(it => it.ParamArray("[3,4,-1,1]").Result(2))
          .Add(it => it.ParamArray("[3,4,-1,1,2,-2]").Result(5))
          .Add(it => it.ParamArray("[3,4,-1,1,2,6]").Result(5))
          .Add(it => it.ParamArray("[3,4,-1,1,2]").Result(5))
          .Add(it => it.ParamArray("[7,8,9,11,12]").Result(1));

    private int Solution(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            while (nums[i] > 0
                && nums[i] <= nums.Length
                && nums[i] != nums[nums[i] - 1])
            {
                (nums[i], nums[nums[i] - 1]) = (nums[nums[i] - 1], nums[i]);
            }
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != i + 1)
            {
                return i + 1;
            }
        }

        return nums.Length + 1;
    }

    private int Solution1(int[] nums)
    {
        var set = nums.Where(it => it > 0).ToHashSet();
        for (var i = 1; i <= set.Count; i++)
        {
            if (!set.Contains(i))
            {
                return i;
            }
        }

        return set.Count + 1;
    }
}