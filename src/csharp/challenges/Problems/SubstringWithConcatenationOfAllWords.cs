//https://leetcode.com/problems/substring-with-concatenation-of-all-words

namespace LeetCode.Problems;

public sealed class FindSubstring : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindSubstring))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("aaaaaaaaaaaaaa").ParamArray<string>("""["aa","aa"]""").ResultArray("[0,1,2,3,4,5,6,7,8,9,10]"))
          .Add(it => it.Param("barfoofoxobarfhefoobarman").ParamArray<string>("""["arf","rfo","ofo","xob"]""").ResultArray("[2]"))
          .Add(it => it.Param("barfoothefoobarman").ParamArray<string>("""["foo","bar"]""").ResultArray("[0,9]"))
          .Add(it => it.Param("wordgoodgoodgoodbestword").ParamArray<string>("""["word","good","best","word"]""").ResultArray("[]"))
          .Add(it => it.Param("barfoofoobarthefoobarman").ParamArray<string>("""["bar","foo","the"]""").ResultArray("[6,9,12]"));

    private IList<int> Solution(string s, string[] words)
    {
var window = words[0].Length * words.Length;
        var size = window / words.Length;

        var wordMap = new Dictionary<string, int[]>();
        foreach (var word in words)
        {
            if (!wordMap.TryGetValue(word, out var map))
            {
                wordMap.Add(word, map = new int[2]);
            }

            map[0] += 1;
        }

        var checkMap = new List<(int index, string word)>();
        for (var i = 0; i <= s.Length - size; i++)
        {
            var word = s[i..(i + size)];
            if (wordMap.ContainsKey(word))
            {
                checkMap.Add((i, word));
            }
        }

        var result = new List<int>();
        var left = 0;
        while (left <= checkMap.Count - words.Length)
        {
            var checkWindow = checkMap[left].index + window - size;
            var right = left;
            var prevIndex = -size;
            while (right < checkMap.Count && checkWindow >= checkMap[right].index)
            {
                if (checkMap[right].index >= prevIndex + size)
                {
                    wordMap[checkMap[right].word][1] += 1;
                    prevIndex = checkMap[right].index;
                }

                right++;
            }

            var found = true;
            foreach(var map in wordMap)
            {
                found &= map.Value[0] == map.Value[1];
                map.Value[1] = 0;
            }

            if (found)
            {
                result.Add(checkMap[left].index);
            }

            left++;
        }

        return result;
    }

    private IList<int> Solution2(string s, string[] words)
    {
        var size = words[0].Length;
        var window = size * words.Length;

        var wordMap = new Dictionary<string, int[]>();
        foreach (var word in words)
        {
            if (!wordMap.TryGetValue(word, out var map))
            {
                wordMap.Add(word, map = new int[2]);
            }

            map[0] += 1;
        }

        var result = new List<int>();
        for (var left = 0; left <= s.Length - window; left++)
        {
            for (var right = left; right < left + window; right += size)
            {
                var word = s[right..(right + size)];
                if (!wordMap.ContainsKey(word))
                {
                    break;
                }

                wordMap[word][1] += 1;
            }

            var found = true;
            foreach(var map in wordMap)
            {
                found &= map.Value[0] == map.Value[1];
                map.Value[1] = 0;
            }

            if (found)
            {
                result.Add(left);
            }
        }

        return result;
    }
}