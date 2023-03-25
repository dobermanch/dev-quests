//https://leetcode.com/problems/partition-equal-subset-sum/

namespace LeetCode.Problems;

public sealed class CanPartition : ProblemBase
{
    [Theory]
    [ClassData(typeof(CanPartition))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,5,11,5]").Result(true))
          .Add(it => it.ParamArray("[1,2,3,5]").Result(false));

    private bool Solution(int[] candidates)
    {
        var result = new List<int>();

        Search(candidates, 0, new List<int>(), result);
        return true;
    }

    private void Search(int[] candidates, int index, IList<int> temp, IList<int> result)
    {
        while (true)
        {
            if (index >= candidates.Length)
            {
                result.Add(temp.Sum());
                return;
            }

            temp.Add(candidates[index]);
            Search(candidates, index + 1, temp, result);

            temp.RemoveAt(temp.Count - 1);
            index++;
        }
    }
}