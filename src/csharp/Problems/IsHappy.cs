//https://leetcode.com/problems/happy-number/

namespace LeetCode.Problems;

public sealed class IsHappy : ProblemBase
{
    public static void Run()
    {
        var d = Run(19); //true
        //var d = Run(2); //false
    }

    private static bool Run(int n)
    {
        var map = new HashSet<int>();
        var value = n;
        while (value != 1)
        {
            var sum = 0;
            while (value > 0)
            {
                int remain = value % 10;
                sum += remain * remain;
                value /= 10;
            }

            if (map.Contains(sum))
            {
                return false;
            }

            map.Add(sum);
            value = sum;
        }

        return true;
    }

    //Option1
    private static bool Run1(int n)
    {
        var map = new HashSet<int>();
        var sum = n;
        while (sum != 1)
        {
            sum = sum.ToString().Select(i => (int)Math.Pow(i - '0', 2)).Sum();
            if (map.Contains(sum))
            {
                return false;
            }

            map.Add(sum);
        }

        return true;
    }
}