//https://leetcode.com/problems/asteroid-collision/

namespace LeetCode.Problems;

public sealed class AsteroidCollision : ProblemBase
{
    [Theory]
    [ClassData(typeof(AsteroidCollision))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[8,-8]").ResultArray("[]"))
          .Add(it => it.ParamArray("[5,10,-5]").ResultArray("[5,10]"))
          .Add(it => it.ParamArray("[-2,-1,1,2]").ResultArray("[-2,-1,1,2]"))
          .Add(it => it.ParamArray("[-2,-2,1,-2]").ResultArray("[-2,-2,-2]"))
          .Add(it => it.ParamArray("[2,5,-5,5,10]").ResultArray("[2,5,10]"))
          .Add(it => it.ParamArray("[-2,-2,-2,1]").ResultArray("[-2,-2,-2,1]"))
          .Add(it => it.ParamArray("[46,-36,3,39,20,-33,35,4,-26,-37,27,-50,-23,48,5,-1,29,-34,34,11,22,8,41,-20,-10,17,35,-14,-9,3,12,-13,-47,23,-39,25,-43,-2,26,-26,-42,-5,-4,34,3,25,20,27,-6]").ResultArray("[-50,-23,48,34,3,25,20,27]"))
          .Add(it => it.ParamArray("[-4,-1,10,2,-1,8,-9,-6,5,2]").ResultArray("[-4,-1,10,5,2]"))
          .Add(it => it.ParamArray("[-5,10]").ResultArray("[-5,10]"))
          .Add(it => it.ParamArray("[10,2,-5]").ResultArray("[10]"));

    private int[] Solution(int[] asteroids)
    {
        var stack = new List<int>(asteroids.Length);
        foreach (var asteroid in asteroids)
        {
            bool add = true;
            while (stack.Any() && stack[^1] > 0 && asteroid < 0)
            {
                if (stack[^1] < -asteroid)
                {
                    stack.RemoveAt(stack.Count - 1);
                    continue;
                }

                add = false;
                if (stack[^1] == -asteroid)
                {
                    stack.RemoveAt(stack.Count - 1);
                }

                break;
            }

            if (add)
            {
                stack.Add(asteroid);
            }
        }

        return stack.ToArray();
    }
}