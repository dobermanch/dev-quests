//https://leetcode.com/problems/n-queens

namespace LeetCode.Problems;

public sealed class SolveNQueens : ProblemBase
{
    [Theory]
    [ClassData(typeof(SolveNQueens))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(4).Result2dArray<string>("""[[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]"""))
          .Add(it => it.Param(1).Result2dArray<string>("""[["Q"]]"""))
          .Add(it => it.Param(2).Result2dArray<string>("""[]""", false))
          .Add(it => it.Param(3).Result2dArray<string>("""[]""", false));

    private IList<IList<string>> Solution(int n)
    {
        var result = new List<IList<string>>();
        var board = Enumerable.Range(0, n).Select(it => Enumerable.Repeat('.', n).ToArray()).ToArray();

        int leftDiagMap = 0;
        int rightDiagMap = 0;
        int colMap = 0;

        void placeQueens(int row = 0)
        {
            if (row >= n)
            {
                result.Add(board.Select(it => new string(it)).ToArray());
                return;
            }

            for (var col = 0; col < n; col++)
            {
                if ((colMap & 1 << col) != 0
                    || (leftDiagMap & 1 << (row + col)) != 0
                    || (rightDiagMap & 1 << (n + (row - col))) != 0
                    )
                {
                    continue;
                }

                board[row][col] = 'Q';

                colMap |= 1 << col;
                leftDiagMap |= 1 << (row + col);
                rightDiagMap |= 1 << (n + (row - col));

                placeQueens(row + 1);

                board[row][col] = '.';

                colMap &= ~(1 << col);
                leftDiagMap &= ~(1 << (row + col));
                rightDiagMap &= ~(1 << (n + (row - col)));
            }
        }

        placeQueens();

        return result;
    }

    private IList<IList<string>> Solution1(int n)
    {
        var result = new List<IList<string>>();
        var board = Enumerable.Range(0, n).Select(it => Enumerable.Repeat('.', n).ToArray()).ToArray();

        void placeQueens(int row = 0)
        {
            if (row >= n)
            {
                result.Add(board.Select(it => new string(it)).ToArray());
                return;
            }

            for (var col = 0; col < n; col++)
            {
                if (canPlace(row, col))
                {
                    board[row][col] = 'Q';

                    placeQueens(row + 1);

                    board[row][col] = '.';
                }
            }
        }

        bool canPlace(int row, int col)
        {
            for (var r = row; r >= 0; r--)
            {
                if (board[r][col] == 'Q')
                {
                    return false;
                }
            }

            for (int r = row, c = col; r >= 0 && c >= 0; r--, c--)
            {
                if (board[r][c] == 'Q')
                {
                    return false;
                }
            }

            for (int r = row, c = col; r >= 0 && c < n; r--, c++)
            {
                if (board[r][c] == 'Q')
                {
                    return false;
                }
            }

            return true;
        }

        placeQueens();

        return result;
    }
}