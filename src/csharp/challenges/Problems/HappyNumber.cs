//https://leetcode.com/problems/happy-number/

namespace LeetCode.Problems;

public sealed class IsHappy : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsHappy))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(19).Result(true))
          .Add(it => it.Param(2).Result(false))
        ;

    private bool Solution(int n)
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
    private bool Solution1(int n)
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