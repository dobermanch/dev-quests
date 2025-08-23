//https://leetcode.com/problems/assign-cookies

namespace LeetCode.Problems;

public sealed class FindContentChildren : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindContentChildren))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,3]").ParamArray("[3]").Result(1))
          .Add(it => it.ParamArray("[1,2,3]").ParamArray("[1,1]").Result(1))
          .Add(it => it.ParamArray("[10,9,8,7]").ParamArray("[5,6,7,8]").Result(2))
          .Add(it => it.ParamArray("[1,2]").ParamArray("[1,2,3]").Result(2));

    private int Solution(int[] g, int[] s)
    {
        Array.Sort(g);
        Array.Sort(s);

        var cookie = 0;
        var green = 0;
        var result = 0;
        while(green < g.Length && cookie < s.Length)
        {
            if (s[cookie] >= g[green])
            {
                result++;
                green++;
            }

            cookie++;
        }

        return result;
    }
}