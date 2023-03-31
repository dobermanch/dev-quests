//https://leetcode.com/problems/sort-colors/

namespace LeetCode.Problems;

public sealed class SortColors : ProblemBase
{
    [Theory]
    [ClassData(typeof(SortColors))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[2,0,2,1,1,0]").ResultArray("[0,0,1,1,2,2]"))
          .Add(it => it.ParamArray("[0,2,1]").ResultArray("[0,1,2]"))
          .Add(it => it.ParamArray("[2,0,1]").ResultArray("[0,1,2]"))
          .Add(it => it.ParamArray("[2,0,2,1,1,2,0]").ResultArray("[0,0,1,1,2,2,2]"))
          .Add(it => it.ParamArray("[2,0,2,1,2,1,2,0]").ResultArray("[0,0,1,1,2,2,2,2]"))
          .Add(it => it.ParamArray("[2,0,2,1,2,1,2,2]").ResultArray("[0,1,1,2,2,2,2,2]"))
          .Add(it => it.ParamArray("[0,1,1,0,2,1,2,2]").ResultArray("[0,0,1,1,1,2,2,2]"))
          .Add(it => it.ParamArray("[0,1,1,0,2,0,2,2]").ResultArray("[0,0,0,1,1,2,2,2]"));

    private int[] Solution(int[] nums)
    {
        var zero = 0;
        var two = nums.Length - 1;
        var current = 0;
        while(current <= two)
        {
            if (nums[current] == 0)
            {
                (nums[zero], nums[current]) = (nums[current], nums[zero]);
                zero++;
                current++;
            }
            else if(nums[current] == 2)
            {
                (nums[two], nums[current]) = (nums[current], nums[two]);
                two--;
            }
            else
            {
                current++;
            }
        }

        return nums;
    }
}