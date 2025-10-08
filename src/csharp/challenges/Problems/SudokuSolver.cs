// https://leetcode.com/problems/sudoku-solver

namespace LeetCode.Problems;

public sealed class SudokuSolver : ProblemBase
{
    [Theory]
    [ClassData(typeof(SudokuSolver))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it =>
                it.Param2dArray<char>(
                        @"[['5','3','.','.','7','.','.','.','.'],
                    ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
                    ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
                    ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
                    ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
                    ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
                    ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
                    ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
                    ['.', '.', '.', '.', '8', '.', '.', '7', '9']]")
                    .Result2dArray<char>(
                        @"[['5','3','4','6','7','8','9','1','2'],
                    ['6','7','2','1','9','5','3','4','8'],
                    ['1','9','8','3','4','2','5','6','7'],
                    ['8','5','9','7','6','1','4','2','3'],
                    ['4','2','6','8','5','3','7','9','1'],
                    ['7','1','3','9','2','4','8','5','6'],
                    ['9','6','1','5','3','7','2','8','4'],
                    ['2','8','7','4','1','9','6','3','5'],
                    ['3','4','5','2','8','6','1','7','9']]")
            )
            .Add(it =>
                it.Param2dArray<char>(
                        @"[['.','.','.','.','.','.','.','.','.'],
                    ['.','9','.','.','1','.','.','3','.'],
                    ['.','.','6','.','2','.','7','.','.'],
                    ['.','.','.','3','.','4','.','.','.'],
                    ['2','1','.','.','.','.','.','9','8'],
                    ['.','.','.','.','.','.','.','.','.'],
                    ['.','.','2','5','.','6','4','.','.'],
                    ['.','8','.','.','.','.','.','1','.'],
                    ['.','.','.','.','.','.','.','.','.']]")
                    .Result2dArray<char>(
                        @"[['7','2','1','8','5','3','9','4','6'],
                    ['4','9','5','6','1','7','8','3','2'],
                    ['8','3','6','4','2','9','7','5','1'],
                    ['9','6','7','3','8','4','1','2','5'],
                    ['2','1','4','7','6','5','3','9','8'],
                    ['3','5','8','2','9','1','6','7','4'],
                    ['1','7','2','5','3','6','4','8','9'],
                    ['6','8','3','9','4','2','5','1','7'],
                    ['5','4','9','1','7','8','2','6','3']]")
            );

    private char[][] Solution(char[][] board)
    {
        var size = board.Length;
        var cols = new bool[size, size];
        var rows = new bool[size, size];
        var blocks = new bool[size, size];

        for (var row = 0; row < size; row++)
        {
            for (var col = 0; col < size; col++)
            {
                if (board[row][col] == '.')
                {
                    continue;
                }

                var val = board[row][col] - '1';
                cols[col, val] = true;
                rows[row, val] = true;

                var blockIndex = row / 3 * 3 + col / 3;
                blocks[blockIndex, val] = true;
            }
        }

        bool Solve(int row, int col)
        {
            if (row >= size)
            {
                return true;
            }

            if (col >= size)
            {
                return Solve(row + 1, 0);
            }

            if (board[row][col] != '.')
            {
                return Solve(row, col + 1);
            }

            for (var val = 0; val <= 8; val++)
            {
                int blockIndex = row / 3 * 3 + col / 3;
                if (cols[col, val]
                    || rows[row, val]
                    || blocks[blockIndex, val])
                {
                    continue;
                }

                cols[col, val] = true;
                rows[row, val] = true;
                blocks[blockIndex, val] = true;

                var solved = col + 1 >= size ? Solve(row + 1, 0) : Solve(row, col + 1);
                if (solved)
                {
                    board[row][col] = (char)(val + '1');
                    return true;
                }

                cols[col, val] = false;
                rows[row, val] = false;
                blocks[blockIndex, val] = false;
            }

            return false;
        }

        Solve(0, 0);

        return board;
    }
}
