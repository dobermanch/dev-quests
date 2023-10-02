//https://leetcode.com/problems/find-the-highest-altitude/

namespace LeetCode.Problems;

public sealed class LargestAltitude : ProblemBase
{
    [Theory]
    [ClassData(typeof(LargestAltitude))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[-5,1,5,0,-7]").Result(1))
          .Add(it => it.ParamArray("[-4,-3,-2,-1,4,3,2]").Result(0));

    private int Solution(int[] gain) 
    {
        var result = 0;
        var current = 0;
        for (var i = 0; i < gain.Length; i++)
        {
            current += gain[i];
            if (current > result)
            {
                result = current;
            }
        }

        return result;
    }
}