//https://leetcode.com/problems/word-search/

namespace LeetCode.Problems;

public sealed class WordSearch : ProblemBase
{
    [Theory]
    [ClassData(typeof(WordSearch))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray<char>("""[['a','a']]""").Param("aaa").Result(false))
          .Add(it => it.Param2dArray<char>("""[['A','B','C','E'],['S','F','E','S'],['A','D','E','E']]""").Param("ABCESEEEFS").Result(true))
          .Add(it => it.Param2dArray<char>("""[['C','A','A'],['A','A','A'],['B','C','D']]""").Param("AAB").Result(true))
          .Add(it => it.Param2dArray<char>("""[['A','B','C','E'],['S','F','C','S'],['A','D','E','E']]""").Param("ABCCED").Result(true))
          .Add(it => it.Param2dArray<char>("""[['A','B','C','E'],['S','F','C','S'],['A','D','E','E']]""").Param("SEE").Result(true))
          .Add(it => it.Param2dArray<char>("""[['A','B','C','E'],['S','F','C','S'],['A','D','E','E']]""").Param("ABCB").Result(false));

    private bool Solution(char[][] board, string word)
    {
        for (var y = 0; y < board.Length; y++)
        {
            for (var x = 0; x < board[0].Length; x++)
            {
                if (Search(board, word, x, y, 0))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool Search(char[][] board, string word, int x, int y, int index)
    {
        if (x < 0 || x >= board[0].Length 
         || y < 0 || y >= board.Length
         || board[y][x] != word[index])
        {
            return false;
        }

        if (index == word.Length - 1)
        {
            return true;
        }

        board[y][x] -= 'A';

        var result = false;
        result |= Search(board, word, x + 1, y, index + 1);
        result |= Search(board, word, x - 1, y, index + 1);
        result |= Search(board, word, x, y + 1, index + 1);
        result |= Search(board, word, x, y - 1, index + 1);

        board[y][x] += 'A';

        return result;
    }
}