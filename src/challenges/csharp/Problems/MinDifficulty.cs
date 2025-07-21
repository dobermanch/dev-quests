//https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule

namespace LeetCode.Problems;

public sealed class MinDifficulty : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinDifficulty))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[34,9,6,12,0,1]").Param(2).Result(35))
          .Add(it => it.ParamArray("[34,12,9,6,0,1]").Param(2).Result(35))
          .Add(it => it.ParamArray("[6,5,4,3,2,1]").Param(2).Result(7))
          .Add(it => it.ParamArray("[9,9,9]").Param(4).Result(-1))
          .Add(it => it.ParamArray("[1,1,1]").Param(3).Result(3))
          .Add(it => it.ParamArray("[186,398,479,206,885,423,805,112,925,656,16,932,740,292,671,360]").Param(4).Result(1803))
          .Add(it => it.ParamArray("[6,5,4,3,2,1]").Param(3).Result(9));

    private int Solution(int[] jobDifficulty, int d)
    {
        var length = jobDifficulty.Length;
        var map = new int[d + 1, length + 1];

        for (int i = 0; i <= d; i++)
        {
            for (int j = 0; j < length; j++)
            {
                map[i, j] = int.MaxValue;
            }
        }

        for (int days = 1; days <= d; days++)
        {
            for (int i = 0; i <= length - days; i++)
            {
                var difficult = 0;
                for (int j = i + 1; j <= jobDifficulty.Length - days + 1; j++)
                {
                    difficult = Math.Max(difficult, jobDifficulty[j - 1]);
                    if (map[days - 1, j] != int.MaxValue)
                    {
                        var current = difficult + map[days - 1, j];
                        map[days, i] = Math.Min(map[days, i], current);
                    }
                }
            }
        }

        return map[d, 0] < int.MaxValue ? map[d, 0] : -1;
    }
}