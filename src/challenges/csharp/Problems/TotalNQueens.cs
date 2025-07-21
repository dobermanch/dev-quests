//https://leetcode.com/problems/n-queens-ii

namespace LeetCode.Problems;

public sealed class TotalNQueens : ProblemBase
{
    [Theory]
    [ClassData(typeof(TotalNQueens))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(4).Result(2))
          .Add(it => it.Param(1).Result(1))
          .Add(it => it.Param(2).Result(0))
          .Add(it => it.Param(3).Result(0))
          .Add(it => it.Param(9).Result(352));

    private int Solution(int n)
    {
        int leftDiagMap = 0;
        int rightDiagMap = 0;
        int colMap = 0;

        int placeQueens(int row)
        {
            if (row >= n)
            {
                return 1;
            }

            var result = 0;
            for (var col = 0; col < n; col++)
            {
                var leftDiagShift = row + col;
                var rightDiagShift = n + (row - col);

                if ((colMap & 1 << col) != 0
                    || (leftDiagMap & 1 << leftDiagShift) != 0
                    || (rightDiagMap & 1 << rightDiagShift) != 0
                    )
                {
                    continue;
                }

                colMap |= 1 << col;
                leftDiagMap |= 1 << leftDiagShift;
                rightDiagMap |= 1 << rightDiagShift;

                result += placeQueens(row + 1);

                colMap &= ~(1 << col);
                leftDiagMap &= ~(1 << leftDiagShift);
                rightDiagMap &= ~(1 << rightDiagShift);
            }

            return result;
        }

        return placeQueens(0);
    }
}