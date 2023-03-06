//https://leetcode.com/problems/valid-sudoku/

namespace LeetCode.Problems;

public sealed class IsValidSudoku : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsValidSudoku))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray<char>(
                        @"[['5','3','.','.','7','.','.','.','.']
                          ,['6', '.', '.', '1', '9', '5', '.', '.', '.']
                          ,['.', '9', '8', '.', '.', '.', '.', '6', '.']
                          ,['8', '.', '.', '.', '6', '.', '.', '.', '3']
                          ,['4', '.', '.', '8', '.', '3', '.', '.', '1']
                          ,['7', '.', '.', '.', '2', '.', '.', '.', '6']
                          ,['.', '6', '.', '.', '.', '.', '2', '8', '.']
                          ,['.', '.', '.', '4', '1', '9', '.', '.', '5']
                          ,['.', '.', '.', '.', '8', '.', '.', '7', '9']]")
                    .Result(true))
          .Add(it => it.Param2dArray<char>(
                        @"[['8','3','.','.','7','.','.','.','.']
                          ,['6', '.', '.', '1', '9', '5', '.', '.', '.']
                          ,['.', '9', '8', '.', '.', '.', '.', '6', '.']
                          ,['8', '.', '.', '.', '6', '.', '.', '.', '3']
                          ,['4', '.', '.', '8', '.', '3', '.', '.', '1']
                          ,['7', '.', '.', '.', '2', '.', '.', '.', '6']
                          ,['.', '6', '.', '.', '.', '.', '2', '8', '.']
                          ,['.', '.', '.', '4', '1', '9', '.', '.', '5']
                          ,['.', '.', '.', '.', '8', '.', '.', '7', '9']]")
              .Result(false));

    private bool Solution(char[][] board)
    {
        var rows = board.Length;
        var cols = board[0].Length;

        var rowMasks = new int[rows];
        var colMasks = new int[cols];
        var boxMasks = new int[rows / 3, cols / 3];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (board[i][j] == '.')
                {
                    continue;
                }

                var mask = 1 << board[i][j];

                if ((boxMasks[i / 3, j / 3] & mask) != 0)
                {
                    return false;
                }

                boxMasks[i / 3, j / 3] |= mask;

                if ((rowMasks[i] & mask) != 0)
                {
                    return false;
                }

                rowMasks[i] |= mask;

                if ((colMasks[j] & mask) != 0)
                {
                    return false;
                }

                colMasks[j] |= mask;
            }
        }

        return true;
    }
}