namespace LeetCode.Problems;

public sealed class FirstBadVersion : ProblemBase
{
    public static void Run()
    {
        //var d = Run(new int[]{-1,0,3,5,9,12}, 9);
        var d = Run(30);
    }

    private static int Run(int n)
    {
        var start = 0;
        var end = n;
        var result = 1;
        do
        {
            var version = start + (end - start) / 2;
            if (IsBadVersion(version))
            {
                result = version;
                end = version - 1;
            }
            else
            {
                start = version + 1;
            }
        }
        while (start <= end);

        return result;
    }


    static bool IsBadVersion(int version)
    {
        return version > 10;
    }
}