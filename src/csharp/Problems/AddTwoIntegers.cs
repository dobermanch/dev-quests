//https://leetcode.com/problems/add-two-integers/

namespace LeetCode.Problems;

public sealed class AddTwoIntegers : ProblemBase
{
    public static void Run()
    {
        var d = Run(15, 11);
    }

    //Option 2
    private static int Run(int num1, int num2) 
    {
        if (num1 < -100 || num2 > 100)
        {
            throw new ArgumentException();
        }
        var carry = 0;
        while (num2 != 0)
        {
            carry = num1 & num2;
            num1 = num1 ^ num2;
            num2 = carry << 1;
        }
        return num1;
    }
}