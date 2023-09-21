//https://leetcode.com/problems/subsets/

namespace LeetCode.Problems;

public sealed class Subsets : ProblemBase
{
    [Theory]
    [ClassData(typeof(Subsets))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,3]").Result2dArray("[[],[1],[1,2],[1,2,3],[1,3],[2],[2,3],[3]]", true))
          .Add(it => it.ParamArray("[0]").Result2dArray("[[],[0]]", true));

    private IList<IList<int>> Solution(int[] nums)
    {
        var result = new List<IList<int>>();

        Search(nums, 0, new List<int>(10), result);

        return result;
    }

    private void Search(int[] nums, int index, IList<int> temp, IList<IList<int>> result)
    {
        result.Add(temp.ToArray());
        
        for (int i = index; i < nums.Length; i++)
        {
            temp.Add(nums[i]);
            Search(nums, i + 1, temp, result);
            temp.RemoveAt(temp.Count - 1);
        }
    }
}