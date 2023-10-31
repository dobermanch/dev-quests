//https://leetcode.com/problems/palindromic-substrings/

namespace LeetCode.Problems;

public sealed class CountSubstrings : ProblemBase
{
    [Theory]
    [ClassData(typeof(CountSubstrings))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("abccba").Result(9))
          .Add(it => it.Param("abaaba").Result(11))
          .Add(it => it.Param("aaa").Result(6))
          .Add(it => it.Param("abc").Result(3));

    private int Solution(string s)
    {
        int IsPalindrome(string str, int left, int right)
        {
            var count = 0;
            while (left >= 0 && right < str.Length)
            {
                if (str[left--] != str[right++])
                {
                    break;
                }
                count++;
            }

            return count;
        }

        var result = 0;
        for (int i = 0; i < s.Length; i++)
        {
            result += IsPalindrome(s, i, i);
            result += IsPalindrome(s, i, i + 1);
        }

        return result;
    }

    private int Solution1(string s)
    {
        var map = new Dictionary<char, IList<int>>();
        for (var i = 0; i < s.Length; i++)
        {
            if (!map.ContainsKey(s[i]))
            {
                map[s[i]] = new List<int>();
            }

            map[s[i]].Add(i);
        }

        var result = s.Length;

        for (int i = 0; i < s.Length; i++)
        {
            if (map[s[i]].Count == 1)
            {
                continue;
            }

            map[s[i]].RemoveAt(0);

            foreach (var index in map[s[i]])
            {
                var left = i;
                var right = index;
                while (left <= right && s[++left] == s[--right]) ;

                if (left >= right)
                {
                    result++;
                }
            }
        }

        return result;
    }
}