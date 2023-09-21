//https://leetcode.com/problems/subsets-ii/

namespace LeetCode.Problems;

public sealed class SubsetsWithDup : ProblemBase
{
    [Theory]
    [ClassData(typeof(SubsetsWithDup))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,2]").Result2dArray("[[],[1],[1,2],[1,2,2],[2],[2,2]]", true))
          .Add(it => it.ParamArray("[4,4,4,1,4]").Result2dArray("[[],[1],[1,4],[1,4,4],[1,4,4,4],[1,4,4,4,4],[4],[4,4],[4,4,4],[4,4,4,4]]", true))
          .Add(it => it.ParamArray("[0]").Result2dArray("[[],[0]]", true));

    private IList<IList<int>> Solution(int[] nums)
    {
        var result = new List<IList<int>>();

        Search(nums.OrderBy(it => it).ToArray(), 0, new List<int>(10), result);

        return result;
    }

    private void Search(int[] nums, int index, IList<int> temp, IList<IList<int>> result)
    {        
        result.Add(temp.ToArray());
        
        for (int i = index; i < nums.Length; i++)
        {
            if (i > index && nums[i] == nums[i - 1]) 
            {
                continue; 
            }

            temp.Add(nums[i]);
            Search(nums, i + 1, temp, result);
            temp.RemoveAt(temp.Count - 1);
        }     
    }
}