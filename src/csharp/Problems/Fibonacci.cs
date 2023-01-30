//https://leetcode.com/problems/fibonacci-number/description

namespace LeetCode.Problems;

public sealed class Fibonacci : ProblemBase
{
    public static int Run()
    {
        var result = Fib(15);

        return result;
    }

    // OPTION 2
    private static int Fib(int n)
    {
        if (n == 1 || n == 0)
        {
            return n;
        }

        var t0 = 0;
        var t1 = 1;
        while (--n > 0)
        {
            var temp = t1;
            t1 = t1 + t0;
            t0 = temp;
        }

        return t1;
    }

    // OPTION 1
    // private static  int Fib(int n) {
    //     if (n == 1 || n == 0){
    //         return n;
    //     }

    //     return Fib(n - 1) + Fib(n - 2);
    // }
}