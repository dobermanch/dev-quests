//https://leetcode.com/problems/unique-paths/description

namespace LeetCode.Problems;

public sealed class UniquePaths : ProblemBase
{
    public static void Run()
    {
        //var result = Run(3,2);
        //var result = Run(3,7);
        var result = Run4(3, 3);
    }

    //Option 4
    private static int Run4(int m, int n)
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
    private static int Run3(int m, int n)
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
    private static int Run2(int m, int n)
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
    private static int Run1(int m, int n)
    {
        return Path(0, 0, m - 1, n - 1);
    }

    private static int Path(int x, int y, int width, int height)
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