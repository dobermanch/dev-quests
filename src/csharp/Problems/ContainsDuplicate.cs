//https://leetcode.com/problems/contains-duplicate/

namespace LeetCode.Problems;

public sealed class ContainsDuplicate : ProblemBase
{
    [Theory]
    [ClassData(typeof(ContainsDuplicate))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,3,1]").Result(true))
          .Add(it => it.ParamArray("[1,2,3,4]").Result(false))
          .Add(it => it.ParamArray("[1,1,1,3,3,4,3,2,4,2]").Result(true));

    private bool Solution(int[] nums)
    {
        var set = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (set.Contains(nums[i]))
            {
                return true;
            }

            set.Add(nums[i]);
        }

        return false;
    }
}