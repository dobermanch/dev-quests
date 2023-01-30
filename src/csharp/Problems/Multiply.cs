//https://leetcode.com/problems/multiply-strings/

using System.Text;

namespace LeetCode.Problems;

public sealed class Multiply : ProblemBase
{
    public static void Run()
    {
        //var d = Run("0", "12"); // 0
        //var d = Run("3", "4"); // 12
        //var d = Run("10", "12"); // 120
        var d = Run("145", "723"); //104835
        //var d = Run("43", "435"); //18705
        //var d = Run("343", "35"); //12005
        //var d = Run("4213", "1422"); //5990886
        //var d = Run("42137", "14223"); //599314551
        //var d = Run("421379", "142237"); //59935684823
        //var d = Run("123456789", "987654321"); //121932631112635269
        //var d = Run("6913259244", "71103343"); //491555843274052692
        //var d = Run("498828660196", "840477629533"); // 419254329864656431168468
    }

    //Option 2
    private static string Run(string num1, string num2)
    {
        var buffer = new int[num1.Length + num2.Length];
        for (var i = num2.Length - 1; i >= 0; i--)
        {
            var ch = num2[i] - '0';
            for (var j = num1.Length - 1; j >= 0; j--)
            {
                var accum = ch * (num1[j] - '0') + buffer[i + j + 1];
                buffer[i + j + 1] = accum % 10;
                buffer[i + j] += accum / 10;
            }
        }

        var result = new StringBuilder();
        foreach (var ch in buffer)
        {
            if (result.Length != 0 || ch != 0)
            {
                result.Append(ch);
            }
        }

        return result.Length == 0 ? "0" : result.ToString();
    }

    //Option 1 (https://www.youtube.com/watch?v=LgJ5bNHBbD4&t=478s)
    private static string Run1(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0")
        {
            return "0";
        }

        if (num1.Length > num2.Length)
        {
            num2 = string.Join("", Enumerable.Repeat("0", num1.Length - num2.Length)) + num2;
        }
        else
        {
            num1 = string.Join("", Enumerable.Repeat("0", num2.Length - num1.Length)) + num1;
        }

        var nums = Enumerable.Range(0, 10).ToDictionary(it => it + '0', it => it);
        var start = num1.Length - 1;
        var end = num1.Length - 1;
        var carry = 0;
        var builder = new StringBuilder();

        while (end >= 0)
        {
            var accum = carry;

            if (start == end)
            {
                accum += nums[num1[end]] * nums[num2[end]];
            }
            else
            {
                accum += nums[num1[start]] * nums[num2[end]];
                accum += nums[num1[end]] * nums[num2[start]];

                var startT = start;
                var endT = end;
                while (startT <= endT)
                {
                    startT++;
                    endT--;
                    if (startT == endT)
                    {
                        accum += nums[num1[startT]] * nums[num2[startT]];
                    }
                    else if (startT < endT)
                    {
                        accum += nums[num1[startT]] * nums[num2[endT]];
                        accum += nums[num1[endT]] * nums[num2[startT]];
                    }
                }
            }

            builder.Insert(0, accum % 10);
            carry = accum / 10;
            if (start == 0)
            {
                end--;
            }
            if (start > 0)
            {
                start--;
            }
        }

        if (carry > 0)
        {
            builder.Insert(0, carry);
        }

        return builder.Length == 0 ? "0" : builder.ToString().TrimStart('0');
    }
}