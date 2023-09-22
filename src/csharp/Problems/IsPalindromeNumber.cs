//https://leetcode.com/problems/palindrome-number/

namespace LeetCode.Problems;

public sealed class IsPalindromeNumber : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsPalindromeNumber))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param(121).Result(true))
          .Add(it => it.Param(-121).Result(false))
          .Add(it => it.Param(10).Result(false));

    private bool Solution1(int x)
    {
        if (x < 0)
        {
            return false;
        }

        var original = x;
        var reversed = 0;
        while (x > 0)
        {
            reversed = reversed * 10 + x % 10;
            x /= 10;
        }

        return original == reversed;
    }

    private bool Solution2(int x)
    {
        if (x < 0)
        {
            return false;
        }

        var arr = new List<int>();
        while (x > 0)
        {
            arr.Add(x % 10);
            x /= 10;
        }

        var left = 0;
        var right = arr.Count - 1;
        while (left <= right)
        {
            if (arr[left++] != arr[right--])
            {
                return false;
            }
        }

        return true;
    }   
}