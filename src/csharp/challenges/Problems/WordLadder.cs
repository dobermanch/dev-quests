
// https://leetcode.com/problems/word-ladder

namespace LeetCode.Problems;

public sealed class WordLadder : ProblemBase
{
    [Theory]
    [ClassData(typeof(WordLadder))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("hit").Param("cog").ParamArray(["hot","dot","dog","lot","log","cog"]).Result(5))
          .Add(it => it.Param("hit").Param("cog").ParamArray(["hot","dot","dog","lot","log"]).Result(0))
        ;

    private int Solution(string beginWord, string endWord, IList<string> wordList)
    {
        var wordsSet = wordList.ToHashSet();

        var queue = new Queue<(string, int)>();
        queue.Enqueue((beginWord, 1));

        var seen = new HashSet<string>();
        seen.Add(beginWord);

        var result = 0;
        while (queue.Count > 0)
        {
            var (word, count) = queue.Dequeue();

            if (word == endWord)
            {
                result = count;
                break;
            }

            for (char l = 'a'; l <= 'z'; l++)
            {
                for (var i = 0; i < beginWord.Length; i++)
                {
                    var nextWord = word.Substring(0, i) + l + word.Substring(i + 1);
                    if (!seen.Contains(nextWord) && wordsSet.Contains(nextWord))
                    {
                        queue.Enqueue((nextWord, count + 1));
                        seen.Add(nextWord);
                    }
                }
            }
        }

        return result;
    }
}
