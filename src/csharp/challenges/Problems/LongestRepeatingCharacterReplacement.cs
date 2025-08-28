//https://leetcode.com/problems/longest-repeating-character-replacement/

namespace LeetCode.Problems;

public sealed class CharacterReplacement : ProblemBase
{
    [Theory]
    [ClassData(typeof(CharacterReplacement))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("AABABBA").Param(1).Result(4))
            .Add(it => it.Param("AAAA").Param(2).Result(4))
            .Add(it => it.Param("ABAA").Param(0).Result(2))
            .Add(it => it.Param("ABBB").Param(2).Result(4))
            .Add(it => it.Param("BAAAB").Param(2).Result(5))
            .Add(it => it.Param("ABAB").Param(2).Result(4))
            .Add(it => it.Param("AAAB").Param(0).Result(3))
            .Add(it => it.Param("EOEMQLLQTRQDDCOERARHGAAARRBKCCMFTDAQOLOKARBIJBISTGNKBQGKKTALSQNFSABASNOPBMMGDIOETPTDICRBOMBAAHINTFLH").Param(7).Result(11))
            .Add(it => it.Param("KRSCDCSONAJNHLBMDQGIFCPEKPOHQIHLTDIQGEKLRLCQNBOHNDQGHJPNDQPERNFSSSRDEQLFPCCCARFMDLHADJADAGNNSBNCJQOF").Param(4).Result(7))
            .Add(it => it.Param("QLHOSLDHOOBHFLPBSLHMSHMSRDOIFGGRTTSMKKRIENQNEECPLTJKCDMLRNNEPQAJDQFPEOGLKRBHSOMHONNTKLFHKNCHQLDBACMO").Param(7).Result(10));

    private int Solution(string s, int k)
    {
        var map = new int[26];

        var sum = 0;
        var left = 0;

        for (int right = 0; right < s.Length; right++)
        {
            map[s[right] - 'A']++;

            sum = Math.Max(sum, map[s[right] - 'A']);

            if (sum + k <= right - left)
            {
                map[s[left] - 'A']--;
                left++;
            }
        }

        return s.Length - left;
    }
}