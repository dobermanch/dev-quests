//https://leetcode.com/problems/unique-paths/description

namespace LeetCode.Problems;

public sealed class UniquePaths : ProblemBase
{
    [Theory]
    [ClassData(typeof(UniquePaths))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(3).Param(7).Result(28))
          .Add(it => it.Param(3).Param(2).Result(3))
        ;

    //Option 4
    private int Solution4(int m, int n)
    {
        var path = new int[m, n];

        for (var x = 1; x < m; x++)
        {
            path[x, 0] = 1;
        }
        for (var y = 1; y < n; y++)
        {
            path[0, y] = 1;
        }

        for (var y = 1; y < n; y++)
        {
            for (var x = 1; x < m; x++)
            {
                path[x, y] += path[x - 1, y] + path[x, y - 1];
            }
        }

        return path[m - 1, n - 1];
    }

    //Option 3
    private int Solution3(int m, int n)
    {
        var path = new int[m, n];

        for (var y = 1; y < n; y++)
        {
            for (var x = 1; x < m; x++)
            {
                path[x, y] += 1 + path[x - 1, y] + path[x, y - 1];
            }
        }

        return path[m - 1, n - 1] + 1;
    }

    //Option 2
    private int Solution2(int m, int n)
    {
        var path = new int[m, n];

        for (var y = 0; y < n; y++)
        {
            for (var x = 0; x < m; x++)
            {
                if (x - 1 >= 0)
                {
                    path[x, y] += path[x - 1, y];
                }
                if (y - 1 >= 0)
                {
                    path[x, y] += path[x, y - 1];
                }
                else
                {
                    path[x, y] = 1;
                }
            }
        }

        return path[m - 1, n - 1];
    }

    //Option 1
    private int Solution1(int m, int n)
    {
        return Path(0, 0, m - 1, n - 1);
    }

    private int Path(int x, int y, int width, int height)
    {
        if (x > width || y > height)
        {
            return 0;
        }

        var result = 0;
        result += Path(x + 1, y, width, height);
        result += Path(x, y + 1, width, height);

        return result += x == width && y == height ? 1 : 0;
    }
}