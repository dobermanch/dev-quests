//https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length/

namespace LeetCode.Problems;

public sealed class MaxVowels : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxVowels))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("abciiidef").Param(3).Result(3))
          .Add(it => it.Param("aeiou").Param(2).Result(2))
          .Add(it => it.Param("leetcode").Param(3).Result(2));

    private int Solution(string s, int k)
    {
        var map = new HashSet<char>{'a', 'e', 'i', 'o', 'u'};

        var right = 0;
        var result = 0;
        var count = 0;
        while (right < s.Length) 
        {
            if (map.Contains(s[right]))
            {
                count++;
                if (count > result)
                {
                    result = count;
                }
            }

            var left = right - k + 1;
            if (left >= 0 && map.Contains(s[left])) 
            {
                count--;
            }

            right++;
        }

        return result;
    }
}