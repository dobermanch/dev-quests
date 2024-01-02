//https://leetcode.com/problems/convert-an-array-into-a-2d-array-with-conditions

namespace LeetCode.Problems;

public sealed class FindMatrix : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindMatrix))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,3,4,1,2,3,1]").Result2dArray("[[1,3,4,2],[1,3],[1]]"))
          .Add(it => it.ParamArray("[1,2,3,4]").Result2dArray("[[4,3,2,1]]"));

    private IList<IList<int>> Solution(int[] nums)
    {
        var result = new List<HashSet<int>>();

        for (var i = 0; i < nums.Length; i++)
        {
            var added = false;
            var index = -1;
            while (!added && ++index < result.Count)
            {
                added = result[index].Add(nums[i]);
            }

            if (!added)
            {
                result.Add(new HashSet<int>());
                result[^1].Add(nums[i]);
            }
        }

        return result.Select(it => it.ToArray()).ToArray();
    }
}