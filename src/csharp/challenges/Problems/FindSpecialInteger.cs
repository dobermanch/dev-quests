//https://leetcode.com/problems/element-appearing-more-than-25-in-sorted-array

namespace LeetCode.Problems;

public sealed class FindSpecialInteger : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindSpecialInteger))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,3,3]").Result(3))
          .Add(it => it.ParamArray("[1,1,2,2,3,3,3,3]").Result(3))
          .Add(it => it.ParamArray("[1,2,2,6,6,6,6,7,10]").Result(6))
          .Add(it => it.ParamArray("[1]").Result(1));

    private int Solution1(int[] arr)
    {
        var minCount = arr.Length / 4;
        for (var i = 0; i < arr.Length - minCount; i++)
        {
            if (arr[i] == arr[i + minCount])
            {
                return arr[i];
            }
        }

        return arr[0];
    }

    private int Solution2(int[] arr)
    {
        var minCount = arr.Length / 4;

        var count = 1;
        for (var i = 1; i < arr.Length; i++)
        {
            count = arr[i - 1] == arr[i] ? count + 1 : 1;
            if (count > minCount)
            {
                return arr[i];
            }
        }

        return arr[0];
    }
}