//https://leetcode.com/problems/fizz-buzz/
namespace LeetCode.Problems;

public sealed class FizzBuzz : ProblemBase
{
    public static void Run()
    {
        var d = Run(3); // ["1","2","Fizz"]
        //var d = Run(5); // ["1","2","Fizz","4","Buzz"]
        //var d = Run(15); // ["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz"]
    }

    private static IList<string> Run(int n)
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