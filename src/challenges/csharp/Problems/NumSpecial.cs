//https://leetcode.com/problems/special-positions-in-a-binary-matrix

namespace LeetCode.Problems;

public sealed class NumSpecial : ProblemBase
{
    [Theory]
    [ClassData(typeof(NumSpecial))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,0,0],[0,0,1],[1,0,0]]").Result(1))
          .Add(it => it.Param2dArray("[[1,0,0],[0,1,0],[0,0,1]]").Result(3))
          .Add(it => it.Param2dArray("[[0,0,0,0,0],[1,0,0,0,0],[0,1,0,0,0],[0,0,1,0,0],[0,0,0,1,1]]").Result(3))
          .Add(it => it.Param2dArray("[[0,0,1,0],[0,0,0,0],[0,0,0,0],[0,1,0,0]]").Result(2))
          .Add(it => it.Param2dArray("[[0,0,0,0,0,1,0,0],[0,0,0,0,1,0,0,1],[0,0,0,0,1,0,0,0],[1,0,0,0,1,0,0,0],[0,0,1,1,0,0,0,0]]").Result(1));

    private int Solution(int[][] mat)
    {
        var result = 0;
        var rowMap = new int[mat.Length];
        var colMap = new int[mat[0].Length];
        for (int row = 0; row < mat.Length; row++)
        {
            for (int col = 0; col < mat[0].Length; col++)
            {                
                if (mat[row][col] == 1) 
                {
                    rowMap[row] += 1;
                    colMap[col] += 1;
                }
            }
        }

        for (int row = 0; row < mat.Length; row++)
        {
            if (rowMap[row] != 1)
            {
                continue;
            }

            for (int col = 0; col < mat[0].Length; col++)
            {                
                if (mat[row][col] == 1 && colMap[col] == 1)
                {
                    result++;
                }
            }
        }

        return result;
    }
}