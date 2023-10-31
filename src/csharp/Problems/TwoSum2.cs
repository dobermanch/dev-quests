//https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/

namespace LeetCode.Problems;

public sealed class TwoSum2 : ProblemBase
{
    [Theory]
    [ClassData(typeof(TwoSum2))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[2,7,11,15]").Param(9).ResultArray("[1,2]"))
          .Add(it => it.ParamArray("[2,7,11,15,16,17,18,19,29,34,45,56,67,78,85,90]").Param(100).ResultArray("[4,15]"))
          .Add(it => it.ParamArray("[2,3,4]").Param(6).ResultArray("[1,3]"))
          .Add(it => it.ParamArray("[-1,0]").Param(-1).ResultArray("[1,2]"));

    private int[] Solution(int[] numbers, int target)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            var start = i + 1;
            var end = numbers.Length - 1;
            var sum = target - numbers[i];
            while (start <= end)
            {
                var mid = start + (end - start) / 2;
                if (numbers[mid] == sum)
                {
                    return new[] {i + 1, mid + 1};
                }

                if (numbers[mid] > sum)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
        }

        return new[] {0, 0};
    }

    private int[] Solution2(int[] numbers, int target)
    {
        var start = 0;
        var end = numbers.Length - 1;

        while (start < end)
        {
            var sum = numbers[start] + numbers[end];
            if (sum == target)
            {
                break;
            }

            if (sum > target)
            {
                end--;
            }
            else
            {
                start++;
            }
        }

        return new[] { start + 1, end + 1 };
    }
}