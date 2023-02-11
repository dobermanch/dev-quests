//https://leetcode.com/problems/longest-substring-without-repeating-characters/

namespace LeetCode.Problems;

public sealed class LengthOfLongestSubstring : ProblemBase
{
    [Theory]
    [ClassData(typeof(LengthOfLongestSubstring))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("pawwkesw").Result(4))
            .Add(it => it.Param("pwawkesw").Result(5))
            .Add(it => it.Param("pwwkew").Result(3))
            .Add(it => it.Param("pwwkes").Result(4))
            .Add(it => it.Param("abcabcbb").Result(3))
            .Add(it => it.Param("bbbbb").Result(1))
            .Add(it => it.Param("dvdf").Result(3))
            .Add(it => it.Param("ckilbkd").Result(5))
            .Add(it => it.Param("tmmzuxt").Result(5))
            .Add(it => it.Param("abcAd").Result(5))
            .Add(it => it.Param("hijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789hijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789hijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789hijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789hijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789hijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789").Result(55))
            .Add(it => it.Param(" ").Result(1));

    private int Solution(string s)
    {
        var map = new int[128 - 33]; //from space to ~

        var max = 0;
        var left = 0;
        for (var right = 0; right < s.Length; right++)
        {
            if (map[s[right] - ' '] == 1)
            {
                max = Math.Max(max, right - left);
                var repeat = true;
                while (repeat)
                {
                    repeat = s[left] != s[right];
                    map[s[left] - ' ']--;
                    left++;
                }
            }

            map[s[right] - ' ']++;
        }

        return Math.Max(max, s.Length - left);
    }

    private int Solution1(string s)
    {
        var map = new int[128 - 33]; //from space to ~

        var max = 0;
        var subString = new StringBuilder();
        for (var right = 0; right < s.Length; right++)
        {
            if (map[s[right] - ' '] == 1)
            {
                max = Math.Max(max, subString.Length);
                bool stop = false;
                while (subString.Length > 0 && !stop)
                {
                    stop = subString[0] == s[right];
                    map[subString[0] - ' ']--;
                    subString.Remove(0, 1);
                }
            }

            subString.Append(s[right]);
            map[s[right] - ' ']++;
        }

        return Math.Max(max, subString.Length);
    }
}