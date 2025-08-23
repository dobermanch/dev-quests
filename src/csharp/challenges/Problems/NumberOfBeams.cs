// https://leetcode.com/problems/number-of-laser-beams-in-a-bank

namespace LeetCode.Problems;

public sealed class NumberOfBeams : ProblemBase
{
    [Theory]
    [ClassData(typeof(NumberOfBeams))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray<string>("""["011001","000000","010100","001000"]""").Result(8))
          .Add(it => it.ParamArray<string>("""["000","111","000"]""").Result(0));

    private int Solution(string[] bank)
    {
        var result = 0;
        var prevDevices = 0;
        foreach (var floor in bank)
        {
            var devices = 0;
            foreach (var device in floor)
            {
                if (device is '1')
                {
                    devices++;
                }
            }

            result += devices * prevDevices;

            if (devices > 0)
            {
                prevDevices = devices;
            }
        }

        return result;
    }
}