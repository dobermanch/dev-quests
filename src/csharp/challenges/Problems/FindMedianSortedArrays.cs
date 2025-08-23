//https://leetcode.com/problems/median-of-two-sorted-arrays/

namespace LeetCode.Problems;

public sealed class FindMedianSortedArrays : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindMedianSortedArrays))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,3,4,5]").ParamArray("[1,2,3,4,5,6,7,8]").Result(4.0))
          .Add(it => it.ParamArray("[1,2,3,4]").ParamArray("[1,2,3,4,5,6,7,8]").Result(3.5))
          .Add(it => it.ParamArray("[1,3]").ParamArray("[2]").Result(2.0))
          .Add(it => it.ParamArray("[1,2]").ParamArray("[3,4]").Result(2.5))
          .Add(it => it.ParamArray("[1,2,4,5,7]").ParamArray("[3,4,6]").Result(4.0))
          .Add(it => it.ParamArray("[1,2,4,5,7]").ParamArray("[3,6]").Result(4.0))
          .Add(it => it.ParamArray("[1,2,4,5,7]").ParamArray("[4,6]").Result(4.0))
          .Add(it => it.ParamArray("[1,2,5,7]").ParamArray("[3,4,6,8]").Result(4.5))
          .Add(it => it.ParamArray("[1,5,8]").ParamArray("[9,10,12]").Result(8.5))
          .Add(it => it.ParamArray("[1,5,6]").ParamArray("[9,10,12]").Result(7.5))
          .Add(it => it.ParamArray("[1,5,6]").ParamArray("[9,10]").Result(6.0))
          .Add(it => it.ParamArray("[1,5,8]").ParamArray("[]").Result(5.0))
          .Add(it => it.ParamArray("[]").ParamArray("[9,10,12]").Result(10.0))
          .Add(it => it.ParamArray("[1]").ParamArray("[4,6,8]").Result(5.0));

    private double Solution(int[]? nums1, int[]? nums2)
    {
        nums1 ??= Array.Empty<int>();
        nums2 ??= Array.Empty<int>();

        if (nums1.Length > nums2.Length)
        {
            (nums1, nums2) = (nums2, nums1);
        }

        var length = nums1.Length + nums2.Length;
        var partition = (length + 1) / 2;
        var left = 0;
        var right = nums1.Length;

        while (left <= right)
        {
            var mid1 = (left + right) / 2;
            var mid2 = partition - mid1;

            var m1 = mid1 > 0 ? nums1[mid1 - 1] : int.MinValue;
            var l1 = mid1 < nums1.Length ? nums1[mid1] : int.MaxValue;
            var m2 = mid2 > 0 ? nums2[mid2 - 1] : int.MinValue;
            var l2 = mid2 < nums2.Length ? nums2[mid2] : int.MaxValue;

            if (m1 <= l2 && m2 <= l1)
            {
                return length % 2 == 0
                    ? (Math.Max(m1, m2) + Math.Min(l1, l2)) / 2.0
                    : Math.Max(m1, m2);
            }

            if (m1 > l2)
            {
                right = mid1 - 1;
            }
            else
            {
                left = mid1 + 1;
            }
        }

        return 0d;
    }
}