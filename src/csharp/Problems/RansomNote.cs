//https://leetcode.com/problems/ransom-note/

namespace LeetCode.Problems;

public sealed class RansomNote : ProblemBase
{
    [Theory]
    [ClassData(typeof(RansomNote))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("a").Param("b").Result(false))
          .Add(it => it.Param("aa").Param("ab").Result(false))
          .Add(it => it.Param("aa").Param("aab").Result(true))
        ;

    private bool Solution(string ransomNote, string magazine) 
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