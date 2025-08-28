// https://leetcode.com/problems/equal-row-and-column-pairs/?envType=study-plan-v2&envId=leetcode-75

namespace LeetCode.Problems;

public sealed class EqualPairs : ProblemBase
{
    [Theory]
    [ClassData(typeof(EqualPairs))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[3,2,1],[1,7,6],[2,7,7]]").Result(1))
          .Add(it => it.Param2dArray("[[3,1,2,2],[1,4,4,5],[2,4,2,2],[2,4,2,2]]").Result(3));

    private int Solution(int[][] grid)
    {
        // var colMap = new Dictionary<int, IList<int>>();
        // for(var c = 0; c < grid.Length; c++)
        // {
        //     colMap.GetValueOrDefault(grid[0][c], new List<int>()).Add(c);
        // }

        var colMap = grid[0]
            .Select((value, index) => (value, index))
            .GroupBy(it => it.value)
            .ToDictionary(it => it.Key, it => it);

        var result = 0;
        for (var r = 0; r < grid.Length; r++)
        {
            if (!colMap.TryGetValue(grid[r][0], out var cols))
            {
                continue;
            }

            foreach(var col in cols)
            {
                var matched = true;
                for (var i = 0; i < grid.Length; i++)
                {
                    if(grid[i][col.index] != grid[r][i])
                    {
                        matched = false;
                        break;
                    }
                }

                if (matched)
                {
                    result++;
                }
            }
        }

        return result;
    }
}