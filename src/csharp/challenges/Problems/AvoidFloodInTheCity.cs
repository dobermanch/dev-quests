
// https://leetcode.com/problems/avoid-flood-in-the-city

namespace LeetCode.Problems;

public sealed class AvoidFloodInTheCity : ProblemBase
{
    [Theory]
    [ClassData(typeof(AvoidFloodInTheCity))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        =>
            Add(it => it.ParamArray([1,2,0,2,3,0,1]).ResultArray([-1,-1,2,-1,-1,1,-1]))
            .Add(it => it.ParamArray([2,0,1,1,0]).ResultArray<int>([]))
            .Add(it => it.ParamArray([1, 2, 3, 4]).ResultArray([-1, -1, -1, -1]))
            .Add(it => it.ParamArray([1, 2, 0, 0, 2, 1]).ResultArray([-1, -1, 2, 1, -1, -1]))
            .Add(it => it.ParamArray([1, 2, 0, 1, 2]).ResultArray<int>([]))
            .Add(it => it.ParamArray([2,3,0,0,3,1,0,1,0,2,2]).ResultArray<int>([]))
            .Add(it => it.ParamArray([69,0,0,0,69]).ResultArray([-1,69,1,1,-1]))
            .Add(it => it.ParamArray([1,1,0,0]).ResultArray<int>([]));

    private int[] Solution(int[] rains)
    {
        var result = new int[rains.Length];
        var rivers = new Dictionary<int, int>();
        var dryDays = new SortedSet<int>();

        for (var i = 0; i < rains.Length; i++)
        {
            if (rains[i] <= 0)
            {
                dryDays.Add(i);
                result[i] = 1;
                continue;
            }

            result[i] = -1;

            if (rivers.ContainsKey(rains[i]))
            {
                var candidates = dryDays.GetViewBetween(rivers[rains[i]], i);
                var min = candidates.Min;
                if (min <= 0)
                {
                    return [];
                }

                result[min] = rains[i];
                dryDays.Remove(min);
            }

            rivers[rains[i]] = i;
        }

        return result;
    }
}
