//https://leetcode.com/problems/add-two-integers/

namespace LeetCode.Problems;

public sealed class TopKFrequentElement : ProblemBase
{
    [Theory]
    [ClassData(typeof(TopKFrequentElement))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,1,1,2,2,3]").Param(2).ResultArray("[1,2]"))
          .Add(it => it.ParamArray("[1]").Param(1).ResultArray("[1]"));

    private int[] Solution(int[] nums, int k)
    {
        var temp = new Dictionary<int, int>();
        foreach (var t in nums)
        {
            if (!temp.ContainsKey(t))
            {
                temp[t] = 0;
            }

            temp[t]++;
        }

        var result = new int[k];
        var queue = new PriorityQueue<int, int>(temp.Select(it => (it.Key, -it.Value)));
        for (var i = 0; i < result.Length; i++)
        {
            result[i] = queue.Dequeue();
        }

        return result;
    }
}