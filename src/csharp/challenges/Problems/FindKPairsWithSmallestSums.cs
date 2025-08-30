
// https://leetcode.com/problems/find-k-pairs-with-smallest-sums

namespace LeetCode.Problems;

public sealed class FindKPairsWithSmallestSums : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindKPairsWithSmallestSums))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray([1,7,11]).ParamArray([2,4,6]).Param(3).Result2dArray("[[1,2],[1,4],[1,6]]"))
          .Add(it => it.ParamArray([1,1,2]).ParamArray([1,2,3]).Param(2).Result2dArray("[[1,1],[1,1]]"))
        ;

    private IList<IList<int>> Solution(int[] nums1, int[] nums2, int k)
    {
        var result = new List<IList<int>>();
        var visited = new HashSet<(int, int)>();

        var heap = new PriorityQueue<(int, int), int>();
        heap.Enqueue((0, 0), nums1[0] + nums2[0]);

        visited.Add((0, 0));

        while (k > 0 && heap.Count > 0)
        {
            var (i, j) = heap.Dequeue();
            result.Add([nums1[i], nums2[j]]);

            if (i + 1 < nums1.Length && !visited.Contains((i + 1, j)))
            {
                heap.Enqueue((i + 1, j), nums1[i + 1] + nums2[j]);
                visited.Add((i + 1, j));
            }

            if (j + 1 < nums2.Length && !visited.Contains((i, j + 1)))
            {
                heap.Enqueue((i, j + 1), nums1[i] + nums2[j + 1]);
                visited.Add((i, j + 1));
            }

            k -= 1;
        }

        return result;
    }
}
