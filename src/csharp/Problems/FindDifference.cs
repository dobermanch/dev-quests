// https://leetcode.com/problems/find-the-difference-of-two-arrays

namespace LeetCode.Problems;

public sealed class FindDifference : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindDifference))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,3]").ParamArray("[2,4,6]").Result2dArray("[[1,3],[4,6]]"))
          .Add(it => it.ParamArray("[1,2,3,3]").ParamArray("[1,1,2,2]").Result2dArray("[[3],[]]", true));

    private IList<IList<int>> Solution(int[] nums1, int[] nums2)
    {
        var map1 = new HashSet<int>(nums1);
        var map2 = new HashSet<int>(nums2);

        var d = nums1.ToLookup(it => it);

        for (var i = 0; i < nums1.Length; i++)
        {
            if (map2.Contains(nums1[i]))
            {
                map2.Remove(nums1[i]);
                map1.Remove(nums1[i]);
            }
        }

        return new [] { map1.ToArray(), map2.ToArray() };
    }
}