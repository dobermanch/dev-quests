//https://leetcode.com/problems/valid-palindrome/

namespace LeetCode.Problems;

public sealed class IsPalindrome : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsPalindrome))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("A man, a plan, a canal: Panama").Result(true))
          .Add(it => it.Param("A man1, a plan, a canal: Pa1nama").Result(true))
          .Add(it => it.Param("race a car").Result(false))
          .Add(it => it.Param("").Result(true));

    private bool Solution(string s)
    {
        var left = 0;
        var right = s.Length - 1;
        while (left < right)
        {
            if (!char.IsLetterOrDigit(s[left]))
            {
                left++;
                continue;
            }

            if (!char.IsLetterOrDigit(s[right]))
            {
                right--;
                continue;
            }

            if (char.ToLower(s[left]) != char.ToLower(s[right]))
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }
}