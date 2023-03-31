//https://leetcode.com/problems/intersection-of-two-arrays-ii/

namespace LeetCode.Problems;

public sealed class Intersect : ProblemBase
{
    [Theory]
    [ClassData(typeof(Intersect))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,2,1]").ParamArray("[2,2]").ResultArray("[2,2]"))
          .Add(it => it.ParamArray("[4,9,5]").ParamArray("[9,4,9,8,4]").ResultArray("[9,4]"));

    private int[] Solution(int[] nums1, int[] nums2)
    {
        var result = new List<int>();

        var map = new Dictionary<int, int>();
        foreach (var i in nums1)
        {
            if (!map.ContainsKey(i))
            {
                map.Add(i, 0);
            }
            map[i]++;
        }

        foreach (var i in nums2)
        {
            if (map.ContainsKey(i) && map[i] > 0)
            {
                result.Add(i);
                map[i]--;
            }
        }

        return result.ToArray();
    }
}