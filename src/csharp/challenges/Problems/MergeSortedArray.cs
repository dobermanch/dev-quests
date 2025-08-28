//https://leetcode.com/problems/merge-sorted-array/

namespace LeetCode.Problems;

public sealed class Merge : ProblemBase
{
    [Theory]
    [ClassData(typeof(Merge))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[4,5,6,0,0,0]").Param(3).ParamArray("[1,2,3]").Param(3).ResultArray("[1,2,3,4,5,6]"))
          .Add(it => it.ParamArray("[1,3,5,0,0,0]").Param(3).ParamArray("[2,4,6]").Param(3).ResultArray("[1,2,3,4,5,6]"))
          .Add(it => it.ParamArray("[1,2,3,0,0,0]").Param(3).ParamArray("[2,5,6]").Param(3).ResultArray("[1,2,2,3,5,6]"))
          .Add(it => it.ParamArray("[1]").Param(1).ParamArray("[]").Param(0).ResultArray("[1]"))
          .Add(it => it.ParamArray("[0]").Param(0).ParamArray("[1]").Param(1).ResultArray("[1]"));

    private int[] Solution(int[] nums1, int m, int[] nums2, int n)
    {
        var i1 = m - 1;
        var i2 = n - 1;
        for (var i = nums1.Length - 1; i >= 0; i--)
        {
            nums1[i] = i2 < 0 || (i1 >= 0 && nums1[i1] > nums2[i2]) ? nums1[i1--] : nums2[i2--];
        }

        return nums1;
    }
}