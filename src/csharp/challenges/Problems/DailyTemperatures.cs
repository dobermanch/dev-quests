//https://leetcode.com/problems/daily-temperatures/

namespace LeetCode.Problems;

public sealed class DailyTemperatures : ProblemBase
{
    [Theory]
    [ClassData(typeof(DailyTemperatures))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[73,74,75,71,69,72,76,73]").ResultArray("[1,1,4,2,1,1,0,0]"))
          .Add(it => it.ParamArray("[73,74,75,75,69,72,76,73]").ResultArray("[1,1,4,3,1,1,0,0]"))
          .Add(it => it.ParamArray("[73,74,75,71,69,40,51,56,43,72,76,73]").ResultArray("[1,1,8,6,5,1,1,2,1,1,0,0]"))
          .Add(it => it.ParamArray("[30,40,50,60]").ResultArray("[1,1,1,0]"))
          .Add(it => it.ParamArray("[30,60,90]").ResultArray("[1,1,0]"));

    private int[] Solution(int[] temperatures)
    {
        var result = new int[temperatures.Length];
        var stack = new Stack<int>();
        for (int i = temperatures.Length - 1; i >= 0; i--)
        {
            while (stack.Any())
            {
                if (temperatures[stack.Peek()] > temperatures[i])
                {
                    result[i] = stack.Peek() - i;
                    break;
                }
                stack.Pop();
            }

            stack.Push(i);
        }

        return result;
    }
}