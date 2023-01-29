//https://leetcode.com/problems/ransom-note/

namespace LeetCode.Problems;

public sealed class RansomNote : ProblemBase
{
    public static void Run()
    {
        var result = Run("a", "b");
        //var result = Run("aa", "ab");
        //var result = Run("aa", "aab");
    }

    private static bool Run(string ransomNote, string magazine) 
    {
        if (magazine.Length < ransomNote.Length) 
        {
            return false;
        }

        var note = new int[26];
        foreach(var letter in magazine)
        {
            note[letter - 'a']++;
        };

        foreach(var letter in ransomNote)
        {
            if (--note[letter - 'a'] < 0)
            {
                return false;
            }
        }

        return true;
    }
}