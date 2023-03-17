//https://leetcode.com/problems/majority-element

namespace LeetCode.Problems;

public sealed class MajorityElement : ProblemBase
{
    [Theory]
    [ClassData(typeof(MajorityElement))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => AddSolutions(nameof(Solution1))
          .Add(it => it.ParamArray("[3,2,3]").Result(3))
          .Add(it => it.ParamArray("[2,2,1,1,1,2,2]").Result(2));

    private int Solution(int[] nums)
    {
        var result = 0;
        var count = 0;

        foreach (var num in nums)
        {
            if (count == 0)
            {
                result = num;
            }

            count += num == result ? 1 : -1;
        }

        return result;
    }

    private int Solution1(int[] nums)
    {
        var target = nums.Length / 2;
        var map = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (!map.ContainsKey(num))
            {
                map.Add(num, 0);
            }

            if (++map[num] > target)
            {
                return num;
            }
        }

        return 0;
    }
}