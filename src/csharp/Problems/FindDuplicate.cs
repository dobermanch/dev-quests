//https://leetcode.com/problems/find-the-duplicate-number/

namespace LeetCode.Problems;

public sealed class FindDuplicate : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindDuplicate))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,3,4,2,2]").Result(2))
          .Add(it => it.ParamArray("[3,1,3,4,2]").Result(3));

    private int Solution(int[] nums)
    {
        var slow = nums[0];
        var fast = nums[0];
        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        fast = nums[0];

        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }

    private int Solution1(int[] nums)
    {
        var map = new HashSet<int>();
        foreach (var num in nums)
        {
            if (map.Contains(num))
            {
                return num;
            }

            map.Add(num);
        }

        return 0;
    }

    private int Solution2(int[] nums)
    {
        var result = nums[0];
        for (int i = 0; i < nums.Length; i++)
        {
            var index = Math.Abs(nums[i]);
            if (nums[index] < 0)
            {
                result = index;
                break;
            }

            nums[index] *= -1;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = Math.Abs(nums[i]);
        }

        return result;
    }
}