//https://leetcode.com/problems/determine-if-two-strings-are-close/

namespace LeetCode.Problems;

public sealed class CloseStrings : ProblemBase
{
    [Theory]
    [ClassData(typeof(AddStrings))]
    public override void Test(object[] data) => base.Test(data);

    public override void CloseStrings()
        => Add(it => it.Param("abc").Param("bca").Result(true))
          .Add(it => it.Param("a").Param("aa").Result(false))
          .Add(it => it.Param("cabbba").Param("abbccc").Result(true))
          .Add(it => it.Param("abbzzca").Param("babzzcz").Result(false));

    private bool Solution(string word1, string word2)
    {
        int[] count(string word)
        {
            var set = new int[26];
            for (var i = 0; i < word.Length; i++)
            {
                set[word[i] - 'a']++;
            }
            return set;
        }

        var map1 = count(word1);
        var map2 = count(word2);

        for (var i = 0; i < map1.Length; i++)
        {
            if ((map1[i] == 0 && map2[i] > 0) || (map1[i] > 0 && map2[i] == 0)) 
            {
                return false;
            }
        }

        Array.Sort(map1);
        Array.Sort(map2);

        return map1.SequenceEqual(map2);
    }
}