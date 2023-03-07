//https://leetcode.com/problems/3sum/

namespace LeetCode.Problems;

public sealed class ThreeSum : ProblemBase
{
    [Theory]
    [ClassData(typeof(ThreeSum))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[-2,0,1,1,2]").Result2dArray("[[-2,0,2],[-2,1,1]]"))
          .Add(it => it.ParamArray("[-1,0,1,2,-1,-4]").Result2dArray("[[-1,-1,2],[-1,0,1]]"))
          .Add(it => it.ParamArray("[0,1,1]").Result2dArray("[]"))
          .Add(it => it.ParamArray("[0,0,0,0]").Result2dArray("[[0,0,0]]"))
          .Add(it => it.ParamArray("[0,0,0]").Result2dArray("[[0,0,0]]"));

    private IList<IList<int>> Solution(int[] nums)
    {
        Array.Sort(nums);

        var result = new List<IList<int>>();
        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i - 1] == nums[i])
            {
                continue;
            }

            if (nums[i] > 0)
            {
                break;
            }

            var left = i + 1;
            var right = nums.Length - 1;
            while (left < right)
            {
                if (left > i + 1 && nums[left - 1] == nums[left])
                {
                    left++;
                    continue;
                }

                var sum = nums[i] + nums[left] + nums[right];
                if (sum == 0)
                {
                    result.Add(new[] { nums[i], nums[left], nums[right] });
                }

                if (sum <= 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        return result;
    }
}