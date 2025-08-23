//https://leetcode.com/problems/3sum-closest/

namespace LeetCode.Problems;

public sealed class ThreeSumClosest : ProblemBase
{
    [Theory]
    [ClassData(typeof(ThreeSumClosest))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[0,0,0]").Param(1).Result(0))
          .Add(it => it.ParamArray("[0,3,97,102,200]").Param(300).Result(300))
          .Add(it => it.ParamArray("[2,2,4,5,6,7,7]").Param(14).Result(14))
          .Add(it => it.ParamArray("[4,0,5,-5,3,3,0,-4,-5]").Param(-2).Result(-2))
          .Add(it => it.ParamArray("[-1,2,1,-4]").Param(1).Result(2))
          .Add(it => it.ParamArray("[1,1,1,0]").Param(-100).Result(2))
          .Add(it => it.ParamArray("[4,0,5,3,3,0,-4]").Param(-2).Result(-1))
          .Add(it => it.ParamArray("[40,-53,36,89,-38,-51,80,11,-10,76,-30,46,-39,-15,4,72,83,-25,33,-69,-73,-100,-23,-37,-13,-62,-26,-54,36,-84,-65,-51,11,98,-21,49,51,78,-58,-40,95,-81,41,-17,-70,83,-88,-14,-75,-10,-44,-21,6,68,-81,-1,41,-61,-82,-24,45,19,6,-98,11,9,-66,50,-97,-2,58,17,51,-13,88,-16,-77,31,35,98,-2,0,-70,6,-34,-8,78,22,-1,-93,-39,-88,-77,-65,80,91,35,-15,7,-37,-96,65,3,33,-22,60,1,76,-32,22]").Param(292).Result(291));

    private int Solution(int[] nums, int target)
    {
        Array.Sort(nums);

        (int diff, int sum)? min = null;
        for (int i = 0; i < nums.Length - 2; i++)
        {
            var start = i + 1;
            var end = nums.Length - 1;
            while (start != end && min?.diff != 0)
            {
                var sum = nums[i] + nums[start] + nums[end];
                var diff = Math.Abs(target - sum);

                if (sum > target)
                {
                    end--;
                }
                else
                {
                    start++;
                }

                if (min == null || diff < min.Value.diff)
                {
                    min = (diff, sum);
                }
            }
        }

        return min?.sum ?? 0;
    }
}