//https://leetcode.com/problems/non-decreasing-subsequences/description/

namespace LeetCode.Problems;

public sealed class FindSubsequences : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindSubsequences))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[4,6,7,7]").Result2dArray("[[4,6],[4,6,7],[4,6,7,7],[4,7],[4,7,7],[6,7],[6,7,7],[7,7]]"))
            .Add(it => it.ParamArray("[4,4,3,2,1]").Result2dArray("[[4,4]]"));

    private IList<IList<int>> Solution(int[] nums)
    {
        var result = new List<IList<int>>();

        Find(nums, 0, new List<int>(), result);

        return result;
    }

    private void Find(int[] nums, int index, List<int> res, List<IList<int>> result)
    {
        if (res.Count > 1)
        {
            result.Add(res.ToArray());
        }

        if (index == nums.Length)
        {
            return;
        }

        var visited = new HashSet<int>();
        for (var next = index; next < nums.Length; next++)
        {
            if (visited.Contains(nums[next]) || res.Any() && res.Last() > nums[next])
            {
                continue;
            }

            res.Add(nums[next]);
            Find(nums, next + 1, res, result);
            res.Remove(res.Last());
            visited.Add(nums[next]);
        }
    }
}