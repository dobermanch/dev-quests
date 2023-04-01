//https://leetcode.com/problems/combination-sum/

namespace LeetCode.Problems;

public sealed class CombinationSum : ProblemBase
{
    [Theory]
    [ClassData(typeof(CombinationSum))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[2,3,6,7]").Param(7).Result2dArray("[[2,2,3],[7]]"))
          .Add(it => it.ParamArray("[2,3,5]").Param(8).Result2dArray("[[2,2,2,2],[2,3,3],[3,5]]"))
          .Add(it => it.ParamArray("[2]").Param(1).Result2dArray("[]"));

    private IList<IList<int>> Solution(int[] candidates, int target)
    {
        var result = new List<IList<int>>();

        Search(candidates, target, 0, 0, new List<int>(), result);
        return result;
    }

    private void Search(int[] candidates, int target, int index, int sum, IList<int> temp, IList<IList<int>> result)
    {
        if (sum == target)
        {
            result.Add(temp.ToArray());
            return;
        }

        while (sum < target && index < candidates.Length)
        {
            temp.Add(candidates[index]);
            Search(candidates, target, index, sum + candidates[index], temp, result);

            temp.RemoveAt(temp.Count - 1);
            index++;
        }
    }
}