//https://leetcode.com/problems/unique-number-of-occurrences/

namespace LeetCode.Problems;

public sealed class UniqueOccurrences : ProblemBase
{
    [Theory]
    [ClassData(typeof(UniqueOccurrences))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(true, it => it.ParamArray("[1,2,2,1,1,3]").Result(true))
          .Add(true, it => it.ParamArray("[1,2]").Result(false))
          .Add(it => it.ParamArray("[0,-3,1,-3,1,1,1,-3,10,0]").Result(true));

    private bool Solution(int[] arr)
    {
        var occurrences = arr.ToLookup(it => it).Select(it => it.Count()).ToArray();

        return occurrences.ToHashSet().Count == occurrences.Length;
    }
}