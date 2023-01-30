//https://leetcode.com/problems/longest-repeating-character-replacement/

namespace LeetCode.Problems;

public sealed class CharacterReplacement : ProblemBase
{
    public static void Run()
    {
        var d = Run("AABABBA", 1); //4
        //var d = Run("AAAA", 2); //4
        //var d = Run("ABAA", 0); //2
        //var d = Run("ABBB", 2); //2
        //var d = Run("BAAAB", 2); //2
        //var d = Run("ABAB", 2); //4
        //var d = Run("AAAB", 0); //3
        //var d = Run("EOEMQLLQTRQDDCOERARHGAAARRBKCCMFTDAQOLOKARBIJBISTGNKBQGKKTALSQNFSABASNOPBMMGDIOETPTDICRBOMBAAHINTFLH", 7); //11
        //var d = Run("KRSCDCSONAJNHLBMDQGIFCPEKPOHQIHLTDIQGEKLRLCQNBOHNDQGHJPNDQPERNFSSSRDEQLFPCCCARFMDLHADJADAGNNSBNCJQOF", 4); //7
        //QLHOSLDHOOBHFLPBSLHMSHMSRDOIFGGRTTSMKKRIENQNEECPLTJKCDMLRNNEPQAJDQFPEOGLKRBHSOMHONN TKLFHKNCHQLDBACMO
        //var d = Run("QLHOSLDHOOBHFLPBSLHMSHMSRDOIFGGRTTSMKKRIENQNEECPLTJKCDMLRNNEPQAJDQFPEOGLKRBHSOMHONNTKLFHKNCHQLDBACMO", 7); //10
    }

    private static int Run(string s, int k)
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