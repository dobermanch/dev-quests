//https://leetcode.com/problems/reverse-vowels-of-a-string/

namespace LeetCode.Problems;

public sealed class ReverseVowels : ProblemBase
{
    [Theory]
    [ClassData(typeof(ReverseVowels))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("hello").Result("holle"))
          .Add(it => it.Param("leetcode").Result("leotcede"));

    private string Solution(string s)
    {
        var map = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        var result = s.ToArray();

        var left = 0;
        var right = s.Length - 1;
        while (left < right)
        {
            if (map.Contains(s[left]))
            {
                if (map.Contains(s[right]))
                {
                    (result[left], result[right]) = (result[right], result[left]);
                    left++;
                }

                right--;
            }
            else
            {
                left++;
            }
        }

        return new string(result);
    }
}