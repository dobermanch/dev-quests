//https://leetcode.com/problems/squares-of-a-sorted-array/

namespace LeetCode.Problems;

public sealed class SortedSquares : ProblemBase
{
    [Theory]
    [ClassData(typeof(SortedSquares))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[-10,-5,-4,-3,-2,-1,0,1,1,7]").ResultArray("[0,1,1,1,4,9,16,25,49,100]"))
          .Add(it => it.ParamArray("[-10,-7,-5,-4,-3,-2,-1,0,1,1,6]").ResultArray("[0,1,1,1,4,9,16,25,36,49,100]"))
          .Add(it => it.ParamArray("[-3,0,2]").ResultArray("[0,4,9]"))
          .Add(it => it.ParamArray("[-9,-7,-5,-3,-1,2,4,4,7,10]").ResultArray("[1,4,9,16,16,25,49,49,81,100]"))
          .Add(it => it.ParamArray("[-4,-1,0,3,10]").ResultArray("[0,1,9,16,100]"))
          .Add(it => it.ParamArray("[-5,-4,1,2,5]").ResultArray("[1,4,16,25,25]"))
          .Add(it => it.ParamArray("[-10000,-9999,-7,-5,0,0,10000]").ResultArray("[0,0,25,49,99980001,100000000,100000000]"))
          .Add(it => it.ParamArray("[2,3,3,7,11]").ResultArray("[4,9,9,49,121]"))
          .Add(it => it.ParamArray("[-7,-3,2,3,11]").ResultArray("[4,9,9,49,121]"))
          .Add(it => it.ParamArray("[-7,-3,-2]").ResultArray("[4,9,49]"));

    private int[] Solution(int[] nums)
    {
        var result = new int[nums.Length];

        var start = 0;
        var end = nums.Length - 1;

        var insert = end;
        while (start <= end)
        {
            if (Math.Abs(nums[end]) > Math.Abs(nums[start]))
            {
                result[insert] = (int)Math.Pow(nums[end], 2);
                end--;
            }
            else
            {
                result[insert] = (int)Math.Pow(nums[start], 2);
                start++;
            }

            insert--;
        }

        return result;
    }
}