//https://leetcode.com/problems/fizz-buzz/

namespace LeetCode.Problems;

public sealed class FizzBuzz : ProblemBase
{
    [Theory]
    [ClassData(typeof(FizzBuzz))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param(3).ResultArray<string>("""["1","2","Fizz"]"""))
          .Add(it => it.Param(5).ResultArray<string>("""["1","2","Fizz","4","Buzz"]"""))
          .Add(it => it.Param(15).ResultArray<string>("""["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz"]"""));

    private IList<string> Solution(int n)
    {
        var result = new List<string>(n);
        for (var i = 1; i < n + 1; i++) 
        {
            if (i % 3 == 0 && i % 5 == 0 ) 
            {
                result.Add(string.Intern("FizzBuzz"));
            }
            else if (i % 3 == 0) 
            {
                result.Add(string.Intern("Fizz"));
            }
            else if (i % 5 == 0) 
            {
                result.Add(string.Intern("Buzz"));
            }
            else 
            {
                result.Add(i.ToString());
            }
        }

        return result;
    }
}