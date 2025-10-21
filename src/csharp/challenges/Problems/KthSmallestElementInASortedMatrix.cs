
// https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix

namespace LeetCode.Problems;

public sealed class KthSmallestElementInASortedMatrix : ProblemBase
{
    [Theory]
    [ClassData(typeof(KthSmallestElementInASortedMatrix))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray<int>("[[-5,-4],[-5,-4]]").Param(2).Result(-4))
          .Add(it => it.Param2dArray<int>("[[1,5,9],[10,11,13],[12,13,15]]").Param(8).Result(13))
          .Add(it => it.Param2dArray<int>("[[-5]]").Param(1).Result(-5))
        ;

    private int Solution(int[][] matrix, int k)
    {
        var left = matrix[0][0];
        var right = matrix[^1][^1];
        var result = right;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            var target = 0;
            foreach(var row in matrix)
            {
                if (row[0] > mid)
                {
                    break;
                }

                var l = 0;
                var r = matrix.Length - 1;
                while(l <= r)
                {
                    var m = (l + r) / 2;
                    if (row[m] <= mid)
                    {
                        l = m + 1;
                    }
                    else
                    {
                        r = m - 1;
                    }
                }

                target += l;
            }

            if (target < k)
            {
                left = mid + 1;
            }
            else
            {
                right = result = mid;
            }
        }

        return result;
    }
}
