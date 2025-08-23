//https://leetcode.com/problems/candy

namespace LeetCode.Problems;

public sealed class Candy : ProblemBase
{
    [Theory]
    [ClassData(typeof(Candy))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[6,7,6,5,4,3,2,1,0,0,0,1,0]").Result(42))
          .Add(it => it.ParamArray("[100,80,70,60,70,80,90,100,90,80,70,60,60]").Result(35))
          .Add(it => it.ParamArray("[1,0,2,4,5,2,4,23,23,5,3,23]").Result(26))
          .Add(it => it.ParamArray("[1,0,2,4,5,2,4]").Result(15))
          .Add(it => it.ParamArray("[1,0,2]").Result(5))
          .Add(it => it.ParamArray("[1,2,2]").Result(4));

    private int Solution(int[] ratings)
    {
        var result = 1;
        var increase = 0;
        var decrease = 0;
        var maxCandy = 0;
        for (var i = 1; i < ratings.Length; i++)
        {
            if (ratings[i - 1] < ratings[i])
            {
                maxCandy = ++increase;
                result += increase + 1;
                decrease = 0;
            }
            else if (ratings[i - 1] > ratings[i])
            {
                decrease++;
                result += decrease + (maxCandy >= decrease ? 0 : 1);
                increase = 0;
            }
            else
            {
                result += 1;
                decrease = 0;
                maxCandy = 0;
                increase = 0;
            }
        }

        return result;
    }
}