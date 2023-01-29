//https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero/

namespace LeetCode.Problems;

public sealed class NumberOfSteps : ProblemBase
{
    public static void Run()
    {
        var result = Run(14); // 6
        //var result = Run(8); // 4
        //var result = Run(123); // 12
    }

    private static int Run(int num) 
    {
        var result = 0;
        while (num != 0){
            if (num % 2 == 0) {
                num >>= 1;
            }
            else {
                num -= 1;
            }

            result++;
        }

        return result;
    }
}