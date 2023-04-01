//https://leetcode.com/problems/top-k-frequent-words

namespace LeetCode.Problems;

public sealed class TopKFrequentWords : ProblemBase
{
    [Theory]
    [ClassData(typeof(TopKFrequentWords))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("i","love","leetcode","i","love","coding").Param(2).ResultArray("i","love"))
          .Add(it => it.ParamArray("the","day","is","sunny","the","the","the","sunny","is","is").Param(4).ResultArray("the", "is", "sunny", "day"));

    private IList<string> Solution(string[] words, int k)
    {
        return words
            .GroupBy(it => it)
            .OrderByDescending(it => it.Count())
            .ThenBy(it => it.Key)
            .Take(k)
            .Select(it => it.Key)
            .ToArray();
    }
}